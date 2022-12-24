using ContactUs.API.BLL.Spcefication;
using ContactUs.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Spcefication.ContactUs
{
    public class ContactUsWithFilterForCountSpecification : BaseSpcification<ContactInfo>
    {

        public ContactUsWithFilterForCountSpecification(ContactUsSpecParams specParams) : base(Jf =>
      (string.IsNullOrEmpty(specParams.Search) || Jf.FullName.ToLower().Contains(specParams.Search))

         )
        {

        }

    }
}
