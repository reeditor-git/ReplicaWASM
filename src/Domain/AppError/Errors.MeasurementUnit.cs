using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class MeasurementUnit
        {
            public static Error NotFound =
                Error.Conflict("MeasurementUnit.NotFound",
                    description: Lang_Errors.MeasurementUnit_NotFound);
        }
    }
}
