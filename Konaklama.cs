using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PansiyonUygulamasi.EntityLayer.Entities
{
    public class Konaklama:Base
    {
        public int MusteriId { get; set; }
        public int OdaId { get; set; }
        public double ToplamFiyat { get; set; }
        public DateTime GirisTarihleri { get; set; }
        public DateTime CikisTarihi { get; set; }
        public bool AktifMi { get; set; }


    }
}
