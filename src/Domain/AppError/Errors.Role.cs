using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Role
        {
            public static Error NotFound =
                Error.Conflict("Role.NotFound",
                    description: Lang_Errors.Role_NotFound);
        }
    }
}
