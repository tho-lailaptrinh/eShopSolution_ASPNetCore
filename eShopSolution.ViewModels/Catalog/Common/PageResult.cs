using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Common
{
    public class PageResult<T> //dùng cho tất các loại đối tường khác nhau
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
