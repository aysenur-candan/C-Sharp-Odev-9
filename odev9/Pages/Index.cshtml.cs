using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odev9.Models;
using System;
using System.Collections.Generic;

namespace odev9.Pages
{
    public class IndexModel : PageModel
    {
        public Oyuncu Oyuncu { get; set; }
        public Oyuncu Rakip { get; set; }
        public List<IKart> RastgeleKartlar { get; set; }
        public string KartEtkisiMesaji { get; set; }
        public string SiraTuru { get; set; }
        public bool OyunDevamEdiyor { get; set; }
        public string OyunSonucu { get; set; }

        private List<IKart> kartlar;
        private bool oyuncuSirasi;

        public IndexModel()
        {
            Oyuncu = new Oyuncu { Ad = "Oyuncu 1", Saglik = 100 };
            Rakip = new Oyuncu { Ad = "Rakip", Saglik = 100 };
            kartlar = new List<IKart>
            {
                new SaldiriKart�(),
                new SavunmaKart�(),
                new SifaKart�(),
                new AltinVurusKart�(),
                new EnerjiIecegiKart�(),
                new IlkyardimKart�(),
            };
            oyuncuSirasi = true; 
        }

        public void OnGet()
        {
            if (Oyuncu.Saglik > 0 && Rakip.Saglik > 0)
            {
                RastgeleKartlar = RastgeleKartlariGetir();
                SiraTuru = oyuncuSirasi ? "Oyuncu S�ras�" : "Rakip S�ras�";
                OyunDevamEdiyor = true;
            }
            else
            {
                OyunDevamEdiyor = false;
                OyunSonucu = Oyuncu.Saglik <= 0 ? "Rakip Kazand�" : "Oyuncu Kazand�";
            }
        }

        public IActionResult OnPost()
        {
            var secilenKartAdi = Request.Form["kartSecim"];
            var secilenKart = kartlar.Find(k => k.Ad == secilenKartAdi);

            if (secilenKart != null)
            {
                
                if (oyuncuSirasi)
                {
                    secilenKart.EtkiUygula(Oyuncu, Rakip);
                    KartEtkisiMesaji = $"{secilenKart.Ad} se�ildi {secilenKart.Ad}'�n etkisi oyuncuya uyguland�";
                }
                else
                {
                    secilenKart.EtkiUygula(Rakip, Oyuncu);
                    KartEtkisiMesaji = $"{secilenKart.Ad} se�ildi {secilenKart.Ad}'�n etkisi rakibe uyguland�";
                }

                
                oyuncuSirasi = !oyuncuSirasi;

                
                if (Oyuncu.Saglik <= 0 || Rakip.Saglik <= 0)
                {
                    OyunDevamEdiyor = false;
                    OyunSonucu = Oyuncu.Saglik <= 0 ? "Rakip Kazand�" : "Oyuncu Kazand�";
                }
                else
                {
                    
                    OyunDevamEdiyor = true;
                }
            }

            
            RastgeleKartlar = RastgeleKartlariGetir();

            return Page();
        }

        private List<IKart> RastgeleKartlariGetir()
        {
            var rastgele = new Random();
            var secilenKartlar = new List<IKart>();

            for (int i = 0; i < 6; i++)
            {
                var kart = kartlar[rastgele.Next(kartlar.Count)];
                secilenKartlar.Add(kart);
            }

            return secilenKartlar;
        }
    }
}
