using RestService.Models;

namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context(): base("name=Context4")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Models.ControlRegistration> ControlRegistrations { get; set; }
        public virtual DbSet<Models.ControlSchedule> ControlSchedules { get; set; }
        public virtual DbSet<Models.Frontpage> Frontpages { get; set; }
        public virtual DbSet<Models.Product> Products { get; set; }
        public virtual DbSet<Models.Production> Productions { get; set; }
        public virtual DbSet<Models.ShiftRegistration> ShiftRegistrations { get; set; }
        public virtual DbSet<Models.TU> TUs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ControlRegistration>()
                .Property(e => e.CommentsOnChangedDate)
                .IsUnicode(false);

            modelBuilder.Entity<Models.ControlRegistration>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<Models.ControlSchedule>()
                .Property(e => e.KegTest)
                .IsUnicode(false);

            modelBuilder.Entity<Models.ControlSchedule>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<Models.ControlSchedule>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Models.Frontpage>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Models.Frontpage>()
                .HasMany(e => e.ControlSchedules)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Frontpage>()
                .HasMany(e => e.Productions)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Frontpage>()
                .HasMany(e => e.ShiftRegistrations)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Frontpage>()
                .HasMany(e => e.TUs)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Models.Product>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.ShiftRegistration>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone_No)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ImageSource)
                .IsUnicode(false);
        }
    }
}
