using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using findmeabuilder.Models;

namespace findmeabuilder.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Companies Create(Companies companyData)
    {
      string sql = @"
    INSERT INTO companies
    (name)
    VALUE
    (@Name);
    SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, companyData);
      companyData.Id = id;
      return companyData;
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

    internal List<Companies> GetAll()
    {
      string sql = "SELECT * FROM companies;";
      return _db.Query<Companies>(sql).ToList();
    }

    internal Companies GetById(int id)
    {
      string sql = "SELECT * FROM companies WHERE id = @id;";
      return _db.QueryFirstOrDefault<Companies>(sql, new { id });
    }
  }
}
