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
                new SaldiriKartý(),
                new SavunmaKartý(),
                new SifaKartý(),
                new AltinVurusKartý(),
                new EnerjiIecegiKartý(),
                new IlkyardimKartý(),
            };
            oyuncuSirasi = true; 
        }

        public void OnGet()
        {
            if (Oyuncu.Saglik > 0 && Rakip.Saglik > 0)
            {
                RastgeleKartlar = RastgeleKartlariGetir();
                SiraTuru = oyuncuSirasi ? "Oyuncu Sýrasý" : "Rakip Sýrasý";
                OyunDevamEdiyor = true;
            }
            else
            {
                OyunDevamEdiyor = false;
                OyunSonucu = Oyuncu.Saglik <= 0 ? "Rakip Kazandý" : "Oyuncu Kazandý";
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
                    KartEtkisiMesaji = $"{secilenKart.Ad} seçildi {secilenKart.Ad}'ýn etkisi oyuncuya uygulandý";
                }
                else
                {
                    secilenKart.EtkiUygula(Rakip, Oyuncu);
                    KartEtkisiMesaji = $"{secilenKart.Ad} seçildi {secilenKart.Ad}'ýn etkisi rakibe uygulandý";
                }

                
                oyuncuSirasi = !oyuncuSirasi;

                
                if (Oyuncu.Saglik <= 0 || Rakip.Saglik <= 0)
                {
                    OyunDevamEdiyor = false;
                    OyunSonucu = Oyuncu.Saglik <= 0 ? "Rakip Kazandý" : "Oyuncu Kazandý";
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
