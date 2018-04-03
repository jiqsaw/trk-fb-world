using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkcellFacebookDunyasi.Core
{
    public interface IRepository<TEntity>  where TEntity : class, IEntity
    {
        void Save(TEntity entity);
        void SaveAndCommit(TEntity entity);

        void Destroy(TEntity entity);
        void DestroyAndCommit(TEntity entity);

        void Delete(TEntity entity);
        void DeleteAndCommit(TEntity entity);

        void DeleteById(int id);
        void DeleteByIdAndCommit(int id);

        TEntity GetById(int id);
        
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllPublished();
        IEnumerable<TEntity> GetAllByOrder();
        
        void Commit();
    }
}
