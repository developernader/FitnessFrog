using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FitnessFrog.Data;

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
        public string Notes { get; set; }
        public double Duration { get; set; }
        public bool Exclude { get; set; }
        public int Intensity { get; set; }

        public Entry(int id, int year, int month, int day, Activity activity,
            double duration, IntensityLevel intensityLevel, bool exclude = false, string notes = null)
        {
            Id = id;
            Date = new DateTime(year, month, day);
            ActivityId = ActivityId;
            Duration = duration;
            //IntensityLevel = (int)intensityLevel;
            Exclude = exclude;
            Notes = notes;
        }
    }
}