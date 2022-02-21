using System;
using System.Collections.Generic;
using vacationFriends.Models;
using vacationFriends.Services;
using Microsoft.AspNetCore.Mvc;

namespace vacationFriends.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _cs;
        public CruisesController(CruisesService cs)
        {
            _cs = cs;
        }

        // ANCHOR GET ALL
        [HttpGet]
        public ActionResult<List<Cruise>> getAll()
        {
            try
            {
                List<Cruise> cruises = _cs.getAll();
                return Ok(cruises);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Cruise> getById(int id)
        {
            try
            {

                Cruise cruise = _cs.getById(id);
                return Ok(cruise);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR CREATE
        [Authorize]
        [HttpPost]
        public ActionResult<Cruise> create([FromBody] Cruise newCruise)
        {
            try
            {
                Cruise cruise = _cs.create(newCruise);
                return Ok(cruise);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR EDIT
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Cruise> edit([FromBody] Cruise update, int id)
        {
            try
            {
                update.Id = id;
                Cruise cruise = _cs.edit(update);
                return Ok(cruise);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<string> remove(int id)
        {
            try
            {
                _cs.remove(id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}