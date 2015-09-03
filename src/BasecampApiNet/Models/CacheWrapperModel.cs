using System;

namespace BasecampApiNet.Models
{
    public class CacheWrapperModel
    {
        public object Value { get; set; }
        public DateTime LastRequested { get; set; }
        public string ETag { get; set; }
        public string TypeString { get; set; }
    }
}
