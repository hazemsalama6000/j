using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestuProj.Models;

namespace RestuProj.usefullclasses
{
    public static class DB
    {
       
        
        private static smalldatabaseContext ob; 
        public static smalldatabaseContext getDBInstance()
        {
            if (ob==null)
            {
                ob = new smalldatabaseContext();
            }
            return ob;
        }
        

    }
}
