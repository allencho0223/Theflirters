using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D8M8.API.Data;

namespace D8M8.API.Controllers
{
    // http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    // ControllerBase is without view support whereas Controller class is with view support
    public class ValuesController : ControllerBase
    {
        // This field enbales to be used in the entire class
        // Initialise field from parameter
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            this._context = context;

        }
        // Inject DataContext
        // GET api/values
        [HttpGet]
        // With async keyword, it doesn't block anything and just wait till called
        // Asynchronous programming
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            // FirstOrDefault matches the particular id
            // First method throws an exception if the id doesn't exist
            /* 
                The reason for using FirstOrDefault is that
                if the id doesn't exist in the db, it just returns null
                instead of occurring an exception
             */ 
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
