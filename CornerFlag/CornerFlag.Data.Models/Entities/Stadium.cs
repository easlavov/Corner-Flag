namespace CornerFlag.Data.Models.Entities
{
    public class Stadium : NamedDatabaseEntry
    {
        public virtual Country Country { get; set; }

        public int Capacity { get; set; }
    }
}
