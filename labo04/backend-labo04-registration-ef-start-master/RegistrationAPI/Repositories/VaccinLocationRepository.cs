using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.data;
using RegistrationAPI.Models;

namespace RegistrationAPI.Repositories
{
  public interface IVaccinLocationRepository
  {
    Task<List<VaccinationLocation>> getLocations();
  }

  public class VaccinLocationRepository : IVaccinLocationRepository
  {
    private IRegistrationContext _context;

    public VaccinLocationRepository(IRegistrationContext context)
    {
      _context = context;
    }

    public async Task<List<VaccinationLocation>> getLocations()
    {

      return await _context.VaccinationLocations.ToListAsync();

    }

  }
}
