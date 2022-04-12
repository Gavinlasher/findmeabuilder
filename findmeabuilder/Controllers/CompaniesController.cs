using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using findmeabuilder.Models;
using findmeabuilder.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace findmeabuilder.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompaniesController : ControllerBase
  {
    private readonly CompaniesService _cs;

    public CompaniesController(CompaniesService cs)
    {
      _cs = cs;
    }
    [HttpPost]
    public ActionResult<Companies> Create([FromBody] Companies CompanyData)
    {
      try
      {
        Companies companies = _cs.Create(CompanyData);
        return Ok(companies);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<List<Companies>> GetAll()
    {
      try
      {
        List<Companies> companies = _cs.GetAll();
        return Ok(companies);
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
        _cs.Remove(id);
        return Ok("deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Companies> GetById(int id)
    {
      try
      {
        Companies company = _cs.GetById(id);
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}