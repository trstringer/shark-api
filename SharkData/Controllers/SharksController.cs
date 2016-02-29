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
            return Shark.GetShark();
        }

        // GET api/sharks/5
        public Shark Get(int id)
        {
            return Shark.GetShark(id);
        }
    }
}
