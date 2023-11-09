using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }

        public int ArmorClass { get; protected set; }
        public int AttackBonus { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandGenerator { get; protected set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public List<string> inventoryList1 = new List<string>();

        public Character(string name, int health, ConsoleColor color, string textArt, int armorClass, int attackBonus)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            ArmorClass = armorClass;
            AttackBonus = attackBonus;   
            Color = color;
            TextArt = textArt;
            RandGenerator = new Random();  
        }

        public void DisplayInfo()
        {
            ForegroundColor = Color;
            WriteLine($"--{Name}--");
            WriteLine($"\n{TextArt}\n");
            WriteLine($"Health: {Health}");
            WriteLine("---");
            ResetColor();
        }
        public string GetName
        {
            get { return Name; }
        }


        public virtual void Fight(Character otherCharacter)
        {

            WriteLine("Enemy is fighting!");
  
        }

        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            if (Health < 0) 
            {
                Health = 0;
            }
        }
        public void TakeMaxHealthDamage(int damageAmount)
        {
            MaxHealth -= damageAmount;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        public void TakeHeal(int healAmount)
        {
            Health += healAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public void Debuff()
        {
                TakeDamage(Health / 2);
        }
        public void AcDebuff()
        {
            if (inventoryList1.Contains("ACDeBuff"))
            {
                ArmorClass -= 2;
            }
        }
        public void ATKBuff()
        {
            if (inventoryList1.Contains("ATKBuff"))
            {
                AttackBonus = AttackBonus + 5;
            }
        }

        public void DEFBuff()
        {
            if (inventoryList1.Contains("DEFBuff"))
            {
                ArmorClass = ArmorClass + 3;
            }
        }

        public void DisplayHealthBar()
        {
            WriteLine($"{Name}'s Health:");
            Write("[");
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i <Health; i++)
            {
                Write(" ");
            }

            BackgroundColor = ConsoleColor.Black;
            for (int i = Health; i < MaxHealth; i++)
            {
                Write(" ");
            }
            ResetColor();
            WriteLine($"] ({Health}/{MaxHealth})");

        }
    }
}
