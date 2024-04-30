using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021030.DomainModels;

namespace _19T1021030.Web.Models
{
    public class OrderEditModel : Order
    {
        public List<OrderDetail> dataOrderDeltail { get; set; }
    }
}