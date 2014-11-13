namespace CornerFlag.Data.Models.People
{
    using CornerFlag.Data.Models.Entities;

    public class Player : Person
    {
        public Club Club { get; set; }

        public Position Position { get; set; }
    }
}
