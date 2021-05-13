namespace K9.WebApplication.Options
{
    public class GaugeOptions
    {
        public string Title { get; set; }
        public int Value { get; set; }
        public int MaxValue { get; set; }
        public bool IsInverted { get; set; }
        public bool IsSecret { get; set; }
    }
}