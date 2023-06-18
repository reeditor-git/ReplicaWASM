using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class ConfirmationStatus
        {
            public static Error NotFound =
                Error.Conflict("ConfirmationStatus.NotFound",
                    description: Lang_Errors.Place_NotFound);
        }
    }
}
