using ErrorOr;
using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Subcategories.Commands.DeleteSubcategory
{
    public class DeleteSubcategoryCommand : IRequest<ErrorOr<Subcategory>>
    {
        public Guid Id { get; set; }
    }
}
