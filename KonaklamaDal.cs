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
    public class KonaklamaDal : IRepository<Konaklama>
    {
        public bool Ekle(Konaklama entity)
        {
            SqlCommand komut = new SqlCommand("insert into Konaklamalar(MusteriId, OdaId, ToplamFiyat, GirisTarihleri, CikisTarihi, AktifMi) values (@musteriId, @odaId, @toplamFiyat, @girisTarihleri, @cikisTarihi, @aktifMi)", tools.Baglanti);
            komut.Parameters.AddWithValue("@musteriId", entity.MusteriId);
            komut.Parameters.AddWithValue("@odaId", entity.OdaId);
            komut.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
            komut.Parameters.AddWithValue("@girisTarihleri", entity.GirisTarihleri);
            komut.Parameters.AddWithValue("@cikisTarihi", entity.CikisTarihi);
            komut.Parameters.AddWithValue("@aktifMi", entity.AktifMi);

            return tools.ExecuteNonQuery(komut);

        }

        public bool Guncelle(Konaklama entity)
        {
            SqlCommand komut = new SqlCommand("update Konaklamalar set MusteriId=@musteriId, OdaId=@odaId, ToplamFiyat=@toplamFiyat, GirisTarihleri=@girisTarihleri, CikisTarihi=@cikisTarihi, AktifMi=@aktifMi, GuncellemeTarihi=@guncellemeTarihi where Id=@id", tools.Baglanti);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@musteriId", entity.MusteriId);
            komut.Parameters.AddWithValue("@odaId", entity.OdaId);
            komut.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
            komut.Parameters.AddWithValue("@girisTarihleri", entity.GirisTarihleri);
            komut.Parameters.AddWithValue("@cikisTarihi", entity.CikisTarihi);
            komut.Parameters.AddWithValue("@aktifMi", entity.AktifMi);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);

            return tools.ExecuteNonQuery(komut);
        }

        public DataTable Listele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("KonaklamaListele", tools.Baglanti);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public bool Sil(int id)
        {
            SqlCommand command = new SqlCommand("delete from Konaklamalar where Id=@id", tools.Baglanti);
            command.Parameters.AddWithValue("@id", id);

            return tools.ExecuteNonQuery(command);
        }
    }
}
