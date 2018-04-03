using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurkcellFacebookDunyasi.Core;
using System.Data;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.EF
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly TurkcellFacebookDunyasiDb _context;
        public Repository(TurkcellFacebookDunyasiDb context)
        {
            _context = context;
        }

        private void _Save(TEntity entity)
        {
            if (entity.Id == 0)
            {
                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = GlobalVars.CurrAdminId;
                entity.IsDeleted = false;
                _context.GetTable<TEntity>().Add(entity);
            }
            else
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifiedBy = GlobalVars.CurrAdminId > 0 ? GlobalVars.CurrAdminId : entity.ModifiedBy;
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
            }
        }

        public void Save(TEntity entity)
        {
            _Save(entity);
        }

        public void SaveAndCommit(TEntity entity)
        {
            _Save(entity);
            Commit();
        }

        private void _Destroy(TEntity entity)
        {
            ChangeEntityState(entity, EntityState.Deleted);                
        }
        public void Destroy(TEntity entity)
        {
            _Destroy(entity);
        }
        public void DestroyAndCommit(TEntity entity)
        {           
            _Destroy(entity);
            Commit();
        }

        private void _Delete(TEntity entity)
        {
            entity.ModifyDate = DateTime.Now;
            entity.ModifiedBy = GlobalVars.CurrAdminId;
            entity.IsDeleted = true;

            ChangeEntityState(entity, EntityState.Modified);
        }
        public void Delete(TEntity entity)
        {
            _Delete(entity);
        }
        public void DeleteAndCommit(TEntity entity)
        {
            _Delete(entity);
            Commit();
        }        

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }
        public void DeleteByIdAndCommit(int id)
        {
            var entity = GetById(id);
            Delete(entity);
            Commit();
        }

        public TEntity GetById(int id)
        {
            return _context.GetTable<TEntity>().Single(e => e.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.GetTable<TEntity>().Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).ToList();
        }
        public IEnumerable<TEntity> GetAllPublished()
        {
            return _context.GetTable<TEntity>().Where(p => p.IsDeleted == false && p.IsActive == true)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order)
                .ThenBy(p => p.Id).ToList();
        }        

        public IEnumerable<TEntity> GetAllByOrder()
        {
            return _context.GetTable<TEntity>().Where(p => p.IsDeleted == false)
                .OrderBy(p => p.Order == null ? GlobalVars.OrderMax : p.Order).OrderByDescending(p => p.Id).ToList();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex) { }
        }
        
        private void ChangeEntityState(TEntity entity, EntityState State)
        {
            var set = _context.Set<TEntity>();
            TEntity attachedEntity = set.Find(entity.Id);

            if (attachedEntity != null)
            {
                var attachedEntry = _context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
                attachedEntry.State = State;
            }
            else
            {
                _context.Entry<TEntity>(entity).State = State;
            }               
        }




    }
}