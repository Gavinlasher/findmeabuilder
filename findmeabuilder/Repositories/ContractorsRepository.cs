using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using findmeabuilder.Models;

namespace findmeabuilder.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Contractor Create(Contractor contractorData)
    {
      string sql = @"
    INSERT INTO contractors
    (name)
    VALUE
    (@Name);
    SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, contractorData);
      contractorData.Id = id;
      return contractorData;
    }

    internal List<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql).ToList();
    }

    internal string Remove(int id)
    {
      string sql = @"
        DELETE FROM companies WHERE id = @id LIMIT 1;
      ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("could not delete");
    }
    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
  }
}