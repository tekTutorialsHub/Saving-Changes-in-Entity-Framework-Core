
using System;
using System.Linq;

namespace EFCoreCRUD
{
    class Program
    {
        static void Main(string[] args)
        {

            //Delete ALl Example data
            //deleteAll();

            AddExample addExample = new AddExample();
            //addExample.Qry();

            UpdateExample updateExample = new UpdateExample();
            //updateExample.Qry();

            DeleteExample deleteExample = new DeleteExample();
            deleteExample.Qry();


            ChangeTrackerExample changeTrackerExample = new ChangeTrackerExample();
            //changeTrackerExample.qry();

        }


        static void deleteAll()
        {

            using (EFCoreContext db = new EFCoreContext())
            {

                db.RemoveRange(db.Departments.ToList());
                db.RemoveRange(db.Employees.ToList());
                db.RemoveRange(db.Regions.ToList());
                db.RemoveRange(db.Territories.ToList());
                db.RemoveRange(db.SalesPersons.ToList());

                db.SaveChanges();
            }

        }


    }
}
