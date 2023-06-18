using ErrorOr;
using MediatR;

namespace Replica.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ErrorOr<Guid>>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
