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
        /// <summary>
        /// Calculate the diferences between right and left input by 
        /// decoding content and comparing using levenshtein algorithm
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>distance between string</returns>
        static int CalculateLevenshteinDifferenceDecoded(string id)
        {
            return Levenshtein.Compute(DecodeBase64String(First(id).right),
                                       DecodeBase64String(First(id).left));
        }
        /// <summary>
        /// Calculate the diferences between right and left input by comparing using levenshtein algorithm
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>distance between string</returns>
        static int CalculateLevenshteinDifference(string id)
        {
            return Levenshtein.Compute(First(id).right, First(id).left);
        }

        /// <summary>
        /// Get the first index of the id
        /// </summary>
        /// <param name="id"> input id</param>
        /// <returns>Diff object finded</returns>
        internal static Diff First(string id)
        {
            return DiffBusiness.FindAll(id)[0];
        }

        /// <summary>
        /// decode string base 64 to plain text
        /// </summary>
        /// <param name="stringToDecode">base64 string</param>
        /// <returns>plain text decoded</returns>
        static string DecodeBase64String(string stringToDecode)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
        }

        /// <summary>
        /// get first object by id and return the right property value
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>string right</returns>
        static string FindRightById(string id)
        {
            return FindAll(id)[0].right;
        }

        /// <summary>
        /// Find all objects with the same id
        /// </summary>
        /// <param name="id">unput id</param>
        /// <returns>list of Diff objects</returns>
        internal static List<Diff> FindAll(string id)
        {
            return Diff.StorageDiff.FindAll(x => x.id.Equals(id));
        }
        /// <summary>
        /// Simple comparing the string right and left content with the id
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>true equals and false not equals</returns>
        static Boolean IsSameLength(string id)
        {
            return First(id).right.Length.Equals(First(id).left.Length);
        }

        /// <summary>
        /// Obtain the result of simple comparison using levenshtein algorithm
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>numbers of distance</returns>
        static int GetCalculatedLevenshteinSimpleResult(string id)
        {
            return CalculateLevenshteinDifference(id);
        }

        /// <summary>
        /// Obtain the diff result of id provided
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns>DiffResult object filled</returns>
        internal static DiffResult GetResult(string id)
        {
            var result = new DiffResult();

            var levenshtein = GetCalculatedLevenshteinSimpleResult(id);
            var length = FindRightById(id).Length;

            result.diference = GetResultOfDiff(levenshtein);
            result.value = FindRightById(id);

            if (result.diference.Equals(EnumDiff.NotEqual.ToString()))
                if (IsSameLength(id))
                    result.diference = EnumDiff.SameSize.ToString();

            result.offsets = levenshtein;
            result.length = length;

            return result;
        }

        /// <summary>
        /// Get the result of diff.
        /// </summary>
        /// <param name="diffLeven">levenshtein distance</param>
        /// <returns> Equal or NotEqual</returns>
        static string GetResultOfDiff(int diffLeven)
        {
            if (diffLeven == 0) return EnumDiff.Equal.ToString();
            else return EnumDiff.NotEqual.ToString();
        }

        /// <summary>
        /// Add the object to specific list of object
        /// </summary>
        /// <param name="id">input id</param>
        /// <param name="value">input value base 64</param>
        /// <param name="direction">direction Right/Left</param>
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
