namespace Spitfire.Library.Models.Health
{
    public class HealthResult
    {
        public HealthResult()
        {
            Totals = new HealthTotals();
            Renderings = new HealthRenderings();
        }

        public HealthTotals Totals { get; set; }

        public HealthRenderings Renderings { get; set; }
    }
}