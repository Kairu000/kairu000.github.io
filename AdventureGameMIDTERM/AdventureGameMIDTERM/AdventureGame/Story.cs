using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Story
    {
        Game storyGame1 =  new Game();

        //create a content array and populate with content
        public string[] contentArray = new string[13]
            {
                "You wait by the flying island's edge, atop your flying airship with your crew, awaiting a report on when the next wave of enemies will be...\nThen you hear vibrations coming from the sending stone and its runic sigil glows a bright yellow -  \n",     //index 0
               " there's a wave of wyverns incoming. Take their flank while our main forces hold them off.\n",     //index 1
                "The sending stone's glow quickly diminishes as the messege is finished. Time to move",     //index 2
                "Now... where should I go...\n1) above the wave \n2)below the wave \n3)to the wave's side\n",     //index 3
                "Please type a number and then press enter to choose\n",     //index 4
                "We'll be able to rain down artillery easier if we move above the wave",     //index 5
                "under the cover of the clouds, the monsters will have a hard time hitting us",     //index 6
                "we'll be able to split the wave easier if we attract some of the wave from the side",     //index 7
                "come back to the shipyard and repair your ship and add any necessary upgrades. I've added more to your budget for your good results during the wave.",     //index 8
                "1)train engineers(5 gold) \n2)train helmsman(5 gold) \n3)Upgrade Aether Reactor(10 gold) \n4)upgrade cannons(5 gold) \n5)upgrade ballistas(5 gold) \n6)Exit" ,     //index 9
                "You hear the sirens ring, asking for your crew to board and go into the fron lines once again",      //index 10
                "After the battle, the remains of the huge leviathan was teathered on to the ship. You get close to the edge of the island, and horns sing of your return.", //index 11
                "congratulations on the successful battle. Glad to have you back." //index 12
            };




    }
}