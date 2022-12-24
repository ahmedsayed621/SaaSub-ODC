using BLL.Spcefication.ContactUs;
using ContactUs.API.BLL.InterFaces;
using ContactUs.API.Model;
using ContactUs.API.Errors;

using ContactUs.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactUs.API.data;
using Talabat.API.Errors;

namespace ContactUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsInfoController : ControllerBase
    {
        private readonly IGenercRepositry<ContactInfo> repositry;
        private readonly ApplicationDbContext context;

        public ContactUsInfoController( ApplicationDbContext _context  ,IGenercRepositry<ContactInfo> _repositry)
        {
            _repositry = repositry;
            _context=context;
        }

        [HttpGet("allData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagintation<IReadOnlyList<ContactInfo>>>> GetContactUs([FromQuery] ContactUsSpecParams specParams)
        {





            var specCount = new ContactUsWithFilterForCountSpecification(specParams);
            var itemCount = await repositry.Count(specCount);
            var data = await repositry.GetAllDataWithSpecificatonAsync(specCount);
            //var Data = await repositry.GetAllAsync();


            if (data == null) return NotFound(new ApiResponse(404));

            return Ok(new Pagintation<ContactInfo>(specParams.PageIndex, specParams.PageSize, itemCount, data));
           
        }


    



        [HttpGet("{Name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactInfo>> GetContactById(int  id)

        {

            var data = await repositry.GetDataByIdAsync(id);

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

