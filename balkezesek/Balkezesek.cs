namespace balkezesek
{
    internal class Balkezesek
    {
        public string Nev { get; private set; }
        public string Elso { get; private set; }
        public string Utolso { get; private set; }
        public int Suly { get; private set; }
        public int Magassag { get; private set; }
        public Balkezesek(string sor)
        {
            string[] adatok = sor.Split(';');
            Nev = adatok[0];
            Elso = adatok[1];
            Utolso = adatok[2];
            Suly = int.Parse(adatok[3]);
            Magassag = int.Parse(adatok[4]);
        }
        public void Evszam(string sor)
        {

        }
    }
}