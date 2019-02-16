using System;

namespace pannel.api.Models
{
    public class Panel
    {
        public int panelId { get; set; }
        public string title { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endDate { get; set; }

        public string descriptiom { get; set; }
    }
}