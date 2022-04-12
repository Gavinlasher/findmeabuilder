using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using findmeabuilder.Models;
using findmeabuilder.Repositories;

namespace findmeabuilder.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository cs_repo;

    public CompaniesService(CompaniesRepository cs_repo)
    {
      this.cs_repo = cs_repo;
    }

    internal Companies Create(Companies companyData)
    {
      return cs_repo.Create(companyData);
    }

    internal List<Companies> GetAll()
    {
      return cs_repo.GetAll();
    }
    internal string Remove(int id)
    {
      return cs_repo.Remove(id);
    }

    internal Companies GetById(int id)
    {
      Companies found = cs_repo.GetById(id);
      if (found == null)
      {
        throw new Exception("invaild id");
      }
      return found;
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}