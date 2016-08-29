
using System;
using System.Collections.Generic;

namespace _cInsights.Model
{
    public class Diff
    {
        /// <summary>
        /// Memory Storage
        /// </summary>
        static List<Diff> storageDiff;
        public static List<Diff> StorageDiff
        {
            get
            {
                return (storageDiff == null) ? storageDiff = new List<Diff>() : storageDiff;
            }
        }

        public String id { get; set; }
        public string right { get; set; }
        public string left { get; set; }
    }
}