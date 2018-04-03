using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.EF.Bases;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace TurkcellFacebookDunyasi.EF
{
    public class TurkcellFacebookDunyasiDb : BaseDbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdminAuth> AdminAuth { get; set; }
        public DbSet<Modul> Modul { get; set; }
        public DbSet<Faq> Faq { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<UserFb> UserFb { get; set; }
        public DbSet<UserInvite> UserInvite { get; set; }        
        public DbSet<UserRequestTL> UserRequestTL { get; set; }
        public DbSet<UserSentTL> UserSentTL { get; set; }
        public DbSet<WebService> WebService { get; set; }
        public DbSet<UserSms> UserSms { get; set; }

        //Log Tablolari
        public DbSet<WebServiceLog> WebServiceLogs { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

        public DbSet<ClickToCall> ClickToCall { get; set; }
        public DbSet<ClickToCallFree> ClickToCallFree { get; set; }
        public DbSet<ClickToCallUserBlock> ClickToCallUserBlock { get; set; }
        public DbSet<ClickToCallPreference> ClickToCallPreference { get; set; }
        public DbSet<TransferAmount> TransferAmount { get; set; }

        public TurkcellFacebookDunyasiDb() : base()
        {
            //UserFb'nin session'a serilestirilebilmesi icin bu gerekiyor.
            Configuration.ProxyCreationEnabled = false;
        }

        public void Dispose()
        {
            base.Dispose(false);
        }

        public DbSet<TEntity> GetTable<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TurkcellFacebookDunyasiDb>());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}