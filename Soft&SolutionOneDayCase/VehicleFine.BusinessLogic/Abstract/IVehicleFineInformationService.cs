using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleFine.Core.Utilities.Results;
using VehicleFine.Entities;
using VehicleFine.Entities.Concrete;

namespace VehicleFine.BusinessLogic.Abstract
{
    public interface IVehicleFineInformationService
    {
        IDataResult<VehicleFineInformation> GetById(Expression<Func<VehicleFineInformation, bool>> filter);
        IDataResult<List<VehicleFineInformation>> GetAll();
        IDataResult<List<VehicleFineInformation>> GetVehicleFineByPlate(string plate);
        IResult PayThePrice(int id);


    }
}
