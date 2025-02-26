using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreApp.Server.Controllers;

   
    public class UserController : BaseAPIController
    {
      [HttpGet("{id}")] 
        public IActionResult Users(string id)
        {
            return Ok(new { idd = id });
        }
    }
