using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eShopSolution.Data.Entities
{
    public class Category
    {
        public int Id { set; get; } 
        public int SortOrder { set; get; }
        public bool IsShowOnHom { set; get; }
        public int ParentId { set; get; }
        public Status Status { set; get; }
        public List<ProductInCategory> ProductInCategories { set; get; }
        public List<CategoryTranslation> CategoryTranslations { set; get; }
    }
}
