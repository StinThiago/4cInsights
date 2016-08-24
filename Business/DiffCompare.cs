using System;
using _cInsights.Model;

namespace _cInsights.Business
{
    /*
    Well they are not quite the same thing as IComparer<T> is implemented on a type that is capable 
    of comparing two different objects while IComparable<T> is implemented on types that are able 
    to compare themselves with other instances of the same type.
    */

    public class DiffComparer : IComparable<Diff>
    {
        public int CompareTo(Diff other)
        {
            if (other.right.Equals(other.left))
                return 1;
            else
                return 0;
        }
    }
}