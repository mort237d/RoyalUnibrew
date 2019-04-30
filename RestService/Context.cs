using RestService.Models;

namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context() : base("name=Context2")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ControlRegistration>()
                .Property(e => e.CommentsOnChangedDate)
                .IsUnicode(false);

            modelBuilder.Entity<ControlRegistration>()
                .Property(e => e.Signature)
                .IsUnicode(false);

            modelBuilder.Entity<ControlRegistration>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.ControlRegistration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ControlSchedule>()
                .Property(e => e.ReceiptForTest)
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

            modelBuilder.Entity<ControlSchedule>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.ControlSchedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Frontpage>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Production>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.Production)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShiftRegistration>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftRegistration>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.ShiftRegistration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TU>()
                .HasMany(e => e.Frontpages)
                .WithRequired(e => e.TU)
                .WillCascadeOnDelete(false);
        }
    }
}
