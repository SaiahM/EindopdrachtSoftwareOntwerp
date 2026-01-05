using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Model
{
    public class Persoon
    {
        public Persoon()
        {
           
        }
        public Persoon(string voornaam)
        {

            Voornaam = voornaam;
            
        }

        public Persoon(string voornaam, string achternaam)
        {
           
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        public int Id { get; set; }

        private string voornaam;
        public string Voornaam 
        { 
            get { return voornaam; } 
            
            set {  
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Voornaam is leeg.");
                }
                voornaam = value; }
        
                
        }


       
        public string Achternaam { get; set; }
        
        

    }
}
