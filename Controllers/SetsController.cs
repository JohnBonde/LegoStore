using System;
using System.Collections.Generic;
using LegoStore.Models;
using LegoStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegoStore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SetsController : ControllerBase
  {
    private readonly SetsService _ss;
    private readonly BricksService _bs;

    public SetsController(SetsService ss)
    {
      _ss = ss;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Set>> Get()
    {
      try
      {
        return Ok(_ss.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Set> Get(int id)
    {
      try
      {
        return Ok(_ss.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Set> Create([FromBody] Set newData)
    {
      try
      {
        return Ok(_ss.Create(newData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Set> Edit([FromBody] Set update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_ss.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_ss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}