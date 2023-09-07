namespace MediaPlayer
{
    public abstract class Media
    {
        protected string titolo;

        protected Media(string titolo)
        {
            this.titolo = titolo;
        }

        public abstract void Print();
    }
}