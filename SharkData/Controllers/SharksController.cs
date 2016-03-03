using System.Collections.Generic;
using System.Web.Http;
using SharkData.Models;

namespace SharkData.Controllers
{
    public class SharksController : ApiController
    {
        // GET api/sharks
        public IEnumerable<Shark> Get()
        {
            return SharkEntity.GetShark();
        }

        // GET api/sharks/5
        public Shark Get(int id)
        {
            return SharkEntity.GetShark(id);
        }

        // PUT api/sharks/5
        public Shark Put(int id, [FromBody]Shark newShark)
        {
            return SharkEntity.ModifyShark(id, newShark);
        }
    }
}
