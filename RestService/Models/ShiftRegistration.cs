using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("ShiftRegistration")]
    public partial class ShiftRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShiftRegistration()
        {
            Frontpages = new HashSet<Frontpage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Shift_Reg { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime End_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime Breaks { get; set; }

        public int TotalHours { get; set; }

        public int Staff { get; set; }

        [StringLength(10)]
        public string Initials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frontpage> Frontpages { get; set; }
    }
}
