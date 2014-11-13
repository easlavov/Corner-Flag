namespace CornerFlag.Data.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Standing : DatabaseEntity
    {
        public virtual Club Club { get; set; }

        [Range(0, 100)]
        public int GamesPlayed { get; set; }

        [Range(0, 100)]
        public int GoalsFor { get; set; }

        [Range(0, 100)]
        public int GoalsAgainst { get; set; }

        [Range(0, 100)]
        public int Won { get; set; }

        [Range(0, 100)]
        public int Lost { get; set; }

        [Range(0, 100)]
        public int Drawn { get; set; }

        [Range(0, 200)]
        public int Points { get; set; }        
    }
}
