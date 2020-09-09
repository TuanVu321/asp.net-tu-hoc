using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValueController : ControllerBase
    {
        private readonly DataContext _context;

        public ValueController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetValues()
        {
            var values = _context.Values.ToList();
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetValueById(int id)
        {
            var values = _context.Values.Find(id);
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult save()
        {
            var value = new Value {Name = "value4"};
            _context.Values.Add(value);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var values = _context.Values.Find(id);
            if (values == null) return NotFound();
            _context.Values.Remove(values);
            _context.SaveChanges();
            return Ok();
            
        }

        // [HttpGet]
        // public IActionResult FindByValue()
        // {
        //     const string find = "value1";
        //     var value = _context.Values.Where(s=>s.Name.Contains(find));
        //     return Ok(value);
        // }
        
    }
}