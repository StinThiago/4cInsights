
using System;
using System.Collections.Generic;

namespace _cInsights.Model
{
    public class Diff
    {
        static List<Diff> listInstance;
            public static List<Diff> ListInstance
        {
            get
            {
                return (listInstance == null) ? listInstance = new List<Diff>() : listInstance;
            }
        }
        
        public String id { get; set; }
        public string right { get; set; }
        public string left { get; set; }
    }
}