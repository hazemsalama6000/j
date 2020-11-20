using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestuProj.Controllers;
using RestuProj.Models;
using RestuProj.usefullclasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {

        private  smalldatabaseContext db = DB.getDBInstance();

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<Named> Get()
        {
            return db.Foods.Select(g=>new Named {ID=g.Id,Name=g.Name }).ToList();
        }
        [HttpGet("{id}")]
        public Food GetFoodItem(int id)
        {
            return db.Foods.Where(a=>a.Id==id).FirstOrDefault();
        }



    }
}
