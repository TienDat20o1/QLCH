using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021030.Web.Controllers
{
    [Authorize]
    [RoutePrefix("thu-nghiem")]
    public class TestController : Controller
    {
        [Route("xin-chao/{name?}/{age?}")]
      public string SayHello(string name= "", int age=18)
        {
            return $"Hello {name},{age} years old";
        }
    }
}