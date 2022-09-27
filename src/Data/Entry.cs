using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessFrog.Data
{
    public class Entry
    {
        public Entry()
        {

        }
        public enum IntensityLevel
        {
            Low,
            Medium,
            High
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
        public string Notes { get; set; }
        public double Duration { get; set; }
        public bool Exclude { get; set; }

        public Entry(int id, int year, int month, int day, Activity activity,
            double duration, IntensityLevel intensityLevel = IntensityLevel, bool exclude = false, string notes = null)
        {
            Id = id;
            Date = new DateTime(year, month, day);
            ActivityId = (int)activityType;
            Duration = duration;
            IntensityLevel = intensity;
            Exclude = exclude;
            Notes = notes
        }
    }
}