using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Entities
{
    public class Language
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool IsDefault { set; get; }
        public List<ProductTranslation> ProductTranslations { set; get; }
        public List<CategoryTranslation> CategoryTranslations { set; get; }
    }
}       
