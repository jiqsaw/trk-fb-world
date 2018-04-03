using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurkcellFacebookDunyasi.Core;
using System.Data;
using TurkcellFacebookDunyasi.Com.General;
using System.Web;

namespace TurkcellFacebookDunyasi.EF
{
    public abstract class RepositoryDefault<TEntity> : IRepositoryDefault<TEntity> where TEntity : class, IEntityDefault
    {
        protected readonly TurkcellFacebookDunyasiDb _context;
        public RepositoryDefault(TurkcellFacebookDunyasiDb context)
        {
            _context = context;
        }

        public enum TransactionLogStatus
        {
            Save,
            Update
        }

        public void Update(TEntity entity)
        {
            ChangeEntityState(entity, EntityState.Modified);
            Commit();
        }

        private void _Save(TEntity entity)
        {
            if (entity.Id == 0)
            {
                entity.CreateDate = DateTime.Now;
                entity.IsDeleted = false;
                _context.GetTable<TEntity>().Add(entity);

                LogTransaction(entity, TransactionLogStatus.Save);
            }
            else
            {
                entity.ModifyDate = DateTime.Now;
                _context.Entry<TEntity>(entity).State = EntityState.Modified;

                LogTransaction(entity, TransactionLogStatus.Update);
            }
        }

        private void LogTransaction(TEntity entity, TransactionLogStatus state)
        {
            if (!(entity is ILog))
            {
                var type = entity.GetType();
                var serializer = new LIB.Serialize();
                TransactionLog log = new TransactionLog
                {
                    FbId = SessionUser.FbId,
                    Msisdn = SessionUser.Msisdn,
                    TcellSession = TcellSession,
                    IP = CurrentRequestIP,
                    Details = serializer.SerializeObject(entity),
                    Naming = type.Name,
                    Status = state.ToString(),
                    CreateDate = DateTime.Now
                };

                _context.TransactionLogs.Add(log);
            }
        }

        private UserFb SessionUser
        {
            get
            {
                try
                {
                    string sessionUserData = HttpContext.Current.Session["SessionUser"].ToString();
                    var serializer = new LIB.Serialize();

                    return (UserFb)serializer.DeserializeObject(sessionUserData, typeof(UserFb));
                }
                catch (Exception)
                {
                    return new UserFb { Msisdn = "", FbId = "" };
                }
            }
        }

        private string TcellSession
        {
            get
            {
                var sid = HttpContext.Current.Session["TurkcellSessionId"];
                return sid == null ? "" : sid.ToString();
            }
        }

        private string CurrentRequestIP
        {
            get
            {
                return HttpContext.Current.Request.UserHostAddress;
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

        public IEnumerable<TEntity> GetAllByOrder()
        {
            return _context.GetTable<TEntity>().Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id).ToList();
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