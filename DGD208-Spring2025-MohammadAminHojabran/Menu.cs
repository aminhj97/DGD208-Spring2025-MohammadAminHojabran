using System;
using System.Collections.Generic;

public class Menu
{
    public string Title { get; }
    private List<string> options;

    public Menu(string title, List<string> options)
    {
        Title = title;
        this.options = options;
    }

    public int Show()
    {
        Console.Clear();

        // Game Title
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== INTERACTIVE PET SIMULATOR ===");
        Console.ResetColor();

        // Developer Info
        Console.WriteLine("Created by: [MohammadAmin Hojabran]");
        Console.WriteLine("Student ID: [2305045002]");
        Console.WriteLine();

        // Menu Title and Options
        Console.WriteLine($"-- {Title} --");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= options.Count)
            return choice - 1;

        Console.WriteLine("Invalid choice. Try again.");
        return Show();
    }
}
