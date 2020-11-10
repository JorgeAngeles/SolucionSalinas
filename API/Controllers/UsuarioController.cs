using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*",headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class UsuarioController : ApiController
    {
        
        // GET: api/Usuario
        public IHttpActionResult GetALL()
        {
            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                return Ok(result); 
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
