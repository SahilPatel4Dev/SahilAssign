namespace SahilAssign.Models
{
    public class AddSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Value2 { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
