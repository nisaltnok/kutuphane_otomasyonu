using MVC_kutuphane_otomasyonu_entities.Model;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using MVC_kutuphane_otomasyonu_entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.DataAccessLayer
{
    public class DuyurularDAL : GenericRepository<KutuphaneContext, Duyurular>
    {
    }
}
