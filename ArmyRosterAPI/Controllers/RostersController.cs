using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmyRosterAPI.AccessDataBases;
using ArmyRosterAPI.Models;
using ArmyRosterAPI.Querys;
using MediatR;
using ArmyRosterAPI.Interfaces.Repository;

namespace ArmyRosterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RostersController : ControllerBase
    {
        private readonly ArmyRosterContext _context;

        private readonly IMediator _mediator;

        private readonly IRosterRepository _rosterRepository;

        public RostersController(ArmyRosterContext context, IMediator mediator, IRosterRepository rosterRepository)
        {
            _context = context;
            _mediator = mediator;
            _rosterRepository = rosterRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roster>>> GetAllRosters()
        {
            try
            {
                var query = new GetAllRostersQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Accessing database error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Roster>> GetRoster(int id)
        {
            try
            {
                var result = await _rosterRepository.GetRosterById(id);

                if(result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Accessing database error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roster"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Roster>> PutRoster(int id, Roster roster)
        {
            try
            {
                if (id != roster.Id)
                {
                    return BadRequest("Wrong roster ID");
                }

                var rosterToUpdate = await _rosterRepository.GetRosterById(id);

                if (rosterToUpdate == null)
                {
                    return NotFound($"Applicant with id = {id} not found");
                }

                return await _rosterRepository.UpdateRoster(id, roster);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Updating applicant error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Roster"></param>
        /// <returns>Roster with specyfic Id</returns>
        [HttpPost]
        public async Task<ActionResult<Roster>> PostRoster(Roster roster)
        {
            try
            {
                if (roster == null)
                {
                    return BadRequest();
                }

                var createdRoster = await _rosterRepository.CreateRoster(roster);

                return CreatedAtAction(nameof(GetRoster), new { id = createdRoster.Id }, createdRoster);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Accessing database error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Roster>> DeleteRoster(int id)
        {
            try
            {
                var result = await _rosterRepository.GetRosterById(id);

                if(result != null)
                {
                    return Ok(await _rosterRepository.DeleteRoster(id));
                }

                return BadRequest("Nie istnieje roster o takim Id");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Accessing database error!");
            }
        }

    }
}
