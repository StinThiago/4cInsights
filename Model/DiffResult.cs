
namespace _cInsights.Model
{
    public class DiffResult
    {
        /// <summary>
        /// EnumDiff 
        /// Equal, //matched, If "equal" return that
        /// NotEqual, // does not matched, If "not of equal size just" return that
        /// SameSize 
        /// </summary>
        public string diference { get; set; }
        /// <summary>
        /// Numbers of the changes needed to be equals
        /// </summary>
        public int offsets { get; set; }
        /// <summary>
        /// lengh of the word.
        /// </summary>
        public int length { get; set; }
    }
}