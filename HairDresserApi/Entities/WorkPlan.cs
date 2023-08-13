using System;
using System.ComponentModel.DataAnnotations;

namespace HairDresserApi.Entities
{
    public class WorkPlan
    {
		[Key]
        public int WP_id { get; private set; }
        public TimeSpan WP_StartTime { get; private set; }
        public TimeSpan WP_EndTime { get; private set; }
        public TimeSpan WP_ShiftLength { get; private set; }       

        public WorkPlan(int wP_id, TimeSpan wP_StartTime, TimeSpan wP_EndTime, TimeSpan wP_ShiftLength)
        {
            WP_id = wP_id;
            WP_StartTime = wP_StartTime;
            WP_EndTime = wP_EndTime;
            WP_ShiftLength = wP_ShiftLength;
        }
    }
}
