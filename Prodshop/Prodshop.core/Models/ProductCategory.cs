using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodshop.core.Models
{
    public class ProductCategory :BaseEntity
    {
       
        public string Category { get; set; }

       
    }
    //public class CatDBContext : DbContext
    //{
    //    public CatDBContext()
    //    { }
    //    public DbSet<Category> Categories { get; set; }

    //}

    //public class DbContext
    //{
    //}
}
