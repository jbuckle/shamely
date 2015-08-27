using System;

using SQLite;

namespace Shamely
{
	public class LogEntry
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get ; set ; }

		//Levels
		// 0: Good
		// 1: Bad
		public int Level { get ; set ; }
		public DateTime LoggedAt { get ; set ; }

		// Takes an int level (currently the one returned by 
		// args.Which) and maps it to the appropriate integer 
		// for the Level field in the LogEntry class.
		// Currently stupid, but potentially valuable in the future.
		public static int MapToLevel(int which) {
			return which;
		}
	}
}

