namespace TaskManager.Model.Data
{
    public class Comment
    {
        public uint id { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public User author { get; set; }
    }
}
