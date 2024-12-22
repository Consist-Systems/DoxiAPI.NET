using System;
using System.Text.Json.Serialization;

namespace Doxi.APIClient.Models
{
	public class User : BaseUser
	{

		[JsonPropertyName("username")]
		public string UserName { get; set; }
		[JsonPropertyName("enabled")]
		public bool? Enabled { get; set; }
		[JsonPropertyName("firstName")]
		public string FirstName { get; set; }
		[JsonPropertyName("lastName")]
		public string LastName { get; set; }


		public string MobilePhone { get; set; }

		public string Company { get; set; }

		public string Title { get; set; }

		public bool IsAllowReceivingSMS { get; set; }

		public bool IsAllowReceivingMails { get; set; }

		public DateTime? LastLoginTime { get; set; }

		public DateTime? CreatedTime { get; set; }

		public bool IdDeleted { get; set; }

		public string PreferredLanguageCode { get; set; }

		public string PreferredTimezone { get; set; }

	}
}