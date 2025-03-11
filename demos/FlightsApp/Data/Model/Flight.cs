using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsApp.Data.Model
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public  string Day { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }

        // Constructor
        public Flight(string flightCode, string airline, string from, string to, string day, string time, int duration, decimal cost)
        {
            FlightCode = flightCode;
            Airline = airline;
            From = from;
            To = to;
            Day = day;
            Time = time;
            Duration = duration;
            Cost = cost;
        }

        // Override the ToString() method to provide a string representation of the flight information
        public override string ToString()
        {
            return $"Flight Code: {FlightCode}, Airline: {Airline}, From: {From}, To: {To}, Day: {Day}, Time: {Time}, Duration: {Duration} minutes, Cost: {Cost:C}";
        }
    }
}
