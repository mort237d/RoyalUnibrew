namespace RestService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TU")]
    public partial class TU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TU()
        {
            Frontpages = new HashSet<Frontpage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TU_ID { get; set; }

        public int FirstDayStart_TU { get; set; }

        public int FirstDayEnd_TU { get; set; }

        public int FirstDay_Total { get; set; }

        public int SecoundDayStart_TU { get; set; }

        public int SecoundDayEnd_TU { get; set; }

        public int SecoundDay_Total { get; set; }

        public int ThirdDayStart_TU { get; set; }

        public int ThirdDayEnd_TU { get; set; }

        public int ThirdDay_Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frontpage> Frontpages { get; set; }
    }
}
