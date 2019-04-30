using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("Frontpage")]
    public partial class Frontpage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessOrder_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int ControlSchedule_ID { get; set; }

        public int ControlRegistration_ID { get; set; }

        public int ShiftRegistration_ID { get; set; }

        public int Production_ID { get; set; }

        public int TU_ID { get; set; }

        public int Week_No { get; set; }

        public virtual ControlRegistration ControlRegistration { get; set; }

        public virtual ControlSchedule ControlSchedule { get; set; }

        public virtual Product Product { get; set; }

        public virtual Production Production { get; set; }

        public virtual ShiftRegistration ShiftRegistration { get; set; }

        public virtual TU TU { get; set; }
    }
}
