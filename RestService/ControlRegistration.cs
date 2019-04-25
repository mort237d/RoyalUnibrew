namespace RestService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ControlRegistration")]
    public partial class ControlRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ControlRegistration()
        {
            Frontpages = new HashSet<Frontpage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LabelControl_ID { get; set; }

        public DateTime Time { get; set; }

        public DateTime Production_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string CommentsOnChangedDate { get; set; }

        public bool ControlAlcoholSpearDispenser { get; set; }

        public int CapNo { get; set; }

        public int EtiquetteNo { get; set; }

        public double KegSize { get; set; }

        [Required]
        [StringLength(50)]
        public string Signature { get; set; }

        public DateTime FirstPalletDepalletizing { get; set; }

        public DateTime LastPalletDepalletizing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frontpage> Frontpages { get; set; }
    }
}
