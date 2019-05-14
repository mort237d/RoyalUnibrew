using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("ShiftRegistration")]
    public partial class ShiftRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShiftRegistration_ID { get; set; }

        public TimeSpan Start_Time { get; set; }

        public TimeSpan End_Date { get; set; }

        public int Breaks { get; set; }

        public int TotalHours { get; set; }

        public int Staff { get; set; }

        [StringLength(10)]
        public string Initials { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpage Frontpage { get; set; }
    }
}
