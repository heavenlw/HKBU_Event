using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hkbulogin.Controllers
{
    public class loginController : ApiController
    {

        [HttpGet]
        
        public IHttpActionResult Login(string id, string password)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.GetDetail(id,password));
        }


     

    }
}
