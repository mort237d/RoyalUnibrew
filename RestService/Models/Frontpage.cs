using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("Frontpage")]
    public partial class Frontpage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Frontpage()
        {
            ControlRegistration = new HashSet<ControlRegistration>();
            ControlSchedule = new HashSet<ControlSchedule>();
            Production = new HashSet<Production>();
            ShiftRegistration = new HashSet<ShiftRegistration>();
            TU = new HashSet<TU>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessOrder_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int Week_No { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlRegistration> ControlRegistration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlSchedule> ControlSchedule { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Production> Production { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftRegistration> ShiftRegistration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TU> TU { get; set; }
    }
}
