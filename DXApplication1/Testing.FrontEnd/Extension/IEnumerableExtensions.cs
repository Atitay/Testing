using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.FrontEnd.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, Guid selectedValue)
        {
            return from item in items

                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("TopicName"),
                       Value = item.GetPropertyValue("TopicId"),
                       Selected = item.GetPropertyValue("TopicName").Equals(selectedValue.ToString())
                   };
        }
    }
}
