using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
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
        [HttpGet(Name="GetDrivers")]
        [EnableCors("OpenPolicy")]
        public List<Driver> Get()  //Show all drivers
        {
            IGetAll readObject = new DriverDataAccess();
            return readObject.GetAll();
        }

        // GET: api/Driver/ //how you pass things on url
        [HttpGet("{id}", Name = "GetDriver")]
        [EnableCors("OpenPolicy")]
        public Driver Get(int id)
        {
            IGetDriver readObject = new DriverDataAccess();
            return readObject.GetDriver(id);
        }

        // POST: api/Driver //create //hire driver
        [HttpPost( Name = "CreateDriver")]
        [EnableCors("OpenPolicy")]
        public void Post([FromBody] Driver value)
        {
            ICreateDriver hireDriver = new CreateDriver();
            hireDriver.CreateDriver(value);
        }

        // PUT: api/Driver/5 //edit driver rating
        [HttpPut( Name = "EditDriver")]
        [EnableCors("OpenPolicy")]
        public void Put(Driver driver)
        {
            IUpdateDriverRating editRating = new UpdateDriverRating();
            editRating.UpdateDriverRating(driver);
        }

        // DELETE: api/Driver/5 //fire driver
        [HttpDelete("{id}", Name="DeleteDriver")]
        [EnableCors("OpenPolicy")]
        public void Delete(int id)
        {
            IDeleteDriver fireDriver = new DeleteDriver();
            fireDriver.DeleteDriver(id);
        }
    }
}
