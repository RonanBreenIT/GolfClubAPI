using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GolfClub.Models;

namespace GolfClub.Controllers
{
    [RoutePrefix("api/GolfClub")]
    public class GolfClubController : ApiController
    {
        private static List<Golfer> GolfersList = new List<Golfer>()
        {
            new Golfer() { GUI = 11111111, FirstName = "Ronan", Surname = "Breen", Handicap = 16, DateJoined = new DateTime(2018, 01, 01), Membership = MemberType.Student, YearlyFees = 270 },
            new Golfer() { GUI = 22222222, FirstName = "Simon", Surname = "Hughes", Handicap = 11, DateJoined = new DateTime(2017, 01, 01), Membership = MemberType.FullTime, YearlyFees = 1270 },
            new Golfer() { GUI = 33333333, FirstName = "Kevin", Surname = "Hearns", Handicap = 14, DateJoined = new DateTime(2011, 01, 01), Membership = MemberType.FullTime, YearlyFees = 1270 }
        };

        [HttpGet]
        [Route("all")]
        // GET: api/GolfClub/all
        public IEnumerable<Golfer> Get()
        {
            return GolfersList.OrderBy(p => p.DateJoined).ThenBy(c => c.FirstName).ThenBy(b => b.Surname).ThenBy(a => a.Handicap);
        }

        [HttpGet]
        [Route("GetByGUI/{GUI}")]
        // GET: api/GolfClub/GetByGUI/11111111
        public IHttpActionResult GetByGUI(int gui)
        {
            var foundGUI = GolfersList.FirstOrDefault(p => p.GUI == gui);
            if (foundGUI != null)
            {
                return Ok(foundGUI);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddMember")]
        // POST: api/GolfClub/AddMember
        public IHttpActionResult AddMember(Golfer newGolfer)
        {
            var foundgolfer = GolfersList.FirstOrDefault(p => p.GUI == newGolfer.GUI);
            if (foundgolfer != null)
            {
                return BadRequest("Sorry a Golfer with this GUI already exists");
            }
            else
            {
                GolfersList.Add(newGolfer);
                return Ok();
            }
        }

        [HttpPut]
        [Route("UpdateMember/{gui}")]
        // PUT: api/GolfClub/UpdateMember/22222222
        public IHttpActionResult UpdateMember(int gui, [FromBody]Golfer updatedGolfer)
        {
            var foundgolfer = GolfersList.FirstOrDefault(p => p.GUI == gui);
            if (foundgolfer == null)
            {
                return BadRequest("No Golfers with that GUI are in the GolfClub Database");
            }
            else
            {
                foundgolfer.FirstName = updatedGolfer.FirstName;
                foundgolfer.Surname = updatedGolfer.Surname;
                foundgolfer.Membership = updatedGolfer.Membership;
                foundgolfer.Handicap = updatedGolfer.Handicap;
                foundgolfer.DateJoined = updatedGolfer.DateJoined;
                foundgolfer.YearlyFees = updatedGolfer.YearlyFees;
                return Ok();
            }
        }


        [HttpDelete]
        [Route("DeleteMember/{gui}")]
        // DELETE: api/GolfClub/5
        public IHttpActionResult DeleteMember(int gui)
        {
            var foundgolfer = GolfersList.FirstOrDefault(p => p.GUI == gui);
            if (foundgolfer == null)
            {
                return BadRequest("No Golfers with that GUI are in the GolfClub Database");
            }
            else
            {
                GolfersList.Remove(foundgolfer);
                return Ok();
            }
        }
    }
}
