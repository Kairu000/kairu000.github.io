using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventureGame
{
    internal class NPC
    {
        public void Dialog(string message)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write(message);
            ResetColor();
        }


    }
}
