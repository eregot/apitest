using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private static List<Team> teams = new List<Team>()
        {
            new Team()
            {
                Country = "Germany",
                Id = 1,
                Name = "Mercedes AMG F1",
                Principal = "Toto Wolff"
            },
            new Team()
            {
                Country = "Italy",
                Id = 2,
                Name = "Scuderia Ferrari",
                Principal = "Mattia Binotto"
            },
            new Team()
            {
                Country = "Austria",
                Id = 3,
                Name = "Red Bull Racing RBPT",
                Principal = "Christian Horner"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);

            if (team == null)
                return BadRequest("Invalid Id");

            return Ok(team);
        }

        [HttpPost]
        public IActionResult Post(Team team)
        {
            teams.Add(team);

            return CreatedAtAction("Get", team.Id, team);
        }

        [HttpPatch]
        public IActionResult Patch(int id, string country)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);

            if (team == null)
                return BadRequest("invalid id");

            team.Country = country;

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var team = teams.FirstOrDefault(x => x.Id == id);

            if (team == null)
                return BadRequest("invalid id");

            teams.Remove(team);

            return NoContent();
        }

    }
}

