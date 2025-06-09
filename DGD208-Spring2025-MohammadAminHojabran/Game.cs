using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class Game
{
    private List<Pet> pets = new List<Pet>();
    private string creatorName = "MohammadAmin Hojabran";
    private string studentId = "2305045002";

    public void Run()
    {
        bool running = true;
        while (running)
        {
            var menu = new Menu("Main Menu", new List<string>
            {
                "Adopt a Pet",
                "View Pets",
                "Use Item on Pet",
                "Credits",
                "Exit"
            });

            switch (menu.Show())
            {
                case 0: AdoptPet(); break;
                case 1: ShowPets(); break;
                case 2: UseItem(); break;
                case 3: ShowCredits(); break;
                case 4: running = false; break;
            }
        }
    }

    private void AdoptPet()
    {
        var petMenu = new Menu("Choose a Pet Type", Enum.GetNames(typeof(PetType)).ToList());
        var petType = (PetType)petMenu.Show();

        Console.Write("Enter a name for your pet: ");
        string name = Console.ReadLine();

        var newPet = new Pet(name, petType);
        newPet.OnDeath += HandlePetDeath;

        pets.Add(newPet);
        Console.WriteLine($"{name} the {petType} has been adopted!");
    }

    private void ShowPets()
    {
        if (!pets.Any())
        {
            Console.WriteLine("No pets adopted.");
            return;
        }
        else
        { 
        foreach (var pet in pets)
        {
            Console.WriteLine(pet);
            pet.DisplayStats();
        }
    }

    Console.WriteLine("\nPress any key to return to the menu...");
     Console.ReadKey();
 }
    private void UseItem()
    {
        if (!pets.Any())
        {
            Console.WriteLine("No pets to use items on.");
            return;
        }

        var petMenu = new Menu("Choose a Pet", pets.Select(p => p.Name).ToList());
        var pet = pets[petMenu.Show()];

        var itemMenu = new Menu("Choose an Item", ItemDatabase.AllItems.Select(i => i.Name).ToList());
        var item = ItemDatabase.AllItems[itemMenu.Show()];

        _ = item.UseAsync(pet);
    }
    private void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("=== Credits ===\n");
        Console.WriteLine("Made by myself with help of a programmer friend in Iran, my friend Moaz in class, and ChatGPT.");
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    private void HandlePetDeath(Pet pet)
    {
        Console.WriteLine($" { pet.Name}has died... 😢");
        pets.Remove(pet);
    }
}
    