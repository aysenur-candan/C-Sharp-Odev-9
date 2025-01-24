namespace odev9.Models
{
    public class SifaKartı : IKart
    {
        public string Ad => "Şifa Kartı";
        public int EnerjiMaliyeti => 4;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            oyuncu.Saglik += 15;  
            System.Console.WriteLine("Şifa Kartı seçildi ve oyuncunun canı 15 arttı");
        }
    }
}
