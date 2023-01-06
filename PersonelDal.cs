using PansiyonUygulamasi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PansiyonUygulamasi.DataAccessLayer
{
    public class PersonelDal : IRepository<Personel>
    {
        public bool Ekle(Personel entity)
        {
            //SqlConnection connection = new SqlConnection("Server=DESK2\\NA;Database=PansiyonUygulamasi;Integrated Security=true;");
            SqlCommand komut = new SqlCommand("insert into Personeller(Adi, Soyadi, KimlikNo, KullaniciAdi, Sifre, Telefon, Adres) values (@adi, @soyadi, @kimlikNo, @kullaniciAdi, @sifre, @telefon, @adres)", tools.Baglanti);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@kullaniciAdi", entity.KullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", entity.Sifre);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
        
            return tools.ExecuteNonQuery(komut);
        }

        public bool Guncelle(Personel entity)
        {
            //SqlConnection connection = new SqlConnection("Server=DESK2\\NA;Database=PansiyonUygulamasi;Integrated Security=true;");
            SqlCommand komut = new SqlCommand("update Personeller set Adi=@adi, Soyadi=@soyadi, KimlikNo=@kimlikNo, KullaniciAdi=@kullaniciAdi, Sifre=@sifre, Telefon=@telefon, Adres=@adres, GuncellemeTarihi=@guncellemeTarihi where Id=@id", tools.Baglanti);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@kullaniciAdi", entity.KullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", entity.Sifre);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);

            return tools.ExecuteNonQuery(komut);

        }

        public DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("PersonelListele", tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable); //sqlDataAdapter içindeki fill() metoduna verilen DataTable nesnesi içerisine veritabanından gelen datalar yerleştiriliyor.

            return dataTable;
        }

        public bool Sil(int id)
        {
            SqlCommand command = new SqlCommand("delete from Personeller where Id=@id", tools.Baglanti);
            command.Parameters.AddWithValue("@id", id);

            return tools.ExecuteNonQuery(command);

        }
    }
}
