namespace odev9.Models
{
    public class EnerjiIecegiKartı : IKart
    {
        public string Ad => "Enerji İçeceği Kartı";
        public int EnerjiMaliyeti => 3;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            oyuncu.Enerji += 50;  
            oyuncu.Saglik -= 10;  
            System.Console.WriteLine("Enerji İçeceği Kartı seçildi ve enerjiniz %50 arttı ancak sağlığınız 10 azaldı");
        }
    }
}
