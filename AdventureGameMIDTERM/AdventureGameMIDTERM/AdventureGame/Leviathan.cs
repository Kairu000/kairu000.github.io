using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    class Leviathan : Character
    {
        public Leviathan(string name, int health, ConsoleColor color, int armorClass, int attackBonus)
            : base(name, health, color, ArtAssets.Leviathan, armorClass, attackBonus)
        {

        }

        public override void Fight(Character otherCharacter)
        {
            //options:
            //represent chance to hit as a d20 random number
            //random number must pass other character's Armor Class
            ForegroundColor = Color;
            WriteLine($"Ant {Name} is fighting {otherCharacter.Name}!");

            int randPercent = RandGenerator.Next(0,99);
            WriteLine($"{Name} takes focus at {otherCharacter.Name} and...");
            if (randPercent < 32)
            {
                if (randPercent + AttackBonus >= otherCharacter.ArmorClass)
                {
                    Write(" strikes, dealing 7 damage");
                    otherCharacter.TakeDamage(7);
                }
                else
                {
                    Write(" Misses");
                }
            }
            else if (randPercent > 32 && randPercent <66)
            {
                if (randPercent + AttackBonus >= otherCharacter.ArmorClass)
                {
                    Write(" Knocks off several soldiers, dealing 2 damage, and reducing max health by 2");
                    otherCharacter.TakeDamage(4);
                    otherCharacter.TakeMaxHealthDamage(2);
                }
                else
                {
                    Write(" It misses");
                }
            }
            else
            {
               
            }
            ResetColor();
        }
    }
}
