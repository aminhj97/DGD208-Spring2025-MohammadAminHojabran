using System;
using System.Threading.Tasks;

public class Pet
{
    public string Name { get; }
    public PetType Type { get; }

    public int Hunger { get; private set; } = 50;
    public int Sleep { get; private set; } = 50;
    public int Fun { get; private set; } = 50;

    public bool IsAlive => Hunger > 0 && Sleep > 0 && Fun > 0;

    public event Action<Pet> OnDeath;

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
        StartStatDecay();
    }

    private async void StartStatDecay()
    {
        while (IsAlive)
        {
            await Task.Delay(3000);
            Hunger--;
            Sleep--;
            Fun--;

            if (!IsAlive)
                OnDeath?.Invoke(this);
        }
    }

    public void IncreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger:
                Hunger = Math.Min(100, Hunger + amount);
                break;
            case PetStat.Sleep:
                Sleep = Math.Min(100, Sleep + amount);
                break;
            case PetStat.Fun:
                Fun = Math.Min(100, Fun + amount);
                break;
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{Name} ({Type}) - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}");
    }
}