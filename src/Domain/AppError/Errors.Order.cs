using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Order
        {
            public static Error NotFound =
                Error.Conflict("Order.NotFound",
                    description: Lang_Errors.Order_NotFound);
        }
    }
}
