using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Subcategories.Commands.DeleteSubcategory
{
    public class DeleteSubcategoryCommandHandler
        : IRequestHandler<DeleteSubcategoryCommand, ErrorOr<Subcategory>>
    {
        protected readonly ISubcategoryRepository _subcategoryRepository;

        public DeleteSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository) =>
            _subcategoryRepository = subcategoryRepository;
        public async Task<ErrorOr<Subcategory>> Handle(DeleteSubcategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetAsync(request.Id);

            if (subcategory is null)
                return Errors.Subcategory.NotFound;

            await _subcategoryRepository.DeleteAsync(request.Id);

            return subcategory;
        }
    }
}
