// EngGameLang.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#define EXPORT_API __declspec(dllexport)

#define IMPORT_API __declspec(dllimport)

#include <iostream>

extern "C" {
    void EXPORT_API FillPlay(char* first, int size)
    {
        strcpy_s(first, size, "Jouer");
    }
    void EXPORT_API FillEdit(char* first, int size)
    {
        strcpy_s(first, size, "Edition");
    }
    void EXPORT_API FillPHealth(char* first, int size)
    {
        strcpy_s(first, size, "Sante des Joueurs");
    }
    void EXPORT_API FillCMode(char* first, int size)
    {
        strcpy_s(first, size, "Mode Actuel");
    }
    void EXPORT_API FillCObject(char* first, int size)
    {
        strcpy_s(first, size, "Objet Courant");
    }
}

/*int main()
{
    std::cout << "Hello World!\n";
}*/
