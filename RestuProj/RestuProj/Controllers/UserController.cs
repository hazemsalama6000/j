using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestuProj.Models;
using RestuProj.usefullclasses;

namespace RestuProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        smalldatabaseContext ob= DB.getDBInstance();
        [HttpGet]
        public object checkUser(string Name ,string Pass)
        {
           var s = ob.DefUsers.Where(a => a.Name == Name && a.Pass == Pass).FirstOrDefault();
            if (s == null)
            {
                return new { action = "n" };
            }
            else
            {
                return new { action = "y" };
            }
        }





    }
       
}
