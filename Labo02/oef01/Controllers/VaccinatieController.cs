using System.Runtime.CompilerServices;
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
using AutoMapper;

namespace oef01.Controllers
{   
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class VaccinatieController : ControllerBase
    {
        private CSVSettings _CSVSettings;
        public static ILogger<VaccinatieController> _logger;
        public static List<VaccinatieLocatie> _locaties = new List<VaccinatieLocatie>();
        public static List<VaccinatieType> _types = new List<VaccinatieType>();
        public static List<Vaccinatie> _registratiess = new List<Vaccinatie>();

        public static IMapper _mapper;
        public CsvConfiguration configuration;
        public VaccinatieController(ILogger<VaccinatieController> logger, IOptions<CSVSettings> settings, IMapper mapper)
        {   
            _mapper = mapper;
            _CSVSettings = settings.Value;
            _logger = logger;
            configuration = new CsvConfiguration(CultureInfo.InvariantCulture){
                    HasHeaderRecord = false,
                    Delimiter = ";"
                };
            if (_locaties.Count == 0)
            {
                
                using(var reader = new StreamReader(_CSVSettings.CSVLocations))
                using(var csv = new CsvReader(reader, configuration)){

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
                using(var csv = new CsvReader(reader, configuration)){

                    // csv.Read();
                    while(csv.Read()){
                        var record = csv.GetRecord<VaccinatieType>();
                        _types.Add(record);
                    }
                    
                }
            }

            if (_registratiess.Count == 0)
            {
                using(var reader = new StreamReader(_CSVSettings.CSVRegistraties))
                using(var csv = new CsvReader(reader, configuration)){

                    // csv.Read();
                    while(csv.Read()){
                        var record = csv.GetRecord<Vaccinatie>();
                        _registratiess.Add(record);
                    }
                    
                }
            }
        }

        private void saveRegistration(Vaccinatie vaccinatie){

            using(var reader = new StreamWriter(_CSVSettings.CSVRegistraties))
            using(var csv = new CsvWriter(reader, configuration)){

                csv.WriteRecord(vaccinatie);
                
                
            }

        }

        [HttpPost]
        [Route("registration")]
        public ActionResult<Vaccinatie> AddRegistratie(Vaccinatie vaccinatie){
            vaccinatie.VaccinatieRegistratieId = Guid.NewGuid();
            _registratiess.Add(vaccinatie);
            saveRegistration(vaccinatie);
            return new OkObjectResult(vaccinatie);

        } 

        [HttpGet]
        [Route("registrations")]
        [MapToApiVersion("2.0")]
        public ActionResult<List<VaccinatieDTO>> GetRegistrationsv2(){
            return _mapper.Map<List<VaccinatieDTO>>(_registratiess);
        } 

        [HttpGet]
        [Route("registrations")]
        [MapToApiVersion("1.0")]
        public ActionResult<List<Vaccinatie>> GetRegistrations(string date = ""){
            if(string.IsNullOrEmpty(date)){
                 return new OkObjectResult(_registratiess);

            }
            else{
                return new OkObjectResult(_registratiess.Find(Vaccinatie => Vaccinatie.PrikDatum == date));
            }

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
