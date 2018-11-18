using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.Application.Contracts;
using KP.Domain.Entities;
using KP.Domain.Entities.Extensions;
using KP.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KP.Presentation.UI.Controllers
{
  [Route("api/[controller]")]
  public class OwnerController : Controller
  {
    private ILoggerManager _logger;
    private readonly IOwnerService _ownerService;
    private readonly IAccountService _accountService;

    public OwnerController(ILoggerManager logger, IOwnerService ownerService, IAccountService accountService)
    {
      _logger = logger;
      _ownerService = ownerService;
      _accountService = accountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOwners()
    {
      try
      {
        var owners = await _ownerService.GetAllOwners();

        _logger.LogInfo($"Returned all owners from database.");

        return Ok(owners);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpGet("{id}"), ActionName("OwnerById")]
    public async Task<IActionResult> GetOwnerById(Guid id)
    {
      try
      {
        var owner = await _ownerService.GetOwnerById(id);

        if (owner.IsObjectNull())
        {
          _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
          return NotFound();
        }

        _logger.LogInfo($"Returned owner with id: {id}");
        return Ok(owner);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpGet("{id}/account")]
    public async Task<IActionResult> GetOwnerWithDetails(Guid id)
    {
      try
      {
        var owner = await _ownerService.GetOwnerWithDetails(id);

        if (owner.IsEmptyObject())
        {
          _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
          return NotFound();
        }
        else
        {
          _logger.LogInfo($"Returned owner with details for id: {id}");
          return Ok(owner);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOwner([FromBody]Owner owner)
    {
      try
      {
        if (owner.IsObjectNull())
        {
          _logger.LogError("Owner object sent from client is null.");
          return BadRequest("Owner object is null");
        }

        if (!ModelState.IsValid)
        {
          _logger.LogError("Invalid owner object sent from client.");
          return BadRequest("Invalid model object");
        }

        await _ownerService.CreateOwner(owner);

        return CreatedAtAction("OwnerById", new { id = owner.Id }, owner);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOwner(Guid id, [FromBody]Owner owner)
    {
      try
      {
        if (owner.IsObjectNull())
        {
          _logger.LogError("Owner object sent from client is null.");
          return BadRequest("Owner object is null");
        }

        if (!ModelState.IsValid)
        {
          _logger.LogError("Invalid owner object sent from client.");
          return BadRequest("Invalid model object");
        }

        var dbOwner = await _ownerService.GetOwnerById(id);
        if (dbOwner.IsEmptyObject())
        {
          _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
          return NotFound();
        }

        await _ownerService.UpdateOwner(dbOwner, owner);

        return NoContent();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOwner(Guid id)
    {
      try
      {
        var owner = await _ownerService.GetOwnerById(id);
        if (owner.IsEmptyObject())
        {
          _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
          return NotFound();
        }

        var accounts = await _accountService.AccountsByOwner(id);
        if (accounts.Any())
        {
          _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
          return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
        }

        await _ownerService.DeleteOwner(owner);

        return NoContent();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
        return StatusCode(500, "Internal server error");
      }
    }
  }
}
