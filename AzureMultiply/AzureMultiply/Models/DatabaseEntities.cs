using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;

namespace AzureMath.Entities
{
	public class User
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string UserName { get; set; }
		public DateTime LastLogonTime { get; set; }

		public virtual ICollection<UserScore> UserScores { get; set; }
	}

	public class UserScore
	{
		public int UserScoreId { get; set; }
		public int UserId { get; set; }
		public DateTime ScoreTime { get; set; }
		public string Mode   { get; set; }
		public int MinVal    { get; set; }
		public int MaxVal    { get; set; }
		public int NumRight  { get; set; }
		public int NumWrong  { get; set; }
		public int TimeSec   { get; set; }
		public int RankScore { get; set; }

		public virtual User User { get; set; }
	}

}