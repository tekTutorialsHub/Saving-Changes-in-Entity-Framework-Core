using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreCRUD
{
    public class AddExample
    {

        public void Qry()
        {
            //AddSingleRecord();
            //AddListOfOjects();

            //AddListOfOjects1();
            //AddIdentyInsert();


            //AddRelatedData1();
            //AddRelatedData2();
            //AddRelatedData3();
            AddRelatedData4();

        }

        public void AddSingleRecord()
        {
            using (EFCoreContext db = new EFCoreContext())
            {
                Department department = new Department();
                department.Name = "Secuirty";
                db.Departments.Add(department);

                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


          
          //INSERT INTO [Departments] ([Descr], [Name])
          //VALUES (@p0, @p1);

          //SELECT [DepartmentID]
          //FROM [Departments]
          //WHERE @@ROWCOUNT = 1 AND [DepartmentID] = scope_identity();


        }

        public void AddListOfOjects()
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                List<Department> deps = new List<Department>();
                deps.Add(new Department { Name = "Dept1", Descr = "" });
                deps.Add(new Department { Name = "Dept2", Descr = "" });
                db.Departments.AddRange(deps);
                db.SaveChanges();

                Console.WriteLine("{0} Departments added ", deps.Count);
                Console.ReadKey();
            }


            //INSERT INTO [Departments] ([Descr], [Name])
            //VALUES (@p0, @p1);

            //SELECT [DepartmentID]
            //FROM [Departments]
            //WHERE @@ROWCOUNT = 1 AND [DepartmentID] = scope_identity();
          
            //INSERT INTO [Departments] ([Descr], [Name])
            //VALUES (@p0, @p1);
         
            //SELECT [DepartmentID]
            //FROM [Departments]
            //WHERE @@ROWCOUNT = 1 AND [DepartmentID] = scope_identity();


        }


        public void AddListOfOjects1()
        {

            //This wont add
            using (EFCoreContext db = new EFCoreContext())
            {

                List<Department> deps = db.Departments.ToList();

                //These records are not added
                deps.Add(new Department { Name = "Dept3", Descr = "" });
                deps.Add(new Department { Name = "Dept4", Descr = "" });

                //This record is added
                db.Departments.Add(new Department { Name = "Dept5", Descr = "" });


                db.SaveChanges();

                Console.WriteLine("Departments added");
                Console.ReadKey();
            }

        }

        public void AddIdentyInsert()
        {

            //insertDepartments();

            //This wont add
            using (EFCoreContext db = new EFCoreContext())
            {

                Department department = new Department();
                department = new Department { DepartmentID = 10, Name = "Sales", Descr = "" };
                
                db.Departments.Add(department);

                try
                {
                    db.Database.OpenConnection();
                    db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Departments ON");
                    db.SaveChanges();
                    db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Departments OFF;");
                }
                catch (Exception ex)
                {

                    throw;
                } finally
                {
                    db.Database.CloseConnection();
                }  

                
                Console.WriteLine("Departments added ");
                Console.ReadKey();
            }

        }



        public void insertDepartments()
        {
            using (EFCoreContext db = new EFCoreContext())
            {
                List<Department> departments = new List<Department>();
                departments.Add(new Department { Name = "HR", Descr = "" });
                departments.Add(new Department { Name = "Finance", Descr = "" });
                departments.Add(new Department { Name = "Accounts", Descr = "" });
                departments.Add(new Department { Name = "Production", Descr = "" });
                departments.Add(new Department { Name = "Marketing", Descr = "" });
                departments.Add(new Department { Name = "Maintenance", Descr = "" });
                db.Departments.AddRange(departments);
                db.SaveChanges();

            }
        }

        public void AddRelatedData1()
        {

            // Adding Department & Employee 
            using (EFCoreContext db = new EFCoreContext())
            {


                //Create new employee
                Employee emp = new Employee();
                emp.FirstName = "Anil";
                emp.LastName = "Kumble";


                // Creat a new department 
                Department department = new Department();
                department.Name = "Bowling";
                department.Employees = new List<Employee>();
                department.Employees.Add(emp);

                //Add department to Departments
                //Note that we are not adding Employee. Employee is already added to Dep 
                db.Departments.Add(department);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);
                Console.WriteLine("Employee {0} ({1}) is added in the department {2} ", emp.FirstName, emp.EmployeeID, emp.Department.Name);
                Console.ReadKey();

            }


            //INSERT INTO[Departments] ([Descr], [Name])
            //VALUES(@p0, @p1);
            //SELECT[DepartmentID]
            //FROM[Departments]
            //WHERE @@ROWCOUNT = 1 AND[DepartmentID] = scope_identity();
            //INSERT INTO[Employees] ([DepartmentID], [FirstName], [LastName])
            //VALUES(@p2, @p3, @p4);
            //SELECT[EmployeeID]
            //FROM[Employees]
            //WHERE @@ROWCOUNT = 1 AND[EmployeeID] = scope_identity();



        }

        public void AddRelatedData2()
        {

            // Adding Department & Employee 
            using (EFCoreContext db = new EFCoreContext())
            {


                // Creat a new department 
                Department department = new Department();
                department.Name = "Bowling";
                department.Employees = new List<Employee>();
                department.Employees.Add(new Employee { FirstName = "Anil", LastName = "Kumble" });
                department.Employees.Add(new Employee { FirstName = "Harbajan", LastName = "Singh" });

                //Add department to Departments
                //Note that we are not adding Employee. Employee is already added to Dep 
                db.Departments.Add(department);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);
                Console.ReadKey();

            }
        }



        public void AddRelatedData3()
        {


            // Adding Department & Employee
            using (EFCoreContext db = new EFCoreContext())
            {

            
                // Get the existing Department
                Department department = db.Departments.Where(f=> f.Name== "Bowling").FirstOrDefault();
                
                //Add Employee with Deparmtnet
                Employee emp = new Employee();
                emp.FirstName = "Kapil";
                emp.LastName = "Dev";
                emp.Department = department;
                db.Employees.Add(emp);

                //Save
                db.SaveChanges();

                Console.WriteLine("Department {0} ({1}) is added ", department.Name, department.DepartmentID);
                Console.WriteLine("Employee {0} ({1}) is added in the department {2} ", emp.FirstName, emp.EmployeeID, emp.Department.Name);
                Console.ReadKey();

            }

        }

        public void AddRelatedData4()
        {


            // Adding Department & Employee
            using (EFCoreContext db = new EFCoreContext())
            {


                //Add Employee with Deparmtnet
                Employee emp = new Employee();
                emp.FirstName = "Kapil";
                emp.LastName = "Dev";
                emp.DepartmentID = 10;
                db.Employees.Add(emp);

                //Save
                db.SaveChanges();

                //Console.WriteLine("Employee {0} ({1}) is added in the department {2} ", emp.FirstName, emp.EmployeeID, emp.Department.Name);
                Console.ReadKey();

            }

        }



    }
}
