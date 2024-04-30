using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021030.DomainModels;

namespace _19T1021030.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang đối với nhân viên
    /// </summary>
    public class EmployeeSearchOutput : PaginationSearchOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}