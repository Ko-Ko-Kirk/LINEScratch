using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LINEScratch.ViewModels
{
    public class ListWinner
    {
        [DisplayName("LINE圖片")]
        public string PicUrl { get; set; }

        [DisplayName("LINE ID")]
        public string LineId { get; set; }

        [DisplayName("LINE名稱")]
        public string Name { get; set; }

        [DisplayName("獎項")]
        public string PrizeName { get; set; }

        [DisplayName("刮刮卷編號")]
        public int PrizeId { get; set; }                       
    }
}
