using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Replica.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, ErrorOr<bool>>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ISubcategoryRepository _subcategoryRepository;
        protected readonly ITagRepository _tagRepository;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            ISubcategoryRepository subcategoryRepository,
            ITagRepository tagRepository) =>
            (_productRepository, _subcategoryRepository, _tagRepository) =
            (productRepository, subcategoryRepository, tagRepository);

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
            product.MeasurementUnits = request.MeasurementUnits;
            product.Price = request.Price;
            product.Subcategory = subcategory;
            product.ProductTags.Clear();

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
