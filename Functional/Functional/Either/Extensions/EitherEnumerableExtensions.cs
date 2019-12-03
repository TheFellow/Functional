using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class EitherEnumerableExtensions
    {
        public static Either<TLeft, TRight> FirstOrDefault<TLeft, TRight>(this IEnumerable<TRight> seq, TLeft whenEmpty) =>
            seq.FirstOrNone() is Some<TRight> some
                ? (Either<TLeft, TRight>)some.Content
                : whenEmpty;
    }
}
