using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    class Player : Character
    {
        public int CannonATKBonus;
        public int CannonDMGBonus;
        public int BallistaATKBonus;
        public int BallistaDMGBonus;



        public Player(string playerName, int health, ConsoleColor color, int armorClass, int attackBonus, int cannonATKBonus, int cannonDMGBonus, int ballistaATKBonus, int ballistaDMGBonus)
            : base(playerName, health, color, ArtAssets.Captain, armorClass, attackBonus)
        {
            Name = playerName;
            CannonATKBonus = cannonATKBonus;
            CannonDMGBonus = cannonDMGBonus;
            BallistaATKBonus = ballistaATKBonus;
            BallistaDMGBonus = ballistaDMGBonus;

        }
        public void HealthReset()
        {
            Health = 40;
        }
        private void CannonBarriagAt(Character otherCharacter)
        {
            Write("Cannons are fired by your command");
            int randPercent = RandGenerator.Next(0, 19);
            if(randPercent + AttackBonus + CannonATKBonus >= otherCharacter.ArmorClass)
            {
                WriteLine("The cannonballs fire directly at the target");
                otherCharacter.TakeDamage(5+CannonDMGBonus);
            }
            else
            {
                WriteLine("The cannonballs miss");
            }
        }
        private void BallistaBarriagAt(Character otherCharacter)
        {
            Write("Ballistas are fired by your command");
            int randPercent = RandGenerator.Next(0, 19);
            if (randPercent + AttackBonus + BallistaATKBonus >= otherCharacter.ArmorClass)
            {
                WriteLine("The speeding ballista bolts hit the target");
                otherCharacter.TakeDamage(2+BallistaDMGBonus);
            }
            else 
            {
                WriteLine("The speeding ballista bolts miss");
            }
        }
        private void RepairShip()
        {
            WriteLine("The ship was partially repaired by your command");
            int randPercent = RandGenerator.Next(2, 10);
            TakeHeal(randPercent);
        }
        private void EvasiveManuevers()
        {
            inventoryList1.Add("DEFBuff");
            DEFBuff();
            WriteLine("You command your helmsman to take evasive amnuevers for this turn");
        }
        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            WriteLine($"You are facing {otherCharacter.Name} what would you like to do?\n1) Command: Cannonball Barrage\n2) Command: Ballista Barrage");
            if(inventoryList1.Contains("Heal"))
            {
                WriteLine("3) command: Tell engineers to repair the ship\n");
            }
            if (inventoryList1.Contains("Helmsman"))
            {
                WriteLine("4) command: Tell the Helmsman to take Evasive manuevers");

            }
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if(keyInfo.Key == ConsoleKey.D1)
            {
                CannonBarriagAt(otherCharacter);
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                BallistaBarriagAt(otherCharacter);
            }
            else if(keyInfo.Key == ConsoleKey.D3)
            {
                if (inventoryList1.Contains("Heal"))
                {
                    RepairShip();
                }
                else
                {
                    WriteLine("That's not a valid move. Try again.");
                    Fight(otherCharacter);
                    return;
                }
            }
            else if(keyInfo.Key == ConsoleKey.D4)
            {
                EvasiveManuevers();

            }
            else
            {
                WriteLine("That's not a valid move. Try again.");
                Fight(otherCharacter);
                return;
            }
            ResetColor();
            
        }
        public void AaetherReactorUpgrade()
        {
            ArmorClass += 2;
        }

    }
}

