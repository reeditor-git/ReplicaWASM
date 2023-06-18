using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<ErrorOr<Category>>
    {
        public Guid Id { get; set; }
    }
}
