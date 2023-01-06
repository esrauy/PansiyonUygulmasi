using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PansiyonUygulamasi.DataAccessLayer
{
    public class KullaniciKontrolDal
    {
        public bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
            SqlCommand command = new SqlCommand("select * from Personeller where KullaniciAdi=@kullaniciAdi and Sifre=@sifre", tools.Baglanti);

            command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            command.Parameters.AddWithValue("@sifre", sifre);

            return tools.ExecuteReader(command);
        }
    }
}
