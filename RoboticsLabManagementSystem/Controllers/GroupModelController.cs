using Microsoft.AspNetCore.Mvc;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Insfastructure.DataSeeder;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupModelController : ControllerBase
    {
        private static List<Group> _groupModels = GroupModelSeed.GetSeedData();

        // GET: api/GroupModel
        [HttpGet]
        public ActionResult<IEnumerable<Group>> Get()
        {
            return Ok(_groupModels);
        }

        // GET: api/GroupModel/{id}
        [HttpGet("{id}")]
        public ActionResult<Group> Get(Guid id)
        {
            var group = _groupModels.Find(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        // POST: api/GroupModel
        [HttpPost]
        public ActionResult<Group> Post([FromBody] Group newGroup)
        {
            newGroup.Id = Guid.NewGuid();
            _groupModels.Add(newGroup);
            return CreatedAtAction(nameof(Get), new { id = newGroup.Id }, newGroup);
        }

        // PUT: api/GroupModel/{id}
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Group updatedGroup)
        {
            var group = _groupModels.Find(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            group.Name = updatedGroup.Name;
            return NoContent();
        }

        // DELETE: api/GroupModel/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var group = _groupModels.Find(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            _groupModels.Remove(group);
            return NoContent();
        }
    }
}