using System;
using System.Threading.Tasks;

public class Item
{
    public string Name { get; }
    public ItemType Type { get; }
    public PetStat AffectedStat { get; }
    public int EffectAmount { get; }
    public int UseDurationMs { get; }

    public Item(string name, ItemType type, PetStat affectedStat, int effectAmount, int useDurationMs)
    {
        Name = name;
        Type = type;
        AffectedStat = affectedStat;
        EffectAmount = effectAmount;
        UseDurationMs = useDurationMs;
    }

    public async Task UseAsync(Pet pet)
    {
        Console.WriteLine($"Using {Name} on {pet.Name}...");
        await Task.Delay(UseDurationMs);
        pet.IncreaseStat(AffectedStat, EffectAmount);
        Console.WriteLine($"{pet.Name}'s {AffectedStat} increased by {EffectAmount}!");
    }
}