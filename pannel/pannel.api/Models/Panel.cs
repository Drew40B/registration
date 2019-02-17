using System;

namespace pannel.api.Models
{
    public class Panel
    {
        public int pannelId { get; set; }
        public string title { get; set; }

        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }

        public string shortDescriptiom { get; set; }

        public string longDescription { get; set; }
    }
}