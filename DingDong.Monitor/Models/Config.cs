using DingDong.Core.Models;

namespace DingDong.Monitor.Models
{
    public class Config
    {
        public DingDongConfig DdConfig { get; set; }

        public List<DingDongCategoryInfo> Categories { get; set; }

        public SoftConfig SoftConfig { get; set; }
    }

    public class SoftConfig
    {
        public List<string> PushUrls { get; set; }

        public bool PlayMusic { get; set; }

        public bool MonitorCategory { get; set; }

        public bool MonitorCart { get; set; }

        public bool IsTimeBegin { get; set; }

        public string TimeBegin { get; set; }

        public bool MonitorContinue { get; set; }

        public int MonitorContinueMins { get; set; }

        public int MonitorInterval { get; set; }

        public List<string> ExcludeKeywords { get; set; }

        public bool TrackLog { get; set; }
    }
}
