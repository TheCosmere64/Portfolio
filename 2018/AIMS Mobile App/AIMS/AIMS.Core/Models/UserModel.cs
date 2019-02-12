#region

using SQLite;

#endregion

namespace AIMS.Core.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public byte[] ProfileImage { get; set; }
        public string ProfileImageText { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalAddress3 { get; set; }
        public string PostalCity { get; set; }
        public string PostalState { get; set; }
        public string PostalPostcode { get; set; }
        public string PostalCountry { get; set; }
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public string WorkAddress1 { get; set; }
        public string WorkAddress2 { get; set; }
        public string WorkAddress3 { get; set; }
        public string WorkCity { get; set; }
        public string WorkState { get; set; }
        public string WorkPostcode { get; set; }
        public string WorkCountry { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Mobile { get; set; }
    }
}