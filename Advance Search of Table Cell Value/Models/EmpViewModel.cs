using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectCellValueSearch.Models
{
    public class EmpViewModel
    {
        public EmpViewModel(int empId, string empName, int age, int depId, string depName, string depCode)
        {
            this.empId = empId;
            this.empName = empName;
            this.age = age;
            this.depId = depId;
            this.depName = depName;
            this.depCode = depCode;
        }



        //SELECT E.Emp_Id, E.EmpName, E.Age, D.Dep_Name, D.Dep_Code, E.Dep_Id FROM Department AS D INNER JOIN Employee AS E ON D.Dep_Id = E.Dep_Id
        public int empId { get; set; }
        public string empName { get; set; }
        public int age { get; set; }
        public int depId { get; set; }
        public string depName { get; set; }
        public string depCode { get; set; }
        
    }
}