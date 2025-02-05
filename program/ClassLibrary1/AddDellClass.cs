using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public static class AddDellClass
    {
        public static List<T> ReloadCurrentData<T>(CourseWorkContext context) where T : class
        {
            return context.Set<T>().ToList();
        }

        public static List<T> DellRow<T>(List<T> items, T selectedItems, CourseWorkContext context) where T : class
        {
            context.Set<T>().Remove(selectedItems);
            context.SaveChanges();
            return context.Set<T>().ToList();
        }

        public static List<T> AddRow<T>(List<T> items) where T : class, new()
        {
            var newItem = new T();
            items.Add(newItem);
            return items;
        }

    }
}
