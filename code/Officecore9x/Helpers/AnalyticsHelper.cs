namespace Officecore9x.Helpers
{
    using Sitecore.Analytics;
    using Sitecore.Analytics.Data.Items;
    using Sitecore.Data;
    using Sitecore.Diagnostics;

    public static class AnalyticsHelper
    {
        public static bool TriggerGoal(ID goalID)
        {
            if (goalID == (ID)null)
            {
                Log.Warn("GoalID is empty", typeof(AnalyticsHelper));
                return false;
            }

            if (!Tracker.IsActive)
            {
                Tracker.StartTracking();
            }

            if (Tracker.Current == null || Tracker.Current.Interaction == null || Tracker.Current.Interaction.CurrentPage == null)
            {
                Log.Warn("Tracker.Current == null || Tracker.Current.Interaction.CurrentPage == null", typeof(AnalyticsHelper));
                return false;
            }

            var goalItem = Sitecore.Context.Database.GetItem(goalID);
            if (goalItem == null)
            {
                Log.Warn("Goal Item is empty from ID: " + goalID, typeof(AnalyticsHelper));
                return false;
            }

            var goal = new PageEventItem(goalItem);
            Tracker.Current.Interaction.CurrentPage.Register(goal);
            return true;
        }
    }
}