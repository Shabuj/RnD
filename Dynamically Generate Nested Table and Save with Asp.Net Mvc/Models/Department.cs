using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Department
    {
        public Department(int departmentId, string departmentName, string departmentCode)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            DepartmentCode = departmentCode;
        }

        public int DepartmentId { get; set; }
        public string  DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

    }
}