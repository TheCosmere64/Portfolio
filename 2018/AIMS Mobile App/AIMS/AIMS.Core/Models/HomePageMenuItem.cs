#region

using System;

#endregion

namespace AIMS.Core.Models
{
    public class HomePageMenuItem
    {
        public HomePageMenuItem()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Type TargetType { get; set; }
    }
}