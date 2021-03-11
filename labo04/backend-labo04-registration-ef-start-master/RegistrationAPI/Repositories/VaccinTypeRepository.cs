using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.data;
using RegistrationAPI.Models;

namespace RegistrationAPI.Repositories
{
  public interface IVaccinTypeRepository
  {
    Task<List<VaccinType>> getVaccinTypes();
  }

  public class VaccinTypeRepository : IVaccinTypeRepository
  {

    private IRegistrationContext _context;
    public VaccinTypeRepository(IRegistrationContext context)
    {

      _context = context;

    }

    public async Task<List<VaccinType>> getVaccinTypes()
    {

      return await _context.VaccinTypes.ToListAsync();

    }
  }
}
