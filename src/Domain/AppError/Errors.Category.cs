using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Category
        {
            public static Error AlreadyExists = 
                Error.Conflict("Category.AlreadyExists",
                    description: Lang_Errors.Tag_AlreadyExists);

            public static Error NotFound =
                Error.Conflict("Category.NotFound",
                    description: Lang_Errors.Tag_NotFound);
        }
    }
}
