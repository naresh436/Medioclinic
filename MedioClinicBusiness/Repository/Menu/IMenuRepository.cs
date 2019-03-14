using MedioClinicBusiness.DTO.Menu;
using MedioClinicBusiness.Services;
using System.Collections.Generic;

namespace MedioClinicBusiness.Repository.Menu
{
    public interface IMenuRepository : IRepository
    {
        IEnumerable<MenuItemDto> GetMenuItems();
    }
}
