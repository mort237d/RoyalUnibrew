namespace RestService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Frontpages = new HashSet<Frontpage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinishedProduct_No { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        public int BedstBeforeDateLength { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frontpage> Frontpages { get; set; }
    }
}
