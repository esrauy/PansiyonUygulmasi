using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PansiyonUygulamasi.EntityLayer.Abstract
{
    public interface IKisi
    {
        string KimlikNo { get; set; }
        string Adi { get; set; }
        string Soyadi { get; set; }
        string Telefon { get; set; }
        string Adres { get; set; }

    }
}
