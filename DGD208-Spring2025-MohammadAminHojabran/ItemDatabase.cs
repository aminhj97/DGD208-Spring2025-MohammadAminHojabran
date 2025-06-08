using System.Collections.Generic;

public static class ItemDatabase
{
    public static List<Item> AllItems = new List<Item>
    {
        new Item("Kibble", ItemType.Food, PetStat.Hunger, 20, 2000),
        new Item("Toy", ItemType.Toy, PetStat.Fun, 25, 1500),
        new Item("Bird Seed", ItemType.Food, PetStat.Hunger, 15, 1800),
        new Item("Plush Bed", ItemType.Bed, PetStat.Sleep, 30, 3000)
    };
}