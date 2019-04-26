using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("ControlSchedule")]
    public partial class ControlSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ControlSchedule()
        {
            Frontpages = new HashSet<Frontpage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Control_ID { get; set; }

        public DateTime Time { get; set; }

        public DateTime WeightControlTime { get; set; }

        public int Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptForTest { get; set; }

        [Required]
        [StringLength(50)]
        public string KegTest { get; set; }

        public double LudKoncentration { get; set; }

        public double MipMA { get; set; }

        [Required]
        [StringLength(50)]
        public string Signature { get; set; }

        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frontpage> Frontpages { get; set; }
    }
}
