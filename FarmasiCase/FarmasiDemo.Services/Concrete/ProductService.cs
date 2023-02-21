using AutoMapper;
using FarmasiDemo.DataAccessLayer.Repository;
using FarmasiDemo.Entities.Concrete;
using FarmasiDemo.Models.Concrete;
using FarmasiDemo.Models.Helper;
using FarmasiDemo.Services.Interface;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        IRepository<Product> _productRepository;
        public ProductService(IMapper mapper, IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public OperationResult<ProductDto> Add(ProductDto entityDto)
        {
            try
            {
                var entity = _mapper.Map<Product>(entityDto);
                _productRepository.Add(entity);
                return new OperationResult<ProductDto>(OperationResultType.SUCCESS, Messages.SuccessTitle, Messages.ProductAdded);
            }
            catch (Exception ex)
            {
                return new OperationResult<ProductDto>(OperationResultType.SUCCESS, Messages.SuccessTitle, ex.Message) { EntityDto = entityDto };
            }
        }

        public OperationResult<ProductDto> Delete(ProductDto entityDto)
        {
            try
            {
                var delete = _productRepository.DeleteAsync(x => x.Id == ObjectId.Parse(entityDto.Id));
                return new OperationResult<ProductDto>(OperationResultType.SUCCESS,Messages.SuccessTitle,Messages.ProductDeleted);
            }
            catch (Exception ex)
            {
                return new OperationResult<ProductDto>(OperationResultType.SUCCESS, Messages.SuccessTitle, ex.Message) { EntityDto=entityDto};
            }
        }

        public IEnumerable<ProductDto> GetAll()
        {
            try
            {
                var products = _productRepository.GetAll();
                return products.Select(x => _mapper.Map<ProductDto>(x));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto GetSingle(string id)
        {
            try
            {
                var product = _productRepository.GetByIdAsync(id);
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OperationResult<ProductDto> Update(ProductDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
