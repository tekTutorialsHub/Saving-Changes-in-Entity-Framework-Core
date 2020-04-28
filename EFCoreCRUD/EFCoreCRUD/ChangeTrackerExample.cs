using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreCRUD
{
    public class ChangeTrackerExample
    {


        public void qry()
        {

            //AddDepartment();

            //SetStatus();
            //Reload();
            //CheckStatus();

            //AddStatusExample();
            //ModifiedStatusExample();
            //DeletedStatusExample();

            AttachExample();
        }


        public void SetStatus()
        {

            //Adding
            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = new Department();

                department.Name = "Secuirty";
                db.Entry(department).State = EntityState.Added;

                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);

            }

            Console.ReadKey();

        }


        public void AddDepartment()
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = new Department();
                department.Name = "Secuirty";
                db.Entry(department).State = EntityState.Added;

                department = new Department();
                department.Name = "HR";
                db.Add(department);

                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);

            }
        }



        public void Reload()
        {

            Console.WriteLine("Reload Example ");

            //Adding
            using (EFCoreContext db = new EFCoreContext())
            {
                Department department =db.Departments.Where(f=> f.Name=="HR").FirstOrDefault();
                db.Entry(department).Reload();
            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();

        }


        public void CheckStatus()
        {

            Console.WriteLine("Checking Status");



            using (EFCoreContext db = new EFCoreContext())
            {
                Department department = db.Departments.Where(f => f.Name == "HR").FirstOrDefault();
                db.Entry(department).State.ToString();
                Console.WriteLine("Status "+ db.Entry(department).State.ToString());

                department = new Department();
                db.Entry(department).State.ToString();
                Console.WriteLine("Status " + db.Entry(department).State.ToString());

                db.Add(department);
                db.Entry(department).State.ToString();
                Console.WriteLine("Status " + db.Entry(department).State.ToString());


            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();

        }



        public void AddStatusExample()
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = new Department();
                department.Name = "Production";
                db.Add(department);
                Console.WriteLine("Status Before SaveChanges " + db.Entry(department).State.ToString());

                db.SaveChanges();

                Console.WriteLine("Status After SaveChanges  " + db.Entry(department).State.ToString());

            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }


        public void ModifiedStatusExample()
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = db.Departments.Where(f => f.Name == "Production").FirstOrDefault();
                department.Name = "Production Department";
                Console.WriteLine("Status Before SaveChanges " + db.Entry(department).State.ToString());
                db.SaveChanges();
                Console.WriteLine("Status After SaveChanges  " + db.Entry(department).State.ToString());

            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        public void DeletedStatusExample()
        {
            AddDepartment();
            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = db.Departments.Where(f => f.Name == "HR").FirstOrDefault();
                db.Remove(department);
                Console.WriteLine("Status Before SaveChanges  " + db.Entry(department).State.ToString());
                db.SaveChanges();
                Console.WriteLine("Status After SaveChanges  " + db.Entry(department).State.ToString());

            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }



        public void AttachExample()
        {

            Console.WriteLine("Attach Example");

            Department department1 = new Department();
            department1.Name = "Production";

            Department department2 = new Department();
            department2.DepartmentID = 10;
            department2.Name = "Finance";


            using (EFCoreContext db = new EFCoreContext())
            {

                Console.WriteLine("Status Before Attach department1 " + db.Entry(department1).State.ToString());   //Detached
                Console.WriteLine("Status Before Attach department2 " + db.Entry(department2).State.ToString());   //Detached

                db.Attach(department1);
                db.Attach(department2);

                Console.WriteLine("Status After Attach department1 " + db.Entry(department1).State.ToString());    //Added
                Console.WriteLine("Status After Attach department2 " + db.Entry(department1).State.ToString());    //Unchanged

                db.Entry(department1).State = EntityState.Detached;
                Console.WriteLine("Status After Detach department1 " + db.Entry(department1).State.ToString());    //Added

            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

    }
}
