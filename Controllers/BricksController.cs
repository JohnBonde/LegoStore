using System;
using System.Collections.Generic;
using LegoStore.Models;
using LegoStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegoStore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BricksController : ControllerBase
  {
    private readonly BricksService _bs;
    private readonly SetsService _ss;

    public BricksController(BricksService bs, SetsService ss)
    {
      _bs = bs;
      _ss = ss;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Brick> Get(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/sets")]
    public ActionResult<IEnumerable<Set>> GetSets(int id)
    {
      try
      {
        return Ok(_ss.GetByBrickId(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Brick> Create([FromBody] Brick newData)
    {
      try
      {
        return Ok(_bs.Create(newData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Brick> Edit([FromBody] Brick update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_bs.Edit(update));
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
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}