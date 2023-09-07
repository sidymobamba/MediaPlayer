using System;
using System.Collections.Generic;

namespace MediaPlayer
{
    public class Lettore<T> where T : Media
    {
        enum Stato
        {
            Play,
            Pause,
            Stop
        }

        private List<T> playlist;
        private int index = -1; // indice a -1 non stiamo riproducendo nulla
        private Stato stato = Stato.Stop;

        public Lettore(T[] playlist)
        {
            this.playlist = new List<T>(playlist);
        }

        public void Pause()
        {
            stato = Stato.Pause;
            Console.WriteLine("Pausa");
        }

        public void Play()
        {
            stato = Stato.Play;
            Console.WriteLine("Playing");
        }

        public void Play(int index)
        {
            if (index < 0 || index >= playlist.Count)
                throw new ArgumentException("Invalid index");

            this.index = index;
            Play();
            playlist[index].Print();
        }

        public void Next()
        {
            index++;
            index %= playlist.Count;
            playlist[index].Print();
        }

        public void Previous()
        {
            index--;
            if (index < 0) index = playlist.Count - 1;
            playlist[index].Print();
        }

        public void Stop()
        {
            stato = Stato.Stop;
            index = -1;
            Console.WriteLine("Stop");
        }

        public void Add(T element)
        {
            playlist.Add(element);
        }

        public void PrintPlaylist()
        {
            Console.Write("--------------\n");
            for (int i = 0; i < playlist.Count; i++)
            {
                Console.Write(i + " - ");
                playlist[i].Print();
            }
            Console.Write("--------------\n");
        }
    }
}