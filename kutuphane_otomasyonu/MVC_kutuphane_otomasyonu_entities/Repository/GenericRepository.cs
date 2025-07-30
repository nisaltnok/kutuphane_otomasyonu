using MVC_kutuphane_otomasyonu_entities.Interfaces;
using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Repository
{
    public class GenericRepository<TContext, TEntity> : IGenereicRepository<TContext, TEntity>
        where TContext : DbContext, new()
        where TEntity : class, new()
    {
        //burada tum metotlarin yapacaklari islemleri atadik,ayrintili incele 
        public void Delete(TContext context, Expression<Func<TEntity, bool>> filter)
        {
            var model = context.Set<TEntity>().FirstOrDefault(filter);   //Tentity olmasinin sebebi T tum varliklarin almasini saglar 
            context.Set<TEntity>().Remove(model);
        }

        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null, params string[] tbl) //listeleme metotu 
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var item in tbl)
            {
                query = query.Where(filter).Include(item);
            }
            return query.ToList();



        }

        public TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter, params string[] tbl)//tek kayit metodu 
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var item in tbl)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(filter);


        }

        public TEntity GetById(TContext context, int? id) //idye gore tek kayit arama metodu 
        {
            return context.Set<TEntity>().Find(id);
        }

        public void InsertUpdate(TContext context, TEntity entity)//ekleme ve guncelleme
        {
            context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void Save(TContext context)//veri tabanina kaydetme
        {
            context.SaveChanges();
        }
    }
}
