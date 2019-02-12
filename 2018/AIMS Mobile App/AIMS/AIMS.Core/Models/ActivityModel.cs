#region

using System;
using SQLite;

#endregion

namespace AIMS.Core.Models
{
    public class ActivityModel
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

        public int UserId { get; set; }

        public string Catagory { get; set; }

        public string SubCatagory { get; set; }

        public string ShortDescription { get; set; }

        public DateTime DateCompleted { get; set; }

        public string FurtherDetails { get; set; }

        public double Quantity { get; set; }

        public string LongDescription { get; set; }

        public double NumPoints { get; set; }

        /// <summary>
        /// This needs to be changed to the database type, right now it only stores the file path
        /// </summary>
        public string SupportingDocument { get; set; }
    }
}