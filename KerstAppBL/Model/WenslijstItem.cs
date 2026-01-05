using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Model
{
    public class WenslijstItem
    {

        public WenslijstItem( string titel, string website, string omschrijving, string beeldUrl)
        {
            
            Titel = titel;
            Website = website;
            Omschrijving = omschrijving;
            BeeldUrl = beeldUrl;
        }

        public WenslijstItem()
        {
        }

        public int Id { get; set; }

        private string titel;
        public string Titel
        {
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


        private string web;
        public string Website
        {
            get { return web; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Website is leeg.");
                }
                web = value;
            }
        }

        private string omschrijving;
        public string Omschrijving { get; set; }







        public string BeeldUrl { get; set; }
    
    }
}
