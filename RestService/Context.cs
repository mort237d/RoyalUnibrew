namespace RestService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context(): base("name=Context")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Frontpage> Frontpages { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
