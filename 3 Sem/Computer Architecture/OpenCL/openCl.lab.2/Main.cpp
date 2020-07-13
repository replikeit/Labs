#include "OpenCL.h"
#include "DeviceEx.h"
#include <iostream>
#include "KernelEx.h"
#include <iomanip>

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
	static void Run()
	{
		try
		{
			auto device = DeviceEx::Find("NVIDIA");
			//auto v = device.getInfo<CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE>();
			RunOnDevice(device);
		}
		catch (const std::exception& e)
		{
			std::cerr << e.what() << std::endl;
		}
	}

private:
	static void RunOnDevice(const cl::Device& device)
	{
		srand(0);
		auto n = 1600;
		auto m = 160;
		auto l = 1600;
		auto m1 = CreateMatrix(n, m);
		auto m2 = CreateMatrix(m, l);
		auto m2T = m2.Transpose();	
		Print(m1);
		Print(m2);
		
		auto context = DeviceEx::CreateContext(device);
		auto m1Buffer = CreateBuffer(context, m1, CL_MEM_READ_ONLY);
		auto m2TBuffer = CreateBuffer(context, m2T, CL_MEM_READ_ONLY);
		
		RunKernel(device, context, m1Buffer, m2TBuffer, n, m, l, "DefaultMulty");
		RunKernel(device, context, m1Buffer, m2TBuffer, n, m, l, "Vector2");
		RunKernel(device, context, m1Buffer, m2TBuffer, n, m, l, "Vector4");
		RunKernel(device, context, m1Buffer, m2TBuffer, n, m, l, "Vector8");
		m1.Dispose();
		m2.Dispose();
		m2T.Dispose();
	}

	static void RunKernel(const cl::Device& device, const cl::Context& context, cl::Buffer m1Buffer, cl::Buffer m2Buffer, int n, int m, int l, std::string kernelName)
	{
		auto m3 = Matrix(n, l, new int[n * l]{});
		auto m3Buffer = CreateBuffer(context, m3, CL_MEM_READ_WRITE);

		auto kernel = KernelEx::BuildFromFile(device, context, "Kernel.cl", kernelName);
		kernel.setArg(0, m1Buffer);
		kernel.setArg(1, m2Buffer);
		kernel.setArg(2, m3Buffer);
		kernel.setArg(3, n);
		kernel.setArg(4, m);
		kernel.setArg(5, l);

		auto event = cl::Event();
		auto queue = cl::CommandQueue(context, device, CL_QUEUE_PROFILING_ENABLE);
		queue.enqueueNDRangeKernel(kernel, cl::NullRange, cl::NDRange(m3.Rows, m3.Columns), cl::NullRange, nullptr, &event);
		queue.finish();

		auto startTime = event.getProfilingInfo<CL_PROFILING_COMMAND_START>();
		auto endTime = event.getProfilingInfo<CL_PROFILING_COMMAND_END>();
		std::cout << "Time "<<kernelName <<": " << std::fixed << std::setprecision(3) << (endTime - startTime) / 1000000.0 << " ms" << std::endl;

		ReadFromBuffer(queue, m3, m3Buffer);
		Print(m3);
	}

	static Matrix CreateMatrix(int n, int m)
	{
		auto size = n * m;
		auto matrix = new int[size];
		for (auto k = 0; k < size; ++k)
		{
			matrix[k] = rand() % 8 - 4;
		}
		return Matrix(n, m, matrix);
	}

	static void Print(Matrix matrix)
	{
		return;
		for (auto i = 0; i < matrix.Rows; ++i)
		{
			for (auto j = 0; j < matrix.Columns; ++j)
			{
				std::cout << std::setw(4) <<matrix.Get(i, j) << " ";
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

};

int main()
{
	Main::Run();
}