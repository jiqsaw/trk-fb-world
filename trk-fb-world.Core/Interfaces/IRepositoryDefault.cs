using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurkcellFacebookDunyasi.Core
{
    public interface  IRepositoryDefault<TEntity>  where TEntity : class, IEntityDefault
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
        IEnumerable<TEntity> GetAllByOrder();
        
        void Commit();

        void Update(TEntity entity);
    }
}
