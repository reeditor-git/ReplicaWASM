using MediatR;
using Replica.Domain.Entities;

namespace Replica.Application.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>> { }
}
