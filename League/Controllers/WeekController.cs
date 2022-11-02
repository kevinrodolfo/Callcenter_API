using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Callcenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        // GET: api/<TeamController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            //headers
            string username = Request.Headers["username"];
            string token = Request.Headers["token"];

            //check if security headers were received
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(token))
            {
                //validate token
                if (Security.ValidateToken(username, token))
                {
                    WeekListViewModel vm = new WeekListViewModel();
                    vm.Status = 0;
                    vm.Weeks = Week.GetAll();
                    return Ok(vm);
                }
                else
                    return Ok(Security.GetError(Enumerators.SecurityError.InvalidToken));
            }
            else
                return Ok(Security.GetError(Enumerators.SecurityError.MissingOrEmptySecurityHeaders));
        }
        // GET api/<WeekController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeekController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeekController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeekController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
