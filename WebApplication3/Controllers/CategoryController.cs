using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class CategoryController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
        public IEnumerable<Category> Get()
        {
            return testdb.Category.ToList();
        }
        public Category GET(int id)
        {
            return testdb.Category.Where(a => a.id == id).FirstOrDefault();
        }
        public Category Post(Category category)
        {
            //validacion

            testdb.Category.Add(category);
            testdb.SaveChanges();
            return category;
        }

        public Category Put(Category category)
        {
            //validacion

            var categoryddb = testdb.Category.Where(a => a.id == category.id).First();
            categoryddb.nombre = category.nombre;
            testdb.SaveChanges();
            return category;
        }

    }
}
