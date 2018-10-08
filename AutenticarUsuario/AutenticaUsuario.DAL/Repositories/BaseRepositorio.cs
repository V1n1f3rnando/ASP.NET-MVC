using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutenticaUsuario.DAL.Context;

namespace AutenticaUsuario.DAL.Repositories
{
    public class BaseRepositorio <TEntity> where TEntity : class
    {
        //método para inserir..
        public virtual void Insert(TEntity obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
            }
        }
        //método para atualizar..
        public virtual void Update(TEntity obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        //método para excluir..
        public virtual void Delete(TEntity obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }
        //método para listar todos..
        public virtual List<TEntity> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<TEntity>().ToList();
            }
        }
        //método para retornar 1 registro..
        public virtual TEntity FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<TEntity>().Find(id);
            }
        }
    }
}
