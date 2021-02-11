using System;

namespace oef_01_wines.models
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public string Grapes { get; set; }
    }
}
