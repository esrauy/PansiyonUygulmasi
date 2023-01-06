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
    public class MusteriDal : IRepository<Musteri>
    {
        public bool Ekle(Musteri entity)
        {
            SqlCommand komut = new SqlCommand("insert into Musteriler(Adi, Soyadi, KimlikNo, Cinsiyet, Telefon, Adres, Email) values (@adi, @soyadi, @kimlikNo, @cinsiyet, @telefon, @adres, @email)", tools.Baglanti);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@cinsiyet", entity.Cinsiyet);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
            komut.Parameters.AddWithValue("@email", entity.Email);

            return tools.ExecuteNonQuery(komut);

        }

        public bool Guncelle(Musteri entity)
        {
            SqlCommand komut = new SqlCommand("update Musteriler set Adi=@adi, Soyadi=@soyadi, KimlikNo=@kimlikNo, Cinsiyet=@cinsiyet, Telefon=@telefon, Adres=@adres, Email=@email, GuncellemeTarihi=@guncellemeTarihi where Id=@id", tools.Baglanti);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@cinsiyet", entity.Cinsiyet);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
            komut.Parameters.AddWithValue("@email", entity.Email);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);

            return tools.ExecuteNonQuery(komut);

        }

        public DataTable Listele()
        {
           SqlDataAdapter adapter = new SqlDataAdapter("MusteriListele", tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Sil(int id)
        {
            SqlCommand command = new SqlCommand("delete from Musteriler where Id=@id", tools.Baglanti);
            command.Parameters.AddWithValue("@id", id);

            return tools.ExecuteNonQuery(command);
        }
    }
}
