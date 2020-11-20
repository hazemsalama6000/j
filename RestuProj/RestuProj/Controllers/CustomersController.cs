using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestuProj.Models;
using RestuProj.usefullclasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestuProj.Controllers
{
   public class Named
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private smalldatabaseContext Db = DB.getDBInstance();

        // GET: api/<CustomersController>
        [HttpGet]
        public List<Named> Get()
        {
            var s = (Db.Customers.Select(g => new Named{ ID = g.Id, Name = g.Name }).ToList());
            return s;
        }



    }
}
