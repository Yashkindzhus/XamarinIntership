using SQLite;

namespace PinsApp.Models
{
	[Table(nameof(PinModel))]
	public class PinModel
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }

		public string Label { get; set; }
		public string Description { get; set; }
		public string Adress { get; set; }
		public double PositionX { get; set; }
		public double PositionY { get; set; }
		public bool IsFavorite { get; set; }
	}
}
