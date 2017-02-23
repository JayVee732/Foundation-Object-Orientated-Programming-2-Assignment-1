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
        public string Image { get; set; }

        //Default Constructor
        public Vehicle()
        {
        }

        public Vehicle(string make, string model, double price, int year, string colour, int mileage, string description, string image)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Year = year;
            this.Colour = colour;
            this.Mileage = mileage;
            this.Description = description;
            this.Image = image;
        }
    }

    class Car : Vehicle
    {
        public string BodyType { get; set; }

        public Car()
        {
        }

        public Car(string bodyType)
        {
            this.BodyType = bodyType;
        }
    }

    class Bike: Vehicle
    {
        public string Type { get; set; }

        public Bike()
        {
        }

        public Bike(string type)
        {
            this.Type = type;
        }
    }

    class Van: Vehicle
    {
        public string Wheelbase { get; set; }
        public string Type { get; set; }
        public Van()
        {
        }

        public Van(string wheelbase, string type)
        {
            this.Wheelbase = wheelbase;
            this.Type = type;
        }
    }
}
