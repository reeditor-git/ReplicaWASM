using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error NotFound =
                Error.Conflict("User.NotFound",
                    description: Lang_Errors.User_NotFound);
        }
    }
}
