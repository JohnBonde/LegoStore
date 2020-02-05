using System.Collections.Generic;
using System.Data;
using Dapper;
using LegoStore.Models;

namespace LegoStore.Repositories
{
  public class BricksRepository
  {
    private readonly IDbConnection _db;
    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Brick> Get()
    {
      string sql = "SELECT * FROM bricks";
      return _db.Query<Brick>(sql);
    }
    internal Brick GetById(int Id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id";
      return _db.QueryFirstOrDefault<Brick>(sql, new { Id });
    }
    internal Brick Create(Brick newData)
    {
      string sql = @"
      INSERT INTO bricks
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
    internal void Edit(Brick update)
    {
      string sql = @"
      UPDATE bricks
      SET
      name = @Name,
      WHERE id = @Id;
      ";
      _db.Execute(sql, update);
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM bricks WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}