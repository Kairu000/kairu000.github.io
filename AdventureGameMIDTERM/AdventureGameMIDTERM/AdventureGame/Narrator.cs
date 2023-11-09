using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    internal class Narrator
    {
        public void Instructions(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            Write(message);
            ResetColor();
        }
    }
}
