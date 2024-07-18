using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Helpers.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
        {
            var observableCollection = new ObservableCollection<T>();
            foreach (var item in list)
            {
                observableCollection.Add(item);
            }
            return observableCollection;
        }
    }
}
