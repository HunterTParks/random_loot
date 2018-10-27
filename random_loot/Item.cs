using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_loot
{
    class Item
    {
        public Item(int id, string name, string description, string value, string rarity, string weight, string category, string properties, string requirements, string author, string rarityNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Rarity = rarity;
            Weight = weight;
            Category = category;
            Properties = properties;
            Requirements = requirements;
            Author = author;
            RarityNumber = rarityNumber;
        }

        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Value { get; set; }
        string Rarity { get; set; }
        string Weight { get; set; }
        string Category { get; set; }
        string Properties { get; set; }
        string Requirements { get; set; }
        string Author { get; set; }
        string RarityNumber { get; set; }
    }
}
