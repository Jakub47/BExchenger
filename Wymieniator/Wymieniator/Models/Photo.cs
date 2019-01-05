namespace Wymieniator.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string FilePath { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}