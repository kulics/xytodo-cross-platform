using System;
using System.Globalization;
using XyTodo.Localizations;

namespace XyTodo.Helpers
{
    public class HelperTime
    {
        public static string GetDateFromUTC(int time)
        {
            var date = "";
			//获取起始时间
			var Epoch = new DateTime(1970, 1, 1);
            var dateNow = DateTime.UtcNow;
			//将时间戳转为时间
            var dateTarget = Epoch.AddSeconds(time).ToLocalTime();
            var fmt = DateTimeFormatInfo.InvariantInfo;
			var dYear = int.Parse(dateNow.ToString("yyyy", fmt)) - int.Parse(dateTarget.ToString("yyyy", fmt));
			var dDay = int.Parse(dateNow.ToString("D", fmt)) - int.Parse(dateTarget.ToString("D", fmt));
			//按格式输出时间

			if (dYear > 0) //去年以前
			{
				date = dateTarget.ToString("yyyy-MM-dd", fmt);
			}
			else if (dYear <= -1)//明年以后
			{
				date = dateTarget.ToString("yyyy-MM-dd", fmt);
			}
            else if (dDay > 1) //昨天以前
            {
                date = dateTarget.ToString("MM-dd EEE", fmt);
            }
			else if (dDay > 0)//昨天
			{
                date = Localization.Yesterday + dateTarget.ToString("  EEE", fmt);
			}
            else if (dDay == 0)//今天
            {
                date = Localization.Today + dateTarget.ToString("  EEE", fmt);
            }
            else if (dDay > -2) //明天
            {
                date = Localization.Tomorrow + dateTarget.ToString("  EEE", fmt);
            }
			else //明天以后
			{
				date = dateTarget.ToString("MM-dd  EEE", fmt);
			}
            return date;
        }

		//换算是否当天
        public static bool ComputeDateToday(int time)
        {
			//获取起始时间
			var Epoch = new DateTime(1970, 1, 1);
			var dateNow = DateTime.UtcNow;
			//将时间戳转为时间
			var dateTarget = Epoch.AddSeconds(time).ToLocalTime();

            var fmt = DateTimeFormatInfo.InvariantInfo;
            
            if (dateTarget.ToString("yyyy-MM-dd", fmt) == DateTime.UtcNow.ToString("yyyy-MM-dd", fmt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
