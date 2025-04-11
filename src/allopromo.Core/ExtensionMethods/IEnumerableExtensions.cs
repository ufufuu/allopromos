using System;
using System.Collections.Generic;
using System.Text;
namespace allopromo.Core.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static List<int> AddNumberToList(this IList<int> numberList, int addedValue)
        {
            numberList = new List<int> { 1, 2, 3, 4, 5 };
            var addedList = new List<int>();
            for(var number=0; number <=numberList.Count; number++)
            {
                for(var num=0; num<=addedList.Count; num++)
                {
                    num = number + 4;
                    num = +5;
                }
            }
            return addedList;
        }
    }
}
