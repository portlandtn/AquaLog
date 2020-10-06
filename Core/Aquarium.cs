using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Aquarium
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, Range(1,500)]
        public int Capacity { get; set; }
        public bool Freshwater { get; set; }
        public string Description { get; set; }
    }
}