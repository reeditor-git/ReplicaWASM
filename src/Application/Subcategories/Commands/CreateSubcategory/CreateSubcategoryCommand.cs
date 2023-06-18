using ErrorOr;
using MediatR;

namespace Replica.Application.Subcategories.Commands.CreateSubcategory
{
    public class CreateSubcategoryCommand : IRequest<ErrorOr<Guid>>
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
