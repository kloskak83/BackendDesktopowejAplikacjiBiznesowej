using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Helpers.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static List<T> ToList<T>(this ObservableCollection<T> collection)
        {
            return new List<T>(collection);
        }
    }
}
