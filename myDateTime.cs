using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phpuploaderCS
{
	internal class myDateTime : ICloneable
	{
		Boolean finit = false;

		//ICloneable.Clone
		public object Clone()
		{
			return MemberwiseClone();
		}

		public DateTime dateTime { get; set; }
		public myDateTime()
		{
			dateTime = DateTime.Now;
			finit = true;
		}
		public myDateTime(DateTime dt)
		{
			dateTime = dt;
			finit = true;
		}
		public myDateTime(int y, int m, int d)
		{
			dateTime = new DateTime(y, m, d);
			finit = true;
		}

		public string ToString(string fmt = "yyyy-MM-dd HH:mm:ss")
		{
			return dateTime.ToString(fmt);
		}

		public void clear()
		{
			finit = false;
		}

		public Boolean isInit()
		{
			return finit;
		}

		public DateTime myDate()
		{
			return dateTime;
		}

		public int year()
		{
			if (!finit)
			{
				return 0;
			}
			return dateTime.Year;
		}
		public int month()
		{
			if (!finit)
			{
				return 0;
			}
			return dateTime.Month;
		}
		public int day()
		{
			if (!finit)
			{
				return 0;
			}
			return dateTime.Day;
		}
		public int hour()
		{
			if (!finit)
			{
				return 0;
			}
			return dateTime.Hour;
		}

		public void setHour(int hour)
		{
			if (finit)
			{
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, dateTime.Minute, dateTime.Second);
			}
		}

		public void setMinute(int minute)
		{
			if (finit)
			{
				dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, minute, dateTime.Second);
			}
		}

		public void addDays(int days)
		{
			if (finit)
			{
				dateTime = dateTime.AddDays(days);
			}
		}

		public int cmpDate(myDateTime dt1)
		{
			return dateTime.CompareTo(dt1.dateTime);
		}




	}


}
