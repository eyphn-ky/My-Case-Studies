using FarmasiDemo.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Services.Interface
{
    public interface IEntityService<TDto> : IService where TDto:class,new()    
    {
        IEnumerable<TDto> GetAll();
        TDto GetSingle(string id);
        OperationResult<TDto> Add(TDto entityDto);
        OperationResult<TDto> Update(TDto entityDto);
        OperationResult<TDto> Delete(TDto entityDto);
    }
}
