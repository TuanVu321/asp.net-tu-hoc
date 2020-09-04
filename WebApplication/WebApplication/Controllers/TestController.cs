using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICRUD _crud;

        public TestController(ICRUD crud)
        {
            _crud = crud;
        }

        [HttpGet]
        public async  Task<IActionResult> ShowAll()
        {
            var value = await _crud.GetAllValue();
            return Ok(value);
        }

    }
}