using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mis321pa3api.api.models;
using mis321pa3api.api.DataAccess;
using mis321pa3api.api.database;
using mis321pa3api.api.interfaces;

namespace mis321pa3api.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/Driver
        [HttpGet]
        public List<Driver> Get()  //Show all drivers
        {
            IGetAll readObject = new DriverDataAccess();
            return readObject.GetAll();
        }

        // GET: api/Driver/ //get 1 //won't need //how you pass things in on url//actually might need after all
        [HttpGet("{id}", Name = "Get")]
        public Driver Get(int id)
        {
            IGetDriver readObject = new DriverDataAccess();
            return readObject.GetDriver(id);
        }

        // POST: api/Driver //create //hire driver
        [HttpPost]
        public void Post([FromBody] Driver value)
        {
            ICreateDriver hireDriver = new CreateDriver();
            hireDriver.CreateDriver(value);
        }

        // PUT: api/Driver/5 //edit driver rating
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Driver value)
        {
            IUpdateDriverRating editRating = new UpdateDriverRating();
            editRating.UpdateDriverRating(id);
        }

        // DELETE: api/Driver/5 //fire driver
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteDriver fireDriver = new DeleteDriver();
            fireDriver.DeleteDriver(id);
        }
    }
}
