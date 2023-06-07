// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

public class FileManager
{
    private string filePath;

    public FileManager(string path)
    {
        filePath = path;
    }

    public void WriteToFile(string data)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(data);
            }
        }
    }

    public string ReadFromFile()
    {
        string data = string.Empty;

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(fileStream))
            {
                data = reader.ReadToEnd();
            }
        }

        return data;
    }
}

public class ExampleUsage
{
    public static void Main()
    {
        string filePath = "example.txt";
        FileManager fileManager = new FileManager(filePath);

        fileManager.WriteToFile("Hello, World!");

        string content = fileManager.ReadFromFile();
        Console.WriteLine(content);
    }
}

