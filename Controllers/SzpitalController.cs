using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [Route("api/szpital")]
    [ApiController]
    public class SzpitalController : ControllerBase
    {
        private IDbService dbservice;

        public SzpitalController(IDbService dbservice)
        {
            this.dbservice = dbservice;
        }


        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            Console.WriteLine("get");
            return dbservice.getDoctor();
        }

        [HttpPost("add")]
        public void addDoctor(Doctor doctor)
        {
            dbservice.addDoctor(doctor);
            Console.WriteLine("Added");
        }

        [HttpPut("update")]
        public void UpdateDoctor(Doctor doctor)
        {
            Console.WriteLine("Modified");
            dbservice.updateDoctor(doctor);
        }

        [HttpDelete("Delete/{Id}")]
        public void DeleteDoctor(int id)
        {
            Console.WriteLine("Deleted");
            dbservice.deleteDoctor(id);
        }

    }
}