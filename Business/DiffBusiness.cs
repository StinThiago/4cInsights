using _cInsights.Model;
using System.Collections.Generic;
using System;
using System.Text;
using _cInsights.Business.Distance;
using _cInsights.Business.Enum;

namespace _cInsights.Business
{
    public class DiffBusiness
    {
        static int CalculateLevenshteinDifferenceDecoded(string id)
        {
            return Levenshtein.Compute(DecodeBase64String(First(id).right),
                                       DecodeBase64String(First(id).left));
        }

        static int CalculateLevenshteinDifference(string id)
        {
            return Levenshtein.Compute(First(id).right, First(id).left);
        }

        internal static Diff First(string id)
        {
            return DiffBusiness.FindAll(id)[0];
        }

        static string DecodeBase64String(string stringToDecode)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
        }

        static string FindRightById(string id)
        {
            return FindAll(id)[0].right;
        }

        internal static List<Diff> FindAll(string id)
        {
            return Diff.StorageDiff.FindAll(x => x.id.Equals(id));
        }

        static int GetCalculatedSimpleResult(string id)
        {
            return First(id).right.CompareTo(First(id).left);
        }

        static Boolean IsSameLength(string id)
        {
            return First(id).right.Length.Equals(First(id).left.Length);
        }

        static int GetCalculatedLevenshteinSimpleResult(string id)
        {
            return CalculateLevenshteinDifference(id);
        }
        internal static DiffResult GetResult(string id)
        {
            var result = new DiffResult();

            var leven = GetCalculatedLevenshteinSimpleResult(id);
            var len = FindRightById(id).Length;

            if (IsSameLength(id)) { result.diference = EnumDiff.SameSize.ToString(); }
            else result.diference = GetResultOfDiff(leven);

            result.offsets = leven;
            result.length = len;

            return result;
        }

        static string GetResultOfDiff(int diffLeven)
        {
            if (diffLeven == 0) return EnumDiff.Equal.ToString();
            else return EnumDiff.NotEqual.ToString();
        }

        internal static void AddToStorage(string id, string value, EnumDirection direction)
        {
            var list = FindAll(id);

            switch (direction)
            {
                case EnumDirection.Right:
                    if (list.Count == 0) Diff.StorageDiff.Add(new Diff() { id = id, right = value });
                    else list.FindLast(x => x.id.Equals(id)).right = value;
                    break;
                case EnumDirection.Left:
                    if (list.Count == 0) Diff.StorageDiff.Add(new Diff() { id = id, left = value });
                    else list.FindLast(x => x.id.Equals(id)).left = value;
                    break;
            }
        }
    }
}
