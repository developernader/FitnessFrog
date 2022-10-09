using FitnessFrog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessFrog.Data
{
    public class ActivitiesRepository
    {
        public List<Activity> GetActivities()
        {
            return Data.activities
                .OrderBy(a => a.Name)
                .ToList();
        }
    }
}