using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreCRUD
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }


    public class Department
    {
        public int DepartmentID { get; set; }

  
        public string Name { get; set; }
        public string Descr { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }


    public class Region
    {
        public int RegionID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }


    }

    public class Territory
    {
        public int TerritoryID { get; set; }
        public string Name { get; set; }

        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
    }


    public class SalesPerson
    {

        [Key, ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public int TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }

    }

}
