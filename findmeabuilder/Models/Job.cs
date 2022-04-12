using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace findmeabuilder.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public int ContractorId { get; set; }
  }
}