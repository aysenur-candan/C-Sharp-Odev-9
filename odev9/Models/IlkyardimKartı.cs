namespace odev9.Models
{
    public class IlkyardimKartı : IKart
    {
        public string Ad => "İlkyardım Kartı";
        public int EnerjiMaliyeti => 5;

        public void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip)
        {
            oyuncu.Saglik += 30; 
            rakip.Saglik += 5;   
            System.Console.WriteLine("İlkyardım Kartı seçildi ve oyuncunun sağlığı 30 arttı rakip 5 sağlık kazandı");
        }
    }
}
