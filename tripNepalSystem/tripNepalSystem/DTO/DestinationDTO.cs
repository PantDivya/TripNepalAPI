﻿using tripNepalSystem.Model;

namespace tripNepalSystem.DTO;

    public class DestinationDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsActive { get; set; }
    }

