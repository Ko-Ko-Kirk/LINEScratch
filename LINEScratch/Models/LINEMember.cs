using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LINEScratch.Models
{
    public partial class LINEMember
    {
        [Key]
        public int Id { get; set; }
        public string LineId { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
    }
}
