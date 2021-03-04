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


namespace RegistrationAPI.Controllers
{
 

    [ApiController] 
    public class VaccinatieController : ControllerBase
    {

        public VaccinatieController()
        {
 
        }


        [HttpGet]
        [Route("/locations")]
        public List<VaccinationLocation> GetLocations(){
            return null;
        }

        [HttpGet]
        [Route("/vaccins")]
        public List<VaccinType> GetVaccins(){
            return null;
        }

        [HttpGet]
        [Route("/registrations")]
        public ActionResult<List<VaccinationRegistration>> GetRegistrations(string date = ""){
            return Ok();
        }

        [HttpPost]
        [Route("/registration")]
        public ActionResult<VaccinationRegistration> AddRegistration(VaccinationRegistration registration){
            
            return null;
        }

    }
}
