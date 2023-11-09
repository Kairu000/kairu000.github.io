using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    public class Game
    {

        private string GameTitleArt = @"╔═╗┌┬┐┬─┐┌─┐┌┬┐┌─┐┌─┐
╚═╗ │ ├┬┘├─┤ │ │ │└─┐
╚═╝ ┴ ┴└─┴ ┴ ┴ └─┘└─┘";
        private string GameTitle = "Stratos";
        private Player CurrentPlayer;
        NPC kyle = new NPC();
        Narrator Angelo = new Narrator();
        private Character CurrentEnemy;
        private List<Character> Enemies;
        int userInput;
        int goldCurrency;
        private string playerName;
        private Story myStory1;


        public void StartUp()
        {
            goldCurrency = 0;
            Title = GameTitle;
            RunMainMenu();

        }
        private void Intro()
        {
            myStory1 = new Story();
            Clear();
            Write("what is your name: ");
            playerName = ReadLine();
            CurrentPlayer = new Player(playerName,40, ConsoleColor.Green, 15, 0,0,0,3,0);
            WriteLine($"Welcome to {GameTitle},{CurrentPlayer.Name}");
            ReadKey();
            wakeup();

        }
        private void wakeup()
        {

            Clear();
            myStory1 = new Story();
            Write(myStory1.contentArray[0]);
            ReadKey();
            kyle.Dialog($"Captain "+this.CurrentPlayer.GetName+ myStory1.contentArray[1]);
            ReadKey();
            Write(myStory1.contentArray[2]);
            ReadKey();
            Choice1();
        }
        private void RunMainMenu()
        {

            string prompt = $"{GameTitleArt}";
            string[] options = { "play", "about", "exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {

                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;


            }
        }
        private void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("well... hello there");
            WriteLine("press any key to return to main menu");
            ReadKey(true);
            RunMainMenu();
        }
        private void RunFirstChoice()
        {
            Intro();
        }
        private void Choice1()
        {

            Clear();
            spawnEnemies();
            //capture user input, convert to int16, save value in var
            Write(myStory1.contentArray[3]);
            Angelo.Instructions(myStory1.contentArray[4]);
            userInput = Convert.ToInt16(ReadLine());

            //perform condititonal branching with if, else if, else
            if (userInput == 1)
            {
                //clear the console
                Clear();

                //print contents of outcome
                WriteLine(myStory1.contentArray[5]);
                CurrentPlayer.inventoryList1.Add("ATKBuff");
                ReadKey();
                FirstCombat();
            }

            else if (userInput == 2)
            {

                Clear();
                WriteLine(myStory1.contentArray[6]);
                CurrentPlayer.inventoryList1.Add("DEFBuff");
                ReadKey();


                

                FirstCombat();
            }
            else if (userInput == 3)
            {

                Clear();


                WriteLine(myStory1.contentArray[7]);

                Enemies[0].Debuff();

                ReadKey();

                FirstCombat();
               
            }
            else
            {
                Clear();
                WriteLine("that's not a valid response");
                


                ReadKey();
                Choice1();

            }

        }
        private void spawnEnemies()
        {
            Wyvern WyvernWave = new Wyvern("WyvernWave", 15, ConsoleColor.Red, 10, 0);
            Wyvern WyvernBoss = new Wyvern("WyvernBoss", 30, ConsoleColor.Magenta, 10, 0);
            Leviathan WhaleLeviathan = new Leviathan("Whale Leviathan", 30, ConsoleColor.DarkMagenta, 14, 2);


            Enemies = new List<Character>() { WyvernWave, WyvernBoss, WhaleLeviathan };
        }

        // The structure of the BattleCurrentEnemy, and the methods within it, are based off micheal Hadley's RPG combat tutorial
        private void BattleCurrentEnemy()
        {
            

            while (CurrentPlayer.IsAlive || CurrentEnemy.IsAlive)
            {
                Clear();
                CurrentPlayer.DisplayInfo();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayInfo();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentPlayer.Fight(CurrentEnemy);

                ReadKey();
                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }
                Clear();
                CurrentPlayer.DisplayInfo();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayInfo();
                CurrentEnemy.DisplayHealthBar();

                CurrentEnemy.Fight(CurrentPlayer);
                CurrentPlayer.inventoryList1.Remove("DEFBuff");

                ReadKey();
                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }
            }

        }
        private void FirstCombat()
        {
            Clear();
           

            for (int i = 0; i < 2; i += 1)
            {
                CurrentEnemy = Enemies[i];
                BattleCurrentEnemy();

                if (CurrentPlayer.IsDead)
                {
                    Clear();
                    WriteLine("You're Dead, newb\n");
                    ReadKey();
                    WriteLine("\nTry Again");
                    ReadKey();
                    RunMainMenu();

                }
                if (Enemies[0].IsDead)
                {
                    Clear();
                    WriteLine("The Wave's been cleared, all that's left is the biggest wyvern!");
                    ReadKey();
                }

                if (Enemies[1].IsDead)
                {
                    Clear();
                    WriteLine($"You've successfully defended the border from the wave!");
                    ReadKey();
                    FirstBattleConclustion();
                }


            }
        }
        private void FirstBattleConclustion()
        {
            CurrentPlayer.inventoryList1.Remove("ATKBuff");
            CurrentPlayer.inventoryList1.Remove("DEFBuff");
            kyle.Dialog($"Captain {CurrentPlayer.Name} " + myStory1.contentArray[8]);
            goldCurrency += 15;
            ReadKey();
            Shopping();
            ReadKey();
            EmergencyCombat();

        }
        public void NotEnoughGold()
        {
            kyle.Dialog("Sorry sir, you don't seem to have enough Gold");
            ReadLine();
            Shopping();
        }
        private void Shopping()
        {
            Clear();
            WriteLine($"Gold : {goldCurrency}\n");
            kyle.Dialog("Hello, sir. How can the Shipyard help you?\n");
            WriteLine(myStory1.contentArray[9]);

            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                if (goldCurrency > 4)
                {
                    goldCurrency -= 5;
                    WriteLine("You've sent your engineers for more training...");
                    CurrentPlayer.inventoryList1.Add("Heal");
                    ReadLine();
                    WriteLine("They come back more prepared");
                    Shopping();
                }
                else
                {
                    NotEnoughGold();
                }
            }
            else if(keyInfo.Key == ConsoleKey.D2)
            {

                if (goldCurrency > 4)
                {
                    goldCurrency -= 5; WriteLine("You've sent your helmsman for more training...");
                    CurrentPlayer.inventoryList1.Add("Helmsman");
                    ReadLine();
                    WriteLine("They come back more prepared");
                    Shopping();
                }
                else
                {
                    NotEnoughGold();
                }
            }
            else if (keyInfo.Key == ConsoleKey.D3)
            {
                if (goldCurrency > 9)
                {
                    goldCurrency -= 10; WriteLine("You've Upgraded your ship's Aether Reactor... It's faster than before!");
                    CurrentPlayer.AaetherReactorUpgrade();
                    ReadLine();
                    WriteLine("They come back more prepared");
                    Shopping();
                }
                else
                {
                    NotEnoughGold();
                }

            }
            else if (keyInfo.Key == ConsoleKey.D4)
            {
                if (goldCurrency > 4)
                {
                    goldCurrency -= 5;
                    WriteLine("Your cannon has gotten a slight upgrade");
                    CurrentPlayer.CannonATKBonus += 3;
                    ReadLine();
                    Shopping();
                }
                else
                {
                    NotEnoughGold();
                }
            }
            else if (keyInfo.Key == ConsoleKey.D5)
            {
                if (goldCurrency > 4)
                {
                    goldCurrency -= 5;
                    WriteLine("Your ballista has gotten a slight upgrade");
                    CurrentPlayer.BallistaATKBonus += 1;
                    ReadLine();
                    Shopping();
                }
                else
                {
                    NotEnoughGold();
                }
            }
            else if (keyInfo.Key == ConsoleKey.D6)
            {
                kyle.Dialog(myStory1.contentArray[10]);
                ReadLine();
                CurrentPlayer.HealthReset();
                EmergencyCombat();
            }
            else 
            {
                Shopping();
            }
           
        }
        private void EmergencyCombat()
        {
            Clear();
            for (int i = 2; i < 3; i += 1)
            {
                CurrentEnemy = Enemies[i];
                BattleCurrentEnemy();

                if (CurrentPlayer.IsDead)
                {
                    Clear();
                    WriteLine("You're Dead, newb\n");
                    ReadKey();
                    WriteLine("\nTry Again");
                    ReadKey();
                    RunMainMenu();

                }
                if (Enemies[1].IsDead)
                {
                    Clear();
                    WriteLine("You've successfully defended against the wave of monsters");
                    ReadKey();
                    EmergencyCombatConclusion();
                }

            }
            Clear();
            WriteLine("combat is over");

            WriteLine();
            ReadKey();
        }

        private void EmergencyCombatConclusion()
        {

            WriteLine(myStory1.contentArray[11]);
            ReadLine();
            kyle.Dialog($"Captain {CurrentPlayer.Name} " + myStory1.contentArray[12]);
            ReadLine();
            CreditScreen();

        }

        private void CreditScreen()
        {
            kyle.Dialog("Thank You for playing Stratos!\nCreator: Kyle Angelo Lapuz");
            WriteLine("Play again if you want to try a different choice for the first encounter, try different upgrades, or face the enemies in a different way.");
            ReadLine();
        }

    }

}
