﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalAccounting.Api.Services.Interfaces;
using PersonalAccounting.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalAccounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUsersServices usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] UserDto user)
        {
            _logger.LogInformation("Enter to UsersController Post");

            var userId = await _usersService.CreateUserAsync(user);

            return userId;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
