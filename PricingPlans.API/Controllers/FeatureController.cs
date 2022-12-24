using Microsoft.AspNetCore.Mvc;
using PricingPlans.API.Data.Services;
using PricingPlans.API.DTOs;
using PricingPlans.API.model;

namespace PricingPlans.API.Controllers
{
    [Route("api/features")]
    public class FeatureController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IFeatureService _service;
        public FeatureController(IFeatureService service) 
        {
            _service= service;
            this._response = new ResponseDto();

        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<FeatureDto> featureDtos = await _service.GetFeatures();
                _response.Result = featureDtos;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                 var feature= await _service.GetFeatureById(id);
                _response.Result = feature;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] FeatureDto feat)
        {
            try
            {
                

                FeatureDto model=await _service.CreateUpdateProduct(feat);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] FeatureDto featureDto)
        {
            try
            {
                FeatureDto model = await _service.CreateUpdateProduct(featureDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _service.DeleteFeature(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return _response;
        }


    }
}
