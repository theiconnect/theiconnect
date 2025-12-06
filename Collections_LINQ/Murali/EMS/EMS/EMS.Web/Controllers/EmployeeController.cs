using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [Route("getallemployees")]
        [Route("list")]
        public string Index3()
        {
            return "hi";
        }

        public string Index()
        {
            return "Hello from Index";
        }

        public int Index2()
        {
            return  100;
        }


        [NonAction]
        public string Index1()
        {
            return "Hello from Index1";
        }
    }

    [Route("e")]
    public class Employee1Controller : Controller
    {


        [Route("")]
        [Route("hellobabai")]
      
        [Route("helloKaka")]
        public string Index()
        {
            return "Employee1Controller - Hello from sai ram";
        }
      

        public int Index2()
        {
            return 100;
        }

        public int Index3()
        {
            return 100;
        }


        [NonAction]
        public string Index1()
        {
            return "Hello from Index1";
        }
    }

    
    [Route("Test")]
    public class TestController : Controller
    {
        public string A()
        {
            return string.Empty;
        }
        //localhost:234/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        public string C()
        {
            return string.Empty;
        }
    }

    [Route("Test1")]
    public class Test1Controller : Controller
    {
        public string A()
        {
            return string.Empty;
        }

        //localhost:234/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        public string C()
        {
            return string.Empty;
        }
    }

}
