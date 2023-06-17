using ErrorOr;
using Replica.Domain.Localization;

namespace Replica.Domain.AppError
{
    public static partial class Errors
    {
        public static class Tag
        {
            public static Error AlreadyExists =
                Error.Conflict("Tag.AlreadyExists",
                    description: Lang_Errors.Tag_AlreadyExists);

            public static Error NotFound =
                Error.Conflict("Tag.NotFound",
                    description: Lang_Errors.Tag_NotFound);
        }
    }
}
