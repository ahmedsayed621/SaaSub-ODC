using Microsoft.AspNetCore.Mvc;
using PricingPlans.API.Data.Services;
using PricingPlans.API.DTOs;

namespace PricingPlans.API.Controllers
{
    [Route("api/plans")]
    public class PlansController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IPlanService _service;
        public PlansController(IPlanService service)
        {
            _service = service;
            this._response = new ResponseDto();

        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PlanDto> planDtos = await _service.GetPlans();
                _response.Result = planDtos;
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
                var plan = await _service.GetPlanById(id);
                _response.Result = plan;
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
        public async Task<object> Post([FromBody] PlanDto plan)
        {
            try
            {


                PlanDto model = await _service.CreateUpdatePlan(plan);
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
        public async Task<object> Put([FromBody] PlanDto planDto)
        {
            try
            {
                PlanDto model = await _service.CreateUpdatePlan(planDto);
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
                bool isSuccess = await _service.DeletePlan(id);
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
