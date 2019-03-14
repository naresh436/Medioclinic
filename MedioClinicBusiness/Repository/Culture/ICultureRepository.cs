using MedioClinicBusiness.DTO.Culture;
using System.Collections.Generic;

namespace MedioClinicBusiness.Repository.Culture
{
    public interface ICultureRepository :IRepository
    {
        IEnumerable<CultureDto> GetSiteCultures();
    }
}
