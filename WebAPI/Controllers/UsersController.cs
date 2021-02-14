using Business.Absract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userService.GetByUserId(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByName(string name)
        {
            var result = _userService.GetByName(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByFirstName(string name)
        {
            var result = _userService.GetByFirstName(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByLastName(string name)
        {
            var result = _userService.GetByLastName(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByEMail(string eMail)
        {
            var result = _userService.GetByEMail(eMail);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
