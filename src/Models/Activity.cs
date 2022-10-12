using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessFrog.Models
{
    public class Activity
    {
        public enum ActivityType
        {
            Basketball = 1,
            Biking = 2,
            Hiking = 3,
            Kayaking = 4,
            PokemonGo = 5,
            Running = 6,
            Skiing = 7,
            Swimming = 8,
            Walking = 9,
            WeightLifting = 10
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Activity(ActivityType activityType, string name = null)
        {
            Id = (int)activityType;

            // If we don't have a name argument, 
            // then use the string representation of the activity type for the name.
            Name = name ?? activityType.ToString();
        }
    }
}