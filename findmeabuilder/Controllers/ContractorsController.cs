using System;
using System.Collections.Generic;
using findmeabuilder.Models;
using findmeabuilder.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace findmeabuilder.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _concs;

    public ContractorsController(ContractorsService concs)
    {
      _concs = concs;
    }
    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor contractorData)
    {
      try
      {
        Contractor contractor = _concs.Create(contractorData);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        List<Contractor> contractors = _concs.GetAll();
        return Ok(contractors);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> GetById(int id)
    {
      try
      {
        Contractor contractor = _concs.GetById(id);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Remove(int id)
    {
      try
      {
        _concs.Remove(id);
        return Ok("deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}