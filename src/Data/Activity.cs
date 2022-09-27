using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessFrog.Data
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
            Swinmming = 8
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Activity(ActivityType activityType, string name)
        {
            Id = (int)activityType;
            Name = name ?? activityType.ToString();
        }
    }
}