using tripNepalSystem.Model;

namespace tripNepalSystem.DTO;

    public class DestinationDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string[] Features { get; set; }
        public int Map { get; set; }
        public string[] OtherDetails { get; set; }
        public string Rating { get; set; }

        public bool IsActive { get; set; }
    }

