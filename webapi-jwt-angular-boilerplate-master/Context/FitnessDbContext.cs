﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using Infrastructure.Interface;
using Context.Entities;

namespace Context
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext()
            : base("FitnessDB")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.Entity is ITrackableEntity)
                            &&
                            (x.State == EntityState.Added ||
                             x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                ITrackableEntity entity = entry.Entity as ITrackableEntity;
                if (entity != null)
                {
                    string identityName = GetUser();
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }

            }
            return base.SaveChanges();
        }

        public string GetUser()
        {
            string identityName = "unknown";
            try
            {
                identityName = Thread.CurrentPrincipal.Identity.Name;
            }
            catch (Exception e)
            {
                //Should log that we can't get the currently logged in user
            }

            return identityName;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ClientTicket> ClientTickets { get; set; }
    }
}