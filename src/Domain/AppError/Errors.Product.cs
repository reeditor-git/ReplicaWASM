using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error NotFound =
                Error.Conflict("Product.NotFound",
                    description: Lang_Errors.Product_NotFound);
        }
    }
}
