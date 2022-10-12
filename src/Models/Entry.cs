using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FitnessFrog.Data;
using static FitnessFrog.Models.Activity;

namespace FitnessFrog.Models
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

        public Activity Activity { get; set; }

        [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }

        public double Duration { get; set; }
        public bool Exclude { get; set; }

        public IntensityLevel Intensity { get; set; }

        public Entry(int id, int year, int month, int day, Activity.ActivityType activityType, double duration, IntensityLevel intensity = IntensityLevel.Medium, bool exclude = false, string notes = null)
        {
            Id = id;
            Date = new DateTime(year, month, day);
            ActivityId = (int)activityType;
            Duration = duration;
            Intensity = intensity;
            Exclude = exclude;
            Notes = notes;
        }

    }
}