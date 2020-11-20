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
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTpesController : ControllerBase
    {
        smalldatabaseContext db = DB.getDBInstance();
        // GET: api/<PaymentTpesController>
        [HttpGet]
        public List<Named> Get()
        {
            var s = db.PaymentMethods.Select(g => new Named { ID = g.Id, Name = g.Name }).ToList();
            return s;
        }

      
    }
}
