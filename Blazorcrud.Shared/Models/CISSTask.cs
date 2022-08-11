namespace Blazorcrud.Shared.Models
{
    public class CISSTask
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string TaskName { get; set; } = default!;
        public string Comment { get; set; } = default!;
        public DateTime StartTimestamp {get; set;} = default!;
        public DateTime? EndTimestamp {get; set;} = default!;
        public string FileContent {get; set;} = default!;
    }
}