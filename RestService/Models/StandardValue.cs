using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestService.Models
{
    public partial class StandardValue
    {
        [Key]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Value { get; set; }
    }
}