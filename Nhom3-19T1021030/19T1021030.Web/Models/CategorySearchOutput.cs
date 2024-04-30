using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021030.DomainModels;

namespace _19T1021030.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang đối với loại hàng
    /// </summary>
    public class CategorySearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Category> Data { get; set; }
    }
}