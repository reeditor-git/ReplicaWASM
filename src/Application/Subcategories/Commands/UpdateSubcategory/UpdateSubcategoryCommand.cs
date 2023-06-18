using ErrorOr;
using MediatR;

namespace Replica.Application.Subcategories.Commands.UpdateSubcategory
{
    public class UpdateSubcategoryCommand : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
