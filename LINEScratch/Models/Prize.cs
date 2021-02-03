using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LINEScratch.Models
{
    public partial class Prize
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("得獎票卷編號")]
        public int PrizeId { get; set; }
        [DisplayName("獎項名稱")]
        public string PrizeName { get; set; }
        [DisplayName("獎項圖片")]
        public string PrizePic { get; set; }
    }
}
