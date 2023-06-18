using ErrorOr;
using MediatR;
using Replica.Domain.Enums;

namespace Replica.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ErrorOr<bool>>
    {
        public Guid ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public double Size { get; set; }

        public MeasurementUnits MeasurementUnits { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }

        public IEnumerable<Guid> TagsId { get; set; }
    }
}
