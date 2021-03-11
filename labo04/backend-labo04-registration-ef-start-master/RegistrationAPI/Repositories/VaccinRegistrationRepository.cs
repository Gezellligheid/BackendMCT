using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.data;
using RegistrationAPI.Models;

namespace RegistrationAPI.Repositories
{
  public interface IVaccinRegistrationRepository
  {
    Task<List<VaccinationRegistration>> GetRegistrations();
  }

  public class VaccinRegistrationRepository : IVaccinRegistrationRepository
  {
    private IRegistrationContext _context;

    public VaccinRegistrationRepository(IRegistrationContext context)
    {
      _context = context;
    }

    public async Task<List<VaccinationRegistration>> GetRegistrations()
    {

      return await _context.VaccinationRegistrations.Include(r => r.VaccinType).ToListAsync();

    }
  }
}
