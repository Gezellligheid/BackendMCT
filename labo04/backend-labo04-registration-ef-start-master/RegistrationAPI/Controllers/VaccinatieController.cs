using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistrationAPI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Options;
using RegistrationAPI.data;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Services;

namespace RegistrationAPI.Controllers
{
 

    [ApiController] 
    public class VaccinatieController : ControllerBase
    {

        private IRegistrationService _registrationService;
        public VaccinatieController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }


        [HttpGet]
        [Route("/locations")]
        public async Task<List<VaccinationLocation>> GetLocations(){
            return await _registrationService.GetLocations();
        }

        [HttpGet]
        [Route("/vaccins")]
        public async Task<List<VaccinType>> GetVaccins(){
            return await _registrationService.GetTypes();
        }

        [HttpGet]
        [Route("/registrations")]
        public async Task<ActionResult<List<VaccinationRegistration>>> GetRegistrations(string date = ""){
            return await _registrationService.GetRegistrations();
        }

        [HttpPost]
        [Route("/registration")]
        public async Task<ActionResult<VaccinationRegistration>> AddRegistration(VaccinationRegistration registration){
            return new OkObjectResult(null);
            // await _context.VaccinationRegistrations.AddAsync(registration);
            // await _context.SaveChangesAsync();
            // return registration;
        }

    }
}
