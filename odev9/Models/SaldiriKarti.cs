namespace odev9.Models
{
    public class SaldiriKartı : IKart
    {
        public string Ad => "Saldırı Kartı";
        public int EnerjiMaliyeti => 3;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            rakip.Saglik -= 10;  
            System.Console.WriteLine("Saldırı Kartı seçildi ve rakibin canı 10 azaldı");
        }
    }
}
