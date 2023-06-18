using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Subcategory
        {
            public static Error AlreadyExists =
                Error.Conflict("Subcategory.AlreadyExists", 
                    description: Lang_Errors.Subcategory_AlreadyExists);

            public static Error NotFound =
                Error.Conflict("Subcategory.NotFound",
                    description: Lang_Errors.Subcategory_NotFound);
        }
    }
}
