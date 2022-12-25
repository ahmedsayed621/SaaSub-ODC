using BLL.Spcefication.ContactUs;
using ContactUs.API.BLL.InterFaces;
using ContactUs.API.Model;
using ContactUs.API.Errors;

using ContactUs.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactUs.API.data;
using Talabat.API.Errors;
using ContactUs.API.DTO;

namespace ContactUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsInfoController : ControllerBase
    {
        protected ContactDTO _response;
        private readonly IGenercRepositry<ContactInfo> repositry;
        private readonly ApplicationDbContext context;

        public ContactUsInfoController( ApplicationDbContext _context  ,IGenercRepositry<ContactInfo> _repositry)
        {
            _repositry = repositry;
            _context=context;
            this._response = new ContactDTO();
        }

        [HttpGet("allData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ContactInfo>>> GetContactUs()
        {



            try
            {
              var ContactUs = await repositry.GetAllAsync();
                _response.Result = ContactUs;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return Ok(_response);




        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactInfo>> GetContactById(int  id)

        {

            try
            {
                var Contact = await repositry.GetDataByIdAsync(id);
                _response.Result = Contact;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };

            }
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErroeResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactInfo>> CreateContact([FromForm] ContactInfo contactUsInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var ContactUsInfo = new ContactInfo()
                {

                    FullName = contactUsInfo.FullName,
                    Company = contactUsInfo.Company,
                    Email = contactUsInfo?.Email,
                     Subject = contactUsInfo?.Subject,
                     Message = contactUsInfo?.Message,
                };

                await repositry.Add(ContactUsInfo);
              //  var result = await _unitOfWork.Complet();
              context.SaveChanges();    
              

                return Ok(ContactUsInfo);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpDelete("{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErroeResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactInfo>> DeleteContact(string Name)
        {
            var User = await repositry.GetDataByNameAsync(Name);

            if (User == null)

                return BadRequest("Cant Find This User");

            repositry.Delete(User);
            //await _unitOfWork.Complet();
            context.SaveChanges();

            return Ok(true);

        }
    }


}

