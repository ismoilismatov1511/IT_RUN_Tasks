// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string filePath = "products.txt";

    static void Main()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("a) Показать список продуктов");
        Console.WriteLine("b) Добавить новый продукт");
        Console.WriteLine("c) Продать продукт");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (choice)
        {
            case 'a':
                ShowProductList();
                break;
            case 'b':
                AddNewProduct();
                break;
            case 'c':
                SellProduct();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        Console.ReadLine();
    }

    static void ShowProductList()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Список продуктов пуст.");
            return;
        }

        Console.WriteLine("Список продуктов:");
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            string name = parts[0];
            int quantity = int.Parse(parts[1]);
            Console.WriteLine($"{name}: {quantity}");
        }
    }

    static void AddNewProduct()
    {
        Console.Write("Введите имя продукта: ");
        string name = Console.ReadLine();

        Console.Write("Введите количество: ");
        int quantity = int.Parse(Console.ReadLine());

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts[0] == name)
                {
                    int existingQuantity = int.Parse(parts[1]);
                    lines[i] = $"{name};{existingQuantity + quantity}";
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Количество продукта обновлено.");
                    return;
                }
            }
        }

        string newProduct = $"{name};{quantity}";
        File.AppendAllText(filePath, newProduct + Environment.NewLine);
        Console.WriteLine("Новый продукт добавлен.");
    }

    static void SellProduct()
    {
        Console.Write("Введите имя продукта: ");
        string name = Console.ReadLine();

        Console.Write("Введите количество: ");
        int quantity = int.Parse(Console.ReadLine());

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Список продуктов пуст.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        bool productFound = false;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts[0] == name)
            {
                int existingQuantity = int.Parse(parts[1]);
                if (existingQuantity >= quantity)
                {
                    lines[i] = $"{name};{existingQuantity - quantity}";
                    File.WriteAllLines(filePath, lines);
                    Console.WriteLine("Продукт продан.");
                }
                else
                {
                    Console.WriteLine("Недостаточное количество продукта.");
                }
                productFound = true;
                break;
            }
        }

        if (!productFound)
        {
            Console.WriteLine("Продукт не найден.");
        }
    }
}

//garbech collecter

    