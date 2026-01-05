using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Model
{
    public class KerstlijstItem
    {

        public KerstlijstItem( string titel, decimal? prijs, string omschrijving, string beeldUrl, int? persoonId)
        {
            Titel = titel;
            Prijs = prijs;
            Omschrijving = omschrijving;
            BeeldUrl = beeldUrl;
            PersoonId = persoonId;
        }

        public KerstlijstItem()
        {
        }

        public int Id { get; set; }

        private string titel;
        public string Titel {
            get { return titel; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Titel is leeg.");
                }
                titel = value;
            }


        } 
        public decimal? Prijs { get; set; }


      //  private string omschrijving;
        public string Omschrijving { get; set; }


       // private string url;

       

        public string BeeldUrl { get; set; }

        public int? PersoonId { get; set; } 

    }
}
