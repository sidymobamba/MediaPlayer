using System;

namespace MediaPlayer
{
    public class Canzone : Media
    {
        private string autore;

        public Canzone(string titolo, string autore) : base(titolo)
        {
            this.autore = autore;
        }

        public override void Print()
        {   
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(titolo + " by " + autore);
            Console.ResetColor();
        }
    }
}