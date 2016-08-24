using _cInsights.Model;
using System.Collections.Generic;

namespace _cInsights.Business
{
    public class DiffBusiness
    {
        internal bool GetResultFromId(string id)
        {
            return CalculateDifference(id) > 0 ? true : false;
        }
        internal static int CalculateDifference(string id)
        {
            var toBeCompared = FindAll(id);
            var comp = new DiffComparer();
            return comp.CompareTo(toBeCompared[0]);
        }
        internal static List<Diff> FindAll(string id)
        {
            return Diff.ListInstance.FindAll(x => x.id.Equals(id));
        }
        public static List<Diff> GetAllResults()
        {
            return Diff.ListInstance;
        }

        internal static void AddDiffToComparer(string id, string value, EnumDirection direction)
        {
            var list = FindAll(id);

            switch (direction)
            {
                case EnumDirection.Right:
                    if (list.Count == 0) Diff.ListInstance.Add(new Diff() { id = id, right = value });
                    else list.FindLast(x => x.id.Equals(id)).right = value;
                    break;
                case EnumDirection.Left:
                    if (list.Count == 0) Diff.ListInstance.Add(new Diff() { id = id, left = value });
                    else list.FindLast(x => x.id.Equals(id)).left = value;
                    break;
            }
        }
    }
}
