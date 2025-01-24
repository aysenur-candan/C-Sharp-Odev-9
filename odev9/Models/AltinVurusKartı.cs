namespace odev9.Models
{
    public class AltinVurusKartı : IKart
    {
        public string Ad => "Altın Vuruş Kartı";
        public int EnerjiMaliyeti => 6;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            rakip.Saglik -= 50; 
            oyuncu.Enerji = 0;  
            System.Console.WriteLine("Altın Vuruş Kartı seçildi ve rakibin sağlığı 50 azaldı ancak oyuncunun enerjisi sıfırlandı");
        }
    }
}
