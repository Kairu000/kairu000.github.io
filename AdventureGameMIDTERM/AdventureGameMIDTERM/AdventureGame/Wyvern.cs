using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace AdventureGame
{
    class Wyvern : Character
    {

        public Wyvern(string name, int health, ConsoleColor color, int armorClass, int attackBonus)
            : base(name, health, color, ArtAssets.Wyvern, armorClass, attackBonus)
        {
        }

        public override void Fight(Character otherCharacter)
        {
            //options:
            //represent chance to hit as a d20 random number
            //random number must pass other character's Armor Class
            ForegroundColor = Color;
            WriteLine($"Ant {Name} is fighting {otherCharacter.Name}!");
            
            int randPercent = RandGenerator.Next(2, 21);
            WriteLine($"{Name} bites at {otherCharacter.Name} and");
            if (randPercent + AttackBonus >= otherCharacter.ArmorClass)
            {
                WriteLine("Hits for 4 damage");
                otherCharacter.TakeDamage(4);
            }
            else
            {
                WriteLine("Misses");
            }
            ResetColor();

        }


    }
}
