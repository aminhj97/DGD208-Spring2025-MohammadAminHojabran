using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PetSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Start();

        }
    }
    class GameManager
    {
        private List<Pet> adoptedPets = new List<Pet>();
        private bool isRunning = true;
        private string creatorName = "Mohammad Amin Hojabran";
        private string studentNumber = "2305045002";
        private Timer statTimer;

        public GameManager()
        {

            
        }

        public void Start()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("    Welcome to Pet Simulator");
            Console.WriteLine("====================================");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            while (isRunning)
            {
                ShowMainMenu();
            }
        }
        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Adopt a Pet");
            Console.WriteLine("2. View Pets");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice) 
            {
                case "1":
                    Console.WriteLine("Enter pet name: ");
                    string name = Console.ReadLine();
                    adoptedPets.Add(new Pet(name));
                    Console.WriteLine($"{name} has been adopted");
                    break;
                case "2":
                    Console.WriteLine("Adopted Pets");
                    foreach (var pet in adoptedPets)
                        Console.WriteLine("- " + pet.Name);
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. ");
                    break;
        }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
    }
        class Pet
        {
            public string Name { get; set; }

            public Pet(string name)
            {
                Name = name;
            }
    }
 }

