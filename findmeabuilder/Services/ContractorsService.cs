using System;
using System.Collections.Generic;
using findmeabuilder.Models;

namespace findmeabuilder.Repositories
{
  public class ContractorsService
  {
    private readonly ContractorsRepository concs_repo;

    public ContractorsService(ContractorsRepository concs_repo)
    {
      this.concs_repo = concs_repo;
    }

    internal Contractor Create(Contractor contractorData)
    {
      return concs_repo.Create(contractorData);
    }

    internal Contractor GetById(int id)
    {
      Contractor found = GetById(id);
      if (found == null)
      {
        throw new Exception("invaild Id");
      }
      return found;
    }

    internal List<Contractor> GetAll()
    {
      return concs_repo.GetAll();
    }

    internal string Remove(int id)
    {
      return concs_repo.Remove(id);
    }
  }
}