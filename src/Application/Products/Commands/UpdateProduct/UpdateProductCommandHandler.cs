using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, ErrorOr<bool>>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly ITagRepository _tagRepository;
        protected readonly IMeasurementUnitRepository _measurementUnitRepository;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            ISubcategoryRepository subcategoryRepository,
            ITagRepository tagRepository,
            IMeasurementUnitRepository measurementUnitRepository) =>
            (_productRepository, _subcategoryRepository,
            _tagRepository, _measurementUnitRepository) =
            (productRepository, subcategoryRepository,
            tagRepository, measurementUnitRepository);

        public async Task<ErrorOr<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);

            if (product is null)
                return Errors.Product.NotFound;

            var subcategory = await _subcategoryRepository.GetAsync(request.SubcategoryId);

            if (subcategory is null)
                return Errors.Subcategory.NotFound;

            product.Name = request.Name;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;
            product.Size = request.Size;
            product.Price = request.Price;
            product.Subcategory = subcategory;
            product.ProductTags.Clear();

            var measurementUnit = await _measurementUnitRepository
                .GetAsync(request.MeasurementUnitsId);
            if (subcategory is null)
                return Errors.MeasurementUnit.NotFound;
            else product.MeasurementUnits = measurementUnit;


            if (request.TagsId is not null)
            {
                foreach (var tag in request.TagsId)
                {
                    var tagValue = await _tagRepository.GetAsync(tag);

                    if (tagValue is not null)
                        product.ProductTags.Add(new ProductTag
                        {
                            ProductId = product.Id,
                            TagId = tagValue.Id,
                        });
                }
            }

            return await _productRepository.UpdateAsync(product);
        }
    }
}
