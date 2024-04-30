using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021030.DomainModels;

namespace _19T1021030.Web.Models
{
    public class ProductEditModel : Product
    {
        public List<ProductPhoto> Photos { get; set;}
        public List<ProductAttribute> Attributes { get; set; }
    }
}