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
using ArmyRosterAPI.Commands;
using MediatR;


namespace ArmyRosterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RostersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RostersController(IMediator mediator)
        {
            _mediator = mediator;
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
                var query = new GetRosterByIdQuery(id);
                var result = await _mediator.Send(query);

                if (result != null)
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

                var command = new UpdateExistingRosterCommand(roster, id);
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound($"Applicant with id = {id} not found");
                }

                return Ok(result);
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
                var command = new CreateNewRosterCommand(roster);
                var result = await _mediator.Send(command);

                if (roster == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetRoster), new { id = result.Id }, result);
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
                var command = new DeleteExistingRosterCommand(id);
                var result = await _mediator.Send(command);

                if(result != null)
                {
                    return Ok();
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
