using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCRUD
{
    public class UpdateExample
    {
        public void Qry()
        {

            //UpdateConnected();
            //UpdateDisconnected();

            //UpdateWrongWay(10, "Purchase Department");
            //UpdateRightWay(10, "Sales Department");

        }


        private void UpdateConnected()
        {

            Department department;

            //Connected Scenario
            using (EFCoreContext db = new EFCoreContext())
            {
                department = db.Departments.Where(d => d.Name == "Sales").First();
                department.Descr = "This is Sales Department";
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is Updated ", department.Name, department.DepartmentID);
                
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


            //SELECT TOP(1) [d].[DepartmentID], [d].[Descr], [d].[Name]
            //FROM [Departments] AS [d]
            //WHERE [d].[Name] = N'Sales'

            //UPDATE [Departments] SET [Descr] = @p0
            //WHERE [DepartmentID] = @p1;
      
            //SELECT @@ROWCOUNT;





        }


        private void UpdateDisconnected()
        {

            Department department;

            //Disconnected Scenario
            using (EFCoreContext db = new EFCoreContext())
            {
                department = db.Departments.Where(d => d.Name == "Sales").First();
            }

            department.Descr = "Sales Department-Disconnected Scenario";
            using (EFCoreContext db = new EFCoreContext())
            {

                db.Entry(department).State = EntityState.Modified;

                //OR
                //db.Departments.Attach(department);
                //db.Entry(department).State = System.Data.Entity.EntityState.Modified;

                //OR
                //db.Departments.Add(department);
                //db.Entry(department).State = System.Data.Entity.EntityState.Modified;


                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Updated ", department.Name, department.DepartmentID);
            Console.ReadKey();

            //UPDATE [Departments] SET [Descr] = @p0, [Name] = @p1
            //WHERE [DepartmentID] = @p2;
            //SELECT @@ROWCOUNT;


        }



        private void UpdateWrongWay(int id, string descr)
        {
            Department department = new Department();
            department.DepartmentID = id;
            department.Descr = descr;

            using (EFCoreContext db = new EFCoreContext())
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Updated ", department.Name, department.DepartmentID);
            Console.ReadKey();

        }




        private void UpdateRightWay(int id, string descr)
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = db.Departments.Where(f => f.DepartmentID == id).FirstOrDefault();
                if (department == null) throw new Exception("");

                department.Descr = descr;
                db.SaveChanges();
            }

            Console.WriteLine("Records Updated");
            Console.ReadKey();

        }


        private void UpdateMultipleRecords()
        {

            List<Department> departments = new List<Department>();

            departments.Add(new Department { DepartmentID = 1, Descr = "Sales" });
            departments.Add(new Department { DepartmentID = 2, Descr = "Purchase" });
            departments.Add(new Department { DepartmentID = 3, Descr = "HR" });

            using (EFCoreContext db = new EFCoreContext())
            {

                foreach (var item in departments)
                {
                    var dept = db.Departments.Where(f => f.DepartmentID == item.DepartmentID).FirstOrDefault();
                    if (dept == null) throw new Exception("");

                    dept.Descr = item.Descr;
                }

                db.SaveChanges();
            }

            Console.WriteLine("Records Updated ");
            Console.ReadKey();

        }



    }
}
