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
    public class OdaDal : IRepository<Oda>
    {
        public bool Ekle(Oda entity)
        {
            SqlCommand komut = new SqlCommand("insert into Odalar(OdaNo, OdaFiyati, MusaitMi) values (@odaNo, @odaFiyati, @musaitMi)", tools.Baglanti);
            komut.Parameters.AddWithValue("@odaNo", entity.OdaNo);
            komut.Parameters.AddWithValue("@odaFiyati", entity.OdaFiyati);
            komut.Parameters.AddWithValue("@musaitMi", entity.MusaitMi);

            return tools.ExecuteNonQuery(komut);

        }

        public bool Guncelle(Oda entity)
        {
            SqlCommand komut = new SqlCommand("update Odalar set OdaNo=@odaNo, OdaFiyati=@odaFiyati, MusaitMi=@musaitMi where Id=@id", tools.Baglanti);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@odaNo", entity.OdaNo);
            komut.Parameters.AddWithValue("@odaFiyati", entity.OdaFiyati);
            komut.Parameters.AddWithValue("@musaitMi", entity.MusaitMi);
          //  komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);

            return tools.ExecuteNonQuery(komut);
        }

        public bool DurumGuncelle(Oda entity)
        {
            SqlCommand komut = new SqlCommand("Update Odalar set MusaitMi=@musaitMi where Id=@id", tools.Baglanti);
            komut.Parameters.AddWithValue("@musaitMi", entity.MusaitMi);
            komut.Parameters.AddWithValue("@id", entity.Id);

            return tools.ExecuteNonQuery(komut);
        }

        public DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("OdaListele", tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;

        }

        public List<Oda> OdaListele()
        {
            List<Oda> odalarList = new List<Oda>();
            SqlCommand command = new SqlCommand("select * from Odalar", tools.Baglanti);
            try
            {
                if(tools.Baglanti.State == ConnectionState.Closed)
                {
                    tools.Baglanti.Open();
                }
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Oda oda = new Oda();
                    oda.Id = Convert.ToInt32(reader["Id"]);
                    oda.OdaNo = reader["OdaNo"].ToString();
                    oda.OdaFiyati = Convert.ToDouble(reader["OdaFiyati"]);
                    oda.MusaitMi = Convert.ToBoolean(reader["MusaitMi"]);

                    odalarList.Add(oda);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if(tools.Baglanti.State == ConnectionState.Open)
                {
                    tools.Baglanti.Close();
                }
            }

            return odalarList;
        }

        public bool Sil(int id)
        {
            SqlCommand command = new SqlCommand("delete from Odalar where Id=@id", tools.Baglanti);
            command.Parameters.AddWithValue("@id", id);

            return tools.ExecuteNonQuery(command);
        }
    }
}
