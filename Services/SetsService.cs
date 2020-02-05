using System;
using System.Collections.Generic;
using LegoStore.Models;
using LegoStore.Repositories;

namespace LegoStore.Services
{
  public class SetsService
  {
    private readonly SetsRepository _repo;
    public SetsService(SetsRepository sr)
    {
      _repo = sr;
    }
    internal IEnumerable<Set> Get()
    {
      return _repo.Get();
    }
    internal Set GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }
    internal Set Create(Set newData)
    {
      _repo.Create(newData);
      return newData;
    }
    internal Set Edit(Set update)
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
    internal IEnumerable<Set> GetByBrickId(int brickId)
    {
      return _repo.GetSetsByBrickId(brickId);
    }
  }
}