namespace _cInsights.Controllers.Input
{
    public class InputValue
    {
        public string value { get; set; }

        public override string ToString()
        {
            return string.Format("value: {0}", value);
        }
    }
}