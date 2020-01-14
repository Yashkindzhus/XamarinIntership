using SQLite;

namespace PinsApp.Models
{
		[Table(nameof(UserModel))]
		public class UserModel
		{
			[PrimaryKey, AutoIncrement, Column("_id")]
			public int Id { get; set; }

			public string Name { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
		}
}
