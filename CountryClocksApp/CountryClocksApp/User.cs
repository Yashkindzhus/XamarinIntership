using System;
using SQLite;

namespace CountryClocksApp
{
    [Table("Users")]
    public class User : BaseItem
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"{Login},{Password}";
        }
    }
}
