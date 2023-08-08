using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleFine.BusinessLogic.Abstract;
using VehicleFine.Core.Utilities.Results;
using VehicleFine.Core.Utilities.UnitOfWork;
using VehicleFine.DataAccess.Repository;
using VehicleFine.Entities.Concrete;

namespace VehicleFine.BusinessLogic.Concrete
{
    public class VehicleFineInformationService : IVehicleFineInformationService
    {
        private IEntityRepository<VehicleFineInformation> _entityRepository;
        IUnitOfWork _unitOfWork;
        public VehicleFineInformationService(IEntityRepository<VehicleFineInformation> entityRepository, IUnitOfWork unitOfWork)
        {
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }
        public IDataResult<List<VehicleFineInformation>> GetAll()
        {
            try
            {
                var result = _entityRepository.GetAllAsQueryable()
                    .Include(v => v.Vehicle).ThenInclude(b => b.Brand)
                    .Include(v => v.Vehicle).ThenInclude(o => o.Owner)
                    .Include(vfr => vfr.VehicleFineReason)
                    .Include(vfs => vfs.VehicleFineStatus).ToList();
                return new SuccessDataResult<List<VehicleFineInformation>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<VehicleFineInformation>>(ex.Message + " " + ex.InnerException);
            }
        }
        public IDataResult<List<VehicleFineInformation>> GetVehicleFineByPlate(string plate)
        {
            try
            {
                var result = _entityRepository.GetAllAsQueryable()
                    .Include(v => v.Vehicle).ThenInclude(b => b.Brand)
                    .Include(v => v.Vehicle).ThenInclude(o => o.Owner)
                    .Include(vfr => vfr.VehicleFineReason)
                    .Include(vfs => vfs.VehicleFineStatus).Where(x => x.Vehicle.Plate == plate).ToList();
                return new SuccessDataResult<List<VehicleFineInformation>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<VehicleFineInformation>>(ex.Message + " " + ex.InnerException);
            }
        }
        public IResult PayThePrice(int id)
        {
            try
            {
                var existing = _entityRepository.GetSingle(id);
                if (existing.VehicleFineStatusId == 2)
                {
                    existing.VehicleFineStatusId = 1;
                }
                _entityRepository.Edit(existing);
                _unitOfWork.Commit();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<VehicleFineInformation>>(ex.Message + " " + ex.InnerException);
            }
        }

        
        public IDataResult<VehicleFineInformation> GetById(Expression<Func<VehicleFineInformation, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
