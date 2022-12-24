using BLL.Spcefication.ContactUs;
using ContactUs.API.BLL.InterFaces;
using ContactUs.API.Model;
using ContactUs.API.Errors;

using ContactUs.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("allData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagintation<IReadOnlyList<ContactInfo>>>> GetContactUs([FromQuery] ContactUsSpecParams specParams)
        {

            var specCount = new ContactUsWithFilterForCountSpecification(specParams);
            var itemCount = await _unitOfWork.Repositry<ContactInfo>().Count(specCount);
            var data = await _unitOfWork.Repositry<ContactInfo>().GetAllDataWithSpecificatonAsync(specCount);
            return Ok(new Pagintation<ContactInfo>(specParams.PageIndex, specParams.PageSize, itemCount, data));

        }



        [HttpGet("{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactInfo>> GetContactById(int  id)

        {

            var data = await _unitOfWork.Repositry<ContactInfo>().GetDataByIdAsync(id);

            if (data == null)

                return NotFound();

            return Ok(data);
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

                await _unitOfWork.Repositry<ContactInfo>().Add(ContactUsInfo);
                var result = await _unitOfWork.Complet();

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
            var User = await _unitOfWork.Repositry<ContactInfo>().GetDataByNameAsync(Name);

            if (User == null)

                return BadRequest("Cant Find This User");

            _unitOfWork.Repositry<ContactInfo>().Delete(User);
            await _unitOfWork.Complet();

            return Ok(true);

        }
    }


}

