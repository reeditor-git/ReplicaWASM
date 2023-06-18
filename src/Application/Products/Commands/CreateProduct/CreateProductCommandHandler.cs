using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, ErrorOr<Guid>>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly ITagRepository _tagRepository;
        protected readonly IMeasurementUnitRepository _measurementUnitRepository;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ISubcategoryRepository subcategoryRepository,
            ITagRepository tagRepository,
            IMeasurementUnitRepository measurementUnitRepository) =>
            (_productRepository, _subcategoryRepository,
            _tagRepository, _measurementUnitRepository) =
            (productRepository, subcategoryRepository, 
            tagRepository, measurementUnitRepository);

        public async Task<ErrorOr<Guid>> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetAsync(request.SubcategoryId);

            if (subcategory is null)
                return Errors.Subcategory.NotFound;

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Size = request.Size,
                Price = request.Price,
                Subcategory = subcategory,
            };

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

            return await _productRepository.CreateAsync(product);
        }
    }
}
