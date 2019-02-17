using System;

namespace pannel.api.Models
{
    public class PannelListEntry
    {
        public string title { get; set; }
        public  DateTime startTime { get; set; } 
        public DateTime endTime { get; set; }

        public string shortDescription { get; set; }
    }
}