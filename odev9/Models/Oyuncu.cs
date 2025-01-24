namespace odev9.Models
{
    public class Oyuncu
    {
        public string Ad { get; set; }
        public int Saglik { get; set; } = 100; 
        public int Savunma { get; set; } = 0;  
        public int Enerji { get; set; } = 20;  
    }
}
