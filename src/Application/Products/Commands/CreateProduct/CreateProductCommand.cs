using ErrorOr;
using MediatR;

namespace Replica.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand 
        : IRequest<ErrorOr<Guid>>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public double Size { get; set; }

        public Guid MeasurementUnitsId { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }

        public IEnumerable<Guid> TagsId { get; set; }
    }
}
