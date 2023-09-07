using System;

namespace MediaPlayer 
{ 
    internal class Program
    {
        private static void Main(string[] args)
        {
            Lettore<Film> lettoreFilm = new(new Film[] { new Film("Barbie", "Greta Gerwig"), new Film("Oppenheimer", "Christopher Nolan") });
            Lettore<Canzone> lettoreCanzoni = new(new Canzone[] {
                new Canzone("Highway to hell", "ACDC"),
                new Canzone("Rock you like a hurricane", "Scorpions"),
                new Canzone("Jailhouse rock" , "Elvis Presley") });

            while(true)
            { 
                Console.Write("'M' per musica, 'V' per film, 'E' per uscire: ");
                char choice = Convert.ToChar(Console.ReadLine());

                switch(choice)
                {
                    case 'M':
                        HandlePlayback(lettoreCanzoni);
                        break;
                    case 'V':
                        HandlePlayback(lettoreFilm);
                        break;
                    case 'E':
                        return;
                    default:
                        Console.WriteLine("Scelta invalida");
                        break;
                }
            }
        }

        private static void HandlePlayback<T>(Lettore<T> lettore) where T : Media
        {
            lettore.PrintPlaylist();
            Console.Write("Media da riprodurre: ");
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                lettore.Play(index);
            } catch (FormatException e)
            {
                Console.WriteLine("Not a number");
                HandlePlayback(lettore);
            }
            
            while(true)
            { 
                Console.WriteLine("F per andare avanti");
                Console.WriteLine("B per andare indietro");
                Console.WriteLine("P per mettere in pausa");
                Console.WriteLine("S fermare la riproduzione");
                Console.Write("Scelta: ");
                char choice = Convert.ToChar(Console.ReadLine());

                switch(choice)
                {
                    case 'F':
                        lettore.Next();
                        break;
                    case 'B':
                        lettore.Previous();
                        break;
                    case 'P':
                        lettore.Pause();
                        break;
                    case 'S':
                        lettore.Stop();
                        return;
                    default:
                        Console.WriteLine("Scelta invalida");
                        break;
                }
            }
        }
    }
}