using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oef01.Models;
using CsvHelper;
using CsvHelper.Configuration;
using oef01.Configuration;
using Microsoft.Extensions.Options;

namespace oef01.Controllers
{   
    [ApiController]
    public class VaccinatieController : ControllerBase
    {
        private CSVSettings _CSVSettings;
        public static ILogger<VaccinatieController> _logger;
        public static List<VaccinatieLocatie> _locaties = new List<VaccinatieLocatie>();
        public static List<VaccinatieType> _types = new List<VaccinatieType>();
        public static List<Vaccinatie> _registratiess = new List<Vaccinatie>();

        public VaccinatieController(ILogger<VaccinatieController> logger, IOptions<CSVSettings> settings)
        {
            _CSVSettings = settings.Value;
            _logger = logger;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture){
                    HasHeaderRecord = false,
                    Delimiter = ";"
                };
            if (_locaties.Count == 0)
            {
                
                using(var reader = new StreamReader(_CSVSettings.CSVLocations))
                using(var csv = new CsvReader(reader, config)){

                    // csv.Read();
                    while(csv.Read()){
                        var record = csv.GetRecord<VaccinatieLocatie>();
                        _locaties.Add(record);
                    }
                    
                }
            }

            if (_types.Count == 0)
            {
                using(var reader = new StreamReader(_CSVSettings.CSVTypes))
                using(var csv = new CsvReader(reader, config)){

                    // csv.Read();
                    while(csv.Read()){
                        var record = csv.GetRecord<VaccinatieType>();
                        _types.Add(record);
                    }
                    
                }
            }



        }

        [HttpPost]
        [Route("registration")]
        public ActionResult<Vaccinatie> AddRegistratie(Vaccinatie vaccinatie){
            vaccinatie.VaccinatieRegistratieId = Guid.NewGuid();
            _registratiess.Add(vaccinatie);
            return new OkObjectResult(vaccinatie);

        } 

        [HttpGet]
        [Route("registrations")]
        public ActionResult<List<Vaccinatie>> GetRegistrations(){
            return new OkObjectResult(_registratiess);

        } 


        [HttpGet]
        [Route("locaties")]
        public ActionResult<List<VaccinatieLocatie>> GetVaccinatieLocaties()
        {
            
            return new OkObjectResult(_locaties);

        }


        [HttpGet]
        [Route("types")]
        public ActionResult<List<VaccinatieType>> GetVaccinatieTypes()
        {

            return new OkObjectResult(_types);

        }
    }
}
