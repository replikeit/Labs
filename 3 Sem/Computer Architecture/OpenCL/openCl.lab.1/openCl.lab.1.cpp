#include "OpenCL.h"
#include "DeviceEx.h"
#include <iostream>
#include "KernelEx.h"
#include <iomanip>
#include <fstream>

class Matrix
{
public:
	int Rows;
	int Columns;
	int* Data;

	Matrix(int rows, int columns, int* data) : Rows(rows), Columns(columns), Data(data) { }

	void Dispose()
	{
		delete[] Data;
		Data = nullptr;
	}
	
	int Get(int i, int j) const
	{
		return Data[i * Columns + j];
	}

	Matrix Transpose() const
	{
		auto data = new int[Rows * Columns];
		for (auto i = 0; i < Rows; ++i)
		{
			for (auto j = 0; j < Columns; ++j)
			{
				data[j * Rows + i] = Get(i, j);
			}
		}
		return Matrix(Columns, Rows, data);
	}
};

class Main
{
public:

	static int* VecCharToVecInt(const char* str)
	{
		int size = strlen(str);
		int *result = new int[size];
		for (int i = 0; i < size;i++)
		{
			result[i] = (int)str[i];
		}
		return result;
	}
	
	static void Run(const char* mode,const char* path,const char* string = "")
	{
		try
		{
			auto device = DeviceEx::Find("NVIDIA");			
			RunOnDevice(device, mode,path, string);
			system("pause");
		}
		catch (const std::exception& e)
		{
			std::cerr << e.what() << std::endl;
		}
	}

private:
	static void RunOnDevice(const cl::Device& device, const char* mode, const char* path, const char* string)
	{
		std::fstream input(path, std::ios_base::in | std::ios_base::binary);
		int temp;
		input.read(reinterpret_cast<char*>(&temp), sizeof(int));
		auto n = temp;
		input.read(reinterpret_cast<char*>(&temp), sizeof(int));
		auto m = temp;
		
		auto binMatrix = CreateMatrix(_byteswap_ulong(n), _byteswap_ulong(m)*4, std::move(input));
		int* strVec = VecCharToVecInt(string);
		
		auto context = DeviceEx::CreateContext(device);

	
		

		if (strcmp(mode, "Encrypt") == 0)
		{
			int* strVec = VecCharToVecInt(string);
			auto matBuffer = CreateBuffer(context, binMatrix, CL_MEM_READ_WRITE);
			auto strBuffer = cl::Buffer(context, CL_MEM_READ_WRITE | CL_MEM_COPY_HOST_PTR, 
				sizeof(int) * strlen(string), strVec);
			RunKernel(device, context, matBuffer, strBuffer, strlen(string), n, m, "encryptionToBin", path,mode);

		}
		else if (strcmp(mode, "Decrypt") == 0)
		{
			int* strVec = new int[_byteswap_ulong(m)];
			auto matBuffer = CreateBuffer(context, binMatrix, CL_MEM_READ_WRITE);
			auto strBuffer = cl::Buffer(context, CL_MEM_READ_WRITE | CL_MEM_COPY_HOST_PTR, 
				sizeof(int) * _byteswap_ulong(m)*4, new int[_byteswap_ulong(m) * 4]);
			RunKernel(device, context, matBuffer, strBuffer, _byteswap_ulong(m) * 4, n, m, "Dencryption", path,mode);
		}
		else
			std::cout << "Wrong input of mode(only can be 'Encrypt' or 'Decrypt')" << std::endl;
	}

	static void RunKernel(const cl::Device& device, const cl::Context& context, cl::Buffer matBuf,
		cl::Buffer strBuf ,int strLen ,int n, int m, std::string kernelName, const char* path, const char* mode)
	{
		int rows = _byteswap_ulong(n);
		int collums = _byteswap_ulong(m)*4;
		auto kernel = KernelEx::BuildFromFile(device, context, "Kernel.cl", kernelName);
		
		kernel.setArg(0, strBuf);
		kernel.setArg(1, matBuf);
		kernel.setArg(2, rows);
		kernel.setArg(3, collums);
		kernel.setArg(4,strLen);

		

		if (strcmp(mode, "Encrypt") == 0)
		{
			auto queue = cl::CommandQueue(context, device);
			queue.enqueueNDRangeKernel(kernel, cl::NullRange, cl::NDRange(rows));
			queue.finish();
			Matrix encMat(rows, collums, new int[rows * collums]{});
			ReadFromBuffer(queue, encMat, matBuf);
			encMat.Data[strLen] = -1;
			WriteMatrix(encMat, n, m, path);
		}
		else if (strcmp(mode, "Decrypt") == 0)
		{
			auto queue = cl::CommandQueue(context, device);
			queue.enqueueNDRangeKernel(kernel, cl::NullRange, cl::NDRange(rows));
			queue.finish();
			int* strVec = new int[collums];
			queue.enqueueReadBuffer(strBuf, CL_TRUE, 0,  strLen * sizeof(int), strVec);
			for (int i = 0; strVec[i] != -1; i++)
				std::cout <<(char)strVec[i];
			std::cout << std::endl;
		}
		
	
	}

	static void WriteMatrix(Matrix mat,int n, int m ,const char* path)
	{
		std::ofstream output(path, std::ios_base::binary);
		output.write(reinterpret_cast<char*>(&m), sizeof(int));
		output.write(reinterpret_cast<char*>(&n), sizeof(int));
		for(int i = 0; i < _byteswap_ulong(n);i++)
			for(int j = 0; j < _byteswap_ulong(m)*4;j++)
			{
				int x = mat.Get(i, j);
				output.write(reinterpret_cast<char*>(&x) , sizeof(char));
			}
		output.close();
	}
	
	static Matrix CreateMatrix(int n, int m, std::fstream input)
	{
		
		auto size = n * m;
		char x = 0;
		auto matrix = new int[size];
		for (auto k = 0; k < size; ++k)
		{
			input.read((&x), sizeof(char));
			matrix[k] = int(x);
		}
		input.close();
		return Matrix(n, m, matrix);
	}

	static void Print(Matrix matrix)
	{
		

		for (auto i = 0; i < matrix.Rows; ++i)
		{
			for (auto j = 0; j < matrix.Columns; ++j)
			{
				std::cout << matrix.Get(i, j) << " ";
			}
			std::cout << std::endl;
		}
		std::cout << std::endl;
	}

	static cl::Buffer CreateBuffer(const cl::Context& context, Matrix matrix, int accessFlag)
	{
		return cl::Buffer(context, accessFlag | CL_MEM_COPY_HOST_PTR, matrix.Rows * matrix.Columns * sizeof(int), matrix.Data);
	}

	static void ReadFromBuffer(const cl::CommandQueue& queue, Matrix matrix, const cl::Buffer& buffer)
	{
		queue.enqueueReadBuffer(buffer, CL_TRUE, 0, matrix.Rows * matrix.Columns * sizeof(int), matrix.Data);
	}

	static void Print(int* counters, const int size)
	{
		for (auto i = 0; i < size; i += 3)
		{
			std::cout << "counters[" << i << "...] = " << counters[i] << ", " << counters[i + 1] << ", " << counters[i + 2] << std::endl;
		}
	}
};

int main(int argc, char* argv[])
{

	if (argc == 3)
	{
		if (strcmp(argv[1], "Decrypt") == 0)
			Main::Run(argv[1], argv[2]);
		else
			std::cout << "Need 2 arguments: (Mode) and (bin file path)" << std::endl;
	}
	else if (argc == 4)
	{
		if (strcmp(argv[1], "Encrypt") == 0)
			Main::Run(argv[1], argv[2], argv[3]);
		else
			std::cout << "Need 3 arguments:(Mode), (bin file path) and (encrypting string)" << std::endl;
	}
	else
	{
		std::cout << "Need 2 (for Decryption) or 3 (for Encryption) arguments." << std::endl;
	}
	Main::Run("Decrypt","data.bin", "Decrypt");
}