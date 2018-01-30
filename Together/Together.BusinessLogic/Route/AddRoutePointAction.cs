using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.BusinessLogic.DTO.RoutePoint;
using Together.BusinessLogic.GenericIntefaces;
using Domain = Together.Data.Domain;
using Together.DataAccess.RoutePoint;

namespace Together.BusinessLogic.Route
{
    public class AddRoutePointAction : IBusinessAction<AddRoutePointDTO, Domain.RoutePoint>
    {
        IAddRoutePointDbAccess _dbAccess;

        public AddRoutePointAction(IAddRoutePointDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public Domain.RoutePoint Action(AddRoutePointDTO dto)
        {
            if (dto.RouteId < 0)
                //TODO: ADD Error
                return null;


            if (!_dbAccess.RouteExist(dto.RouteId))
                //TODO: ADD Error
                return null;

            Domain.RoutePoint routePoint = new Domain.RoutePoint()
            {
                Address = dto.Address,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                RouteId = dto.RouteId
            };

            return _dbAccess.AddRoutePoint(routePoint);
        }
    }
}
