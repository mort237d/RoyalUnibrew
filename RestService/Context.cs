using RestService.Models;

namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context() : base("name=Context15")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ConstantValues> ConstantValues { get; set; }
        public virtual DbSet<ControlRegistration> ControlRegistration { get; set; }
        public virtual DbSet<ControlSchedule> ControlSchedule { get; set; }
        public virtual DbSet<Frontpage> Frontpage { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<ShiftRegistration> ShiftRegistration { get; set; }
        public virtual DbSet<StandardValues> StandardValues { get; set; }
        public virtual DbSet<TU> TU { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConstantValues>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ControlRegistration>()
                .Property(e => e.CommentsOnChangedDate)
                .IsUnicode(false);

            modelBuilder.Entity<ControlRegistration>()
                .Property(e => e.KegSize)
                .IsUnicode(false);

            modelBuilder.Entity<ControlRegistration>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<ControlSchedule>()
                .Property(e => e.KegTest)
                .IsUnicode(false);

            modelBuilder.Entity<ControlSchedule>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<ControlSchedule>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Frontpage>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.ControlRegistration)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.ControlSchedule)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.Production)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.ShiftRegistration)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.TU)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Frontpage)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShiftRegistration>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<StandardValues>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StandardValues>()
                .Property(e => e.Value)
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
