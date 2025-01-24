namespace odev9.Models
{
    public class SavunmaKartı : IKart
    {
        public string Ad => "Savunma Kartı";
        public int EnerjiMaliyeti => 2;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            oyuncu.Savunma += 5;  
            System.Console.WriteLine("Savunma Kartı seçildi ve oyuncunun savunması 5 arttı");
        }
    }
}
