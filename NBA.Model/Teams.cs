namespace NBA.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Teams
    {
        [Key]
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string TeamName { get; set; }
        public string Conference { get; set; }
    }
}
