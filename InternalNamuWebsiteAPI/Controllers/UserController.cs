using InternalNamuWebsiteAPI.Context;
using InternalNamuWebsiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace InternalNamuWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : Controller
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.User.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult Get(int id)
        {
            try
            {
                var user = context.User.FirstOrDefault(g => g.Id == id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                context.User.Add(user);
                context.SaveChanges();
                return CreatedAtRoute("GetUser", new { id = user.Id }, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (user.Id == id)
                {
                    context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUser", new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = context.User.FirstOrDefault(g => g.Id == id);
                if (user != null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
