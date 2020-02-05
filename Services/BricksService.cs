using System;
using System.Collections.Generic;
using LegoStore.Models;
using LegoStore.Repositories;

namespace LegoStore.Services
{
  public class BricksService
  {
    private readonly BricksRepository _repo;
    public BricksService(BricksRepository br)
    {
      _repo = br;
    }
    internal IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }
    internal Brick GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal Brick Create(Brick newData)
    {
      _repo.Create(newData);
      return newData;
    }
    internal Brick Edit(Brick update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      _repo.Edit(update);
      return update;
    }
    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}