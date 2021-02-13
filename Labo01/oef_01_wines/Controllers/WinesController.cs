using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oef_01_wines.models;

namespace oef_01_wines.Controllers
{

    [ApiController]
    [Route("wines")]
    public class WinesController : ControllerBase
    {
        private readonly ILogger<WinesController> _logger;
        private readonly static List<Wine> _wines = new List<Wine>();

        public WinesController(ILogger<WinesController> logger){
            _logger = logger;

            if(_wines == null || _wines.Count == 0){
                _wines.Add(new Wine(){
                    Id = 1,
                    Name = "Sangrato Barolo",
                    Country = "Italia",
                    Price = 35,
                    Color = "Red",
                    Year = 2005,
                    Grapes = "Nebiollo"
                });
            }
        }


        [HttpGet]
        [Route("")]
        public ActionResult GetWines(){
            try
            {
                return new OkObjectResult(_wines);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpPost]
        [Route("")]
        public ActionResult PostWine(Wine wine){
            try
            {
                wine.Id = _wines.Count + 1;
                _wines.Add(wine);
                return new OkObjectResult(wine);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
            

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteWine(int id){
            // Find object with id x
            Wine _wine = _wines.Find(delegate(Wine w){
                return w.Id == id;
            });
            
            
            // Check if object has found
            if(_wine != null){

                _wines.Remove(_wine);
                return new OkObjectResult(_wine);

            }
            else{
                return new StatusCodeResult(404);
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult PutWine(Wine wine){
            // Find object with id x
            Wine _wine = _wines.Find(delegate(Wine w){
                return w.Id == wine.Id;
            });
            
            // Check if object has found
            if(_wine != null){

                _wine.Name = wine.Name;
                return new OkObjectResult(_wine);

            }
            else{
                return new StatusCodeResult(404);
            }
        }
    }
}
