using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021030.DomainModels
{
    public class Category
    {
        /// <summary>
        /// Max loại hàng
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Tên loại hàng
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Mô tả loại hàng
        /// </summary>
        public string Description { get; set; }
    }
}
