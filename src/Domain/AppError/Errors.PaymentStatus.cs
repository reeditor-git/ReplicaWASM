using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class PaymentStatus
        {
            public static Error NotFound =
                Error.Conflict("PaymentStatus.NotFound",
                    description: Lang_Errors.PaymentStatus_NotFound);
        }
    }
}
