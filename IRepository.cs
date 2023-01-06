using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PansiyonUygulamasi.DataAccessLayer
{
    public interface IRepository<T>
    {
        bool Ekle(T entity);
        bool Sil(int id);
        DataTable Listele();
        bool Guncelle(T entity);

    }
}
