using System;
using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public static class Extensions
    {
        private static Random random = new Random();

        // Based on https://stackoverflow.com/a/1262619
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int count = list.Count;
            while (count > 1)
            {
                count--;
                int randomIndex = random.Next(count + 1);
                T value = list[randomIndex];
                list[randomIndex] = list[count];
                list[count] = value;
            }

            return list;
        }
    }
}
