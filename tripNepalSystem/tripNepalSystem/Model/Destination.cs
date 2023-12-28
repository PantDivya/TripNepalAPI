namespace tripNepalSystem.Model;


    public class Destination
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string[] Features {  get; set; }
        public Map Map {  get; set; }
        public string[] OtherDetails {  get; set; }
        public string Rating { get; set; }
       

    }

