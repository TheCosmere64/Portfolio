﻿#region

using SQLite;

#endregion

namespace AIMS.Core.Models
{
    public class ServiceModel
    {
        [PrimaryKey] public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}