using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDevops_H2.Model;

namespace WebAPIDevops_H2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        List<Emp> _EmpApi = new List<Emp>()
        {
            new Emp() { EmpId = 1, Name = "Bhavani",Email = "abcd@gmail.com",Age = 38,Salary = 40000 },
            new Emp() { EmpId = 2, Name = "ravi",Email = "ravi@gmail.com",Age =22,Salary = 25000  },
            new Emp() { EmpId = 3, Name = "ashu",Email = "ashu@gmail.com",Age = 28,Salary = 28000 },
            new Emp() { EmpId = 4, Name = "gayathri",Email = "gayu@gmail.com",Age = 30,Salary = 35000 },
        };

        [HttpGet]

        public IActionResult Get()
        {
            if (_EmpApi.Count == 0)
            {
                return NotFound("No list found,");

            }
            return Ok(_EmpApi);
        }

        [HttpGet("GetEmp")]
        public IActionResult Get(int id)
        {
            Emp EmpApi = _EmpApi.SingleOrDefault(x => x.EmpId == id);
            if (EmpApi == null)
            {
                return NotFound("no Employee found.");
            }
            return Ok(EmpApi);
        }
        [HttpPost]
        public IActionResult save(Emp EmpApi)
        {
            _EmpApi.Add(EmpApi);
            if (_EmpApi.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_EmpApi);

        }
        [HttpDelete]
        public IActionResult DeteteEmp(int id)
        {
            Emp EmpApi = _EmpApi.SingleOrDefault(x => x.EmpId == id);
            if (EmpApi == null)
            {
                return NotFound("No Employee found.");
            }
            _EmpApi.Remove(EmpApi);
            if (_EmpApi.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_EmpApi);
        }

    }
}
