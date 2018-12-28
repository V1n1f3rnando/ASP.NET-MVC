using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutenticaUsuario.Repositorio.Context;
using System.Data.Entity;

namespace AutenticaUsuario.Repositorio.Repositories
{
    public class BaseRepositorio<TEntity> where TEntity : class
    {
        //Método de inserção
        public virtual void Insert(TEntity obj)
        {
            using(DataContex d = new DataContex())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        //Método para atualizar
        public virtual void Update(TEntity obj)
        {
            using (DataContex d = new DataContex())
            {
                d.Entry(obj).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        //Método de Exclusão
        public virtual void Delete(TEntity obj)
        {
            using(DataContex d = new DataContex())
            {
                d.Entry(obj).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        //Método para achar por id
        public virtual TEntity FindById(int id)
        {
            using(DataContex d = new DataContex())
            {
                return d.Set<TEntity>().Find(id);
            }
        }
    }
}
