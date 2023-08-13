using HairDresserApi.Entities;
using System;

namespace HairDresserApi.ViewModel
{
	public class WorkPlanViewModel : WorkPlan
	{
        public ShiftType ShiftType
        {
            get
            {
                if (base.WP_StartTime == new TimeSpan(6, 0, 0) && WP_EndTime == new TimeSpan(14, 0, 0))
                    return ShiftType.daily;
                if (base.WP_StartTime == new TimeSpan(14, 0, 0) && WP_EndTime == new TimeSpan(22, 0, 0))
                    return ShiftType.afternoon;
                if (base.WP_StartTime == new TimeSpan(22, 0, 0) && WP_EndTime == new TimeSpan(6, 0, 0))
                    return ShiftType.night;
                return ShiftType.empty;
            }
        }
		public WorkPlanViewModel(int wp_id, TimeSpan startTime, TimeSpan endTime, TimeSpan length)
            :base(wp_id,startTime,endTime,length)
        {
           
        }
    }
}
