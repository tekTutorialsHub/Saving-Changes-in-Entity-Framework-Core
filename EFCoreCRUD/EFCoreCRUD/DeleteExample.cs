using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreCRUD
{
    public class DeleteExample
    {

        public void Qry()
        {
            //DeleteConnected();
            DeleteDisconnectedWithoutLoading();

        }



        public void DeleteConnected()
        {

            Department department;

            //Connected Scenario
            using (EFCoreContext db = new EFCoreContext())
            {

                department = db.Departments.Where(d => d.Name == "Sales").FirstOrDefault();
                db.Departments.Remove(department);
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is Deleted ", department.Name, department.DepartmentID);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }



        public void DeleteDisconnected()
        {

            Department department;

            //Disconnected Scenario
            using (EFCoreContext db = new EFCoreContext())
            {
                department = db.Departments.Where(d => d.Name == "Sales").First();
            }


            using (EFCoreContext db = new EFCoreContext())
            {


                //This also works
                //db.Departments.Attach(department);
                //db.Entry(department).State = System.Data.Entity.EntityState.Deleted;

                db.Entry(department).State = EntityState.Deleted;
                db.SaveChanges();
            }

            Console.WriteLine("Department {0} ({1}) is Deleted ", department.Name, department.DepartmentID);
            Console.ReadKey();

        }


        public void DeleteDisconnectedWithoutLoading()
        {
            Department department;

            department = new Department() { DepartmentID = 36 };

            using (EFCoreContext db = new EFCoreContext())
            {

                db.Entry(department).State = EntityState.Deleted;
                db.SaveChanges();

            }
            Console.WriteLine("Department {0} is Deleted ", department.DepartmentID);
            Console.ReadKey();

        }


        public void DeleteMultipleRecordsConnected()
        {

            //Deleting Multiple Records
            using (EFCoreContext db = new EFCoreContext())
            {

                List<Department> deps = db.Departments.Take(2).ToList();
                db.Departments.RemoveRange(deps);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Console.ReadKey();

        }


        public void DeleteMultipleRecordsDisconnected()
        {

            List<Department> departments = new List<Department>();
            departments.Add(new Department { DepartmentID = 1 });
            departments.Add(new Department { DepartmentID = 2 });

            //Deleting Multiple Records
            using (EFCoreContext db = new EFCoreContext())
            {

                db.Entry(departments).State = EntityState.Deleted;



                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Console.ReadKey();

        }

    }
}
