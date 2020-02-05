using System.Collections.Generic;
using System.Data;
using Dapper;
using LegoStore.Models;

namespace LegoStore.Repositories
{
  public class SetsRepository
  {
    private readonly IDbConnection _db;
    public SetsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Set> Get()
    {
      string sql = "SELECT * FROM sets";
      return _db.Query<Set>(sql);
    }
    internal Set GetById(int Id)
    {
      string sql = "SELECT * FROM sets WHERE id = @id";
      return _db.QueryFirstOrDefault<Set>(sql, new { Id });
    }
    internal Set Create(Set newData)
    {
      string sql = @"
      INSERT INTO sets
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
    internal void Edit(Set update)
    {
      string sql = @"
      UPDATE sets
      SET
      name = @Name,
      WHERE id = @Id;
      ";
      _db.Execute(sql, update);
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM sets WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
    internal IEnumerable<Set> GetSetsByBrickId(int brickId)
    {
      string sql = @"
      SELECT s.*
      FROM setbricks sb
      JOIN sets s ON s.id = sb.setId
      WHERE brickId = @brickId;";
      return _db.Query<Set>(sql, new { brickId });
    }
  }
}