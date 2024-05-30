namespace CA240530E
{
    internal class Pontszerzo
    {
        public int Helyezes { get; set; }
        public int Sportolok { get; set; }
        public string Sportag { get; set; }
        public string Versenyszam { get; set; }
        public int OlimpiaiPont => Helyezes == 1 ? 7 : 7 - Helyezes;

        public override string ToString() => 
            $"Helyezes: {Helyezes}\n" +
            $"Sportag: {Sportag}\n" +
            $"Versenyszam: {Versenyszam}\n" +
            $"Sportolok szama: {Sportolok}";

        public Pontszerzo(string sor)
        {
            string[] v = sor.Split(' ');
            Helyezes = int.Parse(v[0]);
            Sportolok = int.Parse(v[1]);
            Sportag = v[2];
            Versenyszam = v[3];
        }
    }
}
