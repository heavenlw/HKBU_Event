using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hkbulogin.Controllers
{
   
    public class signupController : ApiController
    {
        [HttpGet]
        public IHttpActionResult signup(string id, string password)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.SignUp(id, password));
                    
        }
    }
}
