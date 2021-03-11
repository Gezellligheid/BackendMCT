using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationAPI.Models;
using RegistrationAPI.Repositories;

namespace RegistrationAPI.Services
{
  public interface IRegistrationService
  {
    Task<List<VaccinationLocation>> GetLocations();
    Task<List<VaccinationRegistration>> GetRegistrations();
    Task<List<VaccinType>> GetTypes();
  }

  public class RegistrationService : IRegistrationService
  {
    private IVaccinLocationRepository _vaccinLocationRepo;
    private IVaccinTypeRepository _vaccinTypeRepo;
    private IVaccinRegistrationRepository _vaccinRegistrationRepo;

    public RegistrationService(IVaccinLocationRepository vaccinLocationRepository, IVaccinTypeRepository vaccinTypeRepository, IVaccinRegistrationRepository vaccinRegistrationRepository)
    {
      _vaccinLocationRepo = vaccinLocationRepository;
      _vaccinTypeRepo = vaccinTypeRepository;
      _vaccinRegistrationRepo = vaccinRegistrationRepository;
    }


    public async Task<List<VaccinationLocation>> GetLocations()
    {

      return await _vaccinLocationRepo.getLocations();

    }

    public async Task<List<VaccinationRegistration>> GetRegistrations()
    {

      return await _vaccinRegistrationRepo.GetRegistrations();

    }

    public async Task<List<VaccinType>> GetTypes()
    {

      return await _vaccinTypeRepo.getVaccinTypes();

    }
  }


}
