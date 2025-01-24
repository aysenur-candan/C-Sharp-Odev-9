namespace odev9.Models
{
    public interface IKart
    {
        string Ad { get; }
        int EnerjiMaliyeti { get; }
        void EtkiUygula(Oyuncu oyuncu, Oyuncu rakip);
    }
}
