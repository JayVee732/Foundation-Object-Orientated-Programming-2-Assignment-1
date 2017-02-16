using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    //Add in addition classes
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        //Add in image constructor
        
        //Default Constructor
        public Vehicle()
        {
        }

        public Vehicle(string make, string model, double price, int year, string colour, int mileage, string description)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
            this.Description = description;
            //Also image in here too
        }

        public override string ToString()
        {
            return "Make: " + Make + " " + "Model: " + Model;
        }
    }
}
