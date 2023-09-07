using System;

namespace MediaPlayer
{
    public class Film : Media
    {
        private string regista;

        public Film(string titolo, string regista) : base(titolo)
        {
            this.regista = regista;
        }

        public override void Print()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(titolo + " by " + regista);
            Console.ResetColor();
        }
    }
}