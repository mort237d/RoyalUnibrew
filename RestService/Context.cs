using RestService.Models;

namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context() : base("name=Context8")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ControlRegistration> ControlRegistrations { get; set; }
        public virtual DbSet<ControlSchedule> ControlSchedules { get; set; }
        public virtual DbSet<Frontpage> Frontpages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<ShiftRegistration> ShiftRegistrations { get; set; }
        public virtual DbSet<TU> TUs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.ControlRegistrations)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.ControlSchedules)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.Productions)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.ShiftRegistrations)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .HasMany(e => e.TUs)
                .WithRequired(e => e.Frontpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ControlRegistrations)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShiftRegistration>()
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
