using System;
using System.Collections.Generic;

namespace Universal_Inject_Generator
{
    public static class HexText
    {
        public static IEnumerable<TResult> SelectPair<TSource, TResult>(this IEnumerable<TSource> list, Func<TSource, TSource, TResult> onPair)
        {
            TSource odd = default(TSource);
            bool isOdd = true;

            foreach (var item in list)
            {
                if (isOdd)
                {
                    odd = item;
                }
                else
                {
                    yield return onPair(odd, item);
                }

                isOdd = !isOdd;
            }
        }
    }
}
