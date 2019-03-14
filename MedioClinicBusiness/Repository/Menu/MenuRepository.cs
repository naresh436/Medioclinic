using System.Collections.Generic;
using MedioClinicBusiness.DTO.Menu;
using MedioClinicBusiness.Services.Query;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.MedioClinic;
using System.Linq;

namespace MedioClinicBusiness.Repository.Menu
{
    public class MenuRepository : BaseRepository,IMenuRepository
    {

        public MenuRepository(IDocumentQueryService menuRepository):base(menuRepository)
        {

        }


        public IEnumerable<MenuItemDto> GetMenuItems()
        {
            return DocumentQueryService.GetDocuments<MenuContainerItem>()
                .Path("/Menu-items", PathTypeEnum.Children)
                .AddColumns("Caption", "Controller", "Action")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(x =>
                {
                    return new MenuItemDto()
                    {
                        Action = x.Action,
                        Controller = x.Controller,
                        Caption = x.Caption
                    };
                });

        }
    }
}
