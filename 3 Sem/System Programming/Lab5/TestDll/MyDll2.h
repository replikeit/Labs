#pragma once
#ifdef DLL_EXPORT
#define PORT __declspec(dllexport)
#else
#define PORT __declspec(dllimport)
#endif


extern "C" {
	PORT BOOLEAN __stdcall GetAuthor(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten);
	PORT BOOLEAN __stdcall GetDescription(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten);
	PORT void __stdcall Execute();
}



