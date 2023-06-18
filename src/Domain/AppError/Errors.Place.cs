using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Place
        {
            public static Error NotFound =
                Error.Conflict("Place.NotFound",
                    description: Lang_Errors.Place_NotFound);
        }
    }
}
