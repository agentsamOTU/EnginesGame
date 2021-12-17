#define EXPORT_API __declspec(dllexport)

#define IMPORT_API __declspec(dllimport)

#include <iostream>

extern "C" {
	float EXPORT_API GetLife()
	{
		return 0.5f;
	}
}