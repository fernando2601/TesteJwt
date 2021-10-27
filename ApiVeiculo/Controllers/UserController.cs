using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVeiculo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService service;

        public UserController(UserService _service)
        {
            service = _service;
        }

     
     [HttpGet]
     public ActionResult<List<User>> GetUsers()
        {
            try
            {
                return service.GetUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }


     
     [HttpGet("{id}")]
     public ActionResult<User> GetUser(string id)
        {
            try
            {
                var user = service.GetUser(id);

                return Json(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult<User> Create(User user)
        {
            try
            {
                service.Create(user);

                return Json(user);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    
    [AllowAnonymous]
    [Route("Authenticate")]
    [HttpPost]

    public ActionResult Login( [FromBody] User user)
        {
            try
            {
                var token = service.Authenticate(user.Email, user.Password);

                if (token == null)
                    return Unauthorized();

                return Ok(new { token, user });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }


    }
}
