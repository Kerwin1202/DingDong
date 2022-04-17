namespace DingDong.Core.Models
{
    public class DingDongCategoryInfo
    {
        public DingDongCategoryInfo()
        {

        }
        public DingDongCategoryInfo(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool Monitor { get; set; }
    }
}
