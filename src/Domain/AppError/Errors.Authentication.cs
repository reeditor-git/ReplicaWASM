using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidAccessToken =
                Error.Conflict("Authentication.InvalidToken",
                    description: Lang_Errors.Authentication_InvalidToken);

            public static Error RefreshTokenExpired =
                Error.Conflict("Authentication.RefreshTokenExpired",
                    description: Lang_Errors.Authentication_RefreshTokenExpired);

            public static Error DuplicateEmail =
                Error.Conflict("Authentication.DuplicateEmail",
                    description: Lang_Errors.Authentication_DuplicateEmail);
        }
    }
}
