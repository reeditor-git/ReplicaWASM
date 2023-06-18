using ErrorOr;
using MediatR;

namespace Replica.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ErrorOr<bool>>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
