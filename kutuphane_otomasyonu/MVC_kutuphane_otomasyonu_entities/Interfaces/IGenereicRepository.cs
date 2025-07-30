using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Interfaces
{
    // nu kisimda interface olusturuldu ,ayrintili ogren
    //burada olusturulan methodlar ,reposirty kisminda implemente edilmedigi zaman hata veriyor bunun nedeni nedir
    public interface IGenereicRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null,params string[] tbl); //filtre null ise tum listeyi getir. degilse Filtrele 
        TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, params string[] tbl);//tek kayit getirir.

        TEntity GetById(TContext context, int? id);

        void InsertUpdate(TContext context, TEntity entity);

        void Delete(TContext context, Expression<Func<TEntity, bool>> filter);

        void Save(TContext context);


    }
}
