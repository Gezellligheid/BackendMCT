using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oef_02_cars.Models;

namespace oef_02_cars.Controllers
{
    [ApiController]
    [Route("api")]
    public class BrandController : ControllerBase
    {
        private static List<Brand> _brands = new List<Brand>();
        private static List<CarModel> _carModels = new List<CarModel>();
        private readonly ILogger<BrandController> _logger;
        public BrandController(ILogger<BrandController> logger){
            _logger = logger;
            if(_brands == null || _brands.Count == 0){
                Brand Suzuki = new Brand(){
                    BrandId = 0,
                    Country = "japan",
                    Name="Suzuki"
                };
                _brands.Add(Suzuki);
                Brand Volkswagen = new Brand(){
                    BrandId = 1,
                    Country = "belgium",
                    Name="Volkswagen"
                };
                _brands.Add(Volkswagen);
            }
            
            if(_carModels == null || _carModels.Count == 0){
                CarModel Swift = new CarModel(){
                    CarModelId = 0,
                    Name = "Swift",
                    Brand = _brands.Find(b => b.Name == "Suzuki")
                };
                _carModels.Add(Swift);
                CarModel Alto = new CarModel(){
                    CarModelId = 1,
                    Name = "Alto",
                    Brand = _brands.Find(b => b.Name == "Suzuki")  
                };
                _carModels.Add(Alto);

                CarModel Polo = new CarModel(){
                    CarModelId = 2,
                    Name = "Polo",
                    Brand = _brands.Find(b => b.Name == "Volkswagen")
                };
                _carModels.Add(Polo);
                CarModel Tiguan = new CarModel(){
                    CarModelId = 3,
                    Name = "Tiguan  ",
                    Brand = _brands.Find(b => b.Name == "Volkswagen")  
                };
                _carModels.Add(Tiguan);

                
            }
            
        }

        [HttpGet]
        [Route("brands")]
        public ActionResult GetBrands(string country = ""){
            
            try
            {
                if(country != ""){  

                    List<Brand> x = _brands.Where(b => b.Country == country).ToList();

                    return new OkObjectResult(x);

                }

                return new OkObjectResult(_brands);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpPost]
        [Route("brands")]
        public ActionResult PostBrand(Brand brand){
            try
            {   
                if(brand != null){
                    brand.BrandId = _brands.Count +1;
                    _brands.Add(brand);
                    return new OkObjectResult(brand);
                }
                return new BadRequestResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("brands/{brandId}")]
        public ActionResult GetBrandbyId(int brandId){
            try
            {   
                Brand brand = _brands.Find(b => b.BrandId == brandId);
                if(brand != null){

                    return new OkObjectResult(brand);

                }
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("models")]
        public ActionResult GetModels(string country = ""){
            try
            {   
                if(country == ""){
                    return new OkObjectResult(_carModels);

                }
                else{
                    List<CarModel> models = _carModels.FindAll(c => c.Brand.Country == country);
                    return new OkObjectResult(models);

                }
                
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("models/{brandId}")]
        public ActionResult GetModelByBrandId(int brandId){
            try
            {   
                List<CarModel> models = _carModels.Where(c => c.Brand.BrandId == brandId).ToList();
                if(models != null){
                    return new OkObjectResult(models);
                }
                else{
                    return new NotFoundResult();
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("model/{modelId}")]
        public ActionResult GetModelByid(int modelId){
            try
            {   
                
                CarModel models = _carModels.Find(c => c.CarModelId == modelId);
                return new OkObjectResult(models);
            
            
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

    }
}
