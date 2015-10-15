using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
namespace Event_App.Controllers
{
    public class IdController : ApiController
    {
        [HttpGet]
        
        public HttpResponseMessage GetDetail(int id)
        {
            if (id == 1)
            {
                Student student = new Student();
                student.student_id = 1;

                student.venus_list = new List<string>();
                student.venus_list.Add("1");
                student.venus_list.Add("2");
                student.venus_list.Add("3");
                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }
            if (id == 2)
            {
                Student student = new Student();
                student.student_id = 2;

                student.venus_list = new List<string>();
                student.venus_list.Add("2");
                student.venus_list.Add("3");
                student.venus_list.Add("4");
                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }
            if (id == 3)
            {
                Student student = new Student();
                student.student_id = 3;

                student.venus_list = new List<string>();
                student.venus_list.Add("1");
                student.venus_list.Add("2");
                student.venus_list.Add("4");
                string json = JsonConvert.SerializeObject(student);
                return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }
           
                return new HttpResponseMessage { Content = new StringContent("error id", System.Text.Encoding.UTF8, "application/json") };
      

        }
    }
}
