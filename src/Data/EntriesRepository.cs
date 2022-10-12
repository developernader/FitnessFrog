using FitnessFrog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessFrog.Data
{
    public class EntriesRepository
    {
        public List<Entry> GetEntries()
        {
            return Data.Entries
                .Join(
                    Data.Activities, // The inner collection
                    e => e.ActivityId, // The outer selector
                    a => a.Id,  // The inner selector
                    (e, a) =>  // The result selector
                    {
                        e.Activity = a; // Set the entry's Activity property
                        return e; // Return the entry
                    }
                    )
                .OrderByDescending(e => e.Date)
                .ThenByDescending(e => e.Id)
                .ToList();
        }

        public Entry GetEntry(int id)
        {
            Entry entry = Data.Entries
                .Where(e => e.Id == id)
                .SingleOrDefault();

            // Ensure that the activity property is not null.
            if (entry.Activity == null)
            {
                entry.Activity = Data.Activities
                    .Where(a => a.Id == entry.ActivityId)
                    .SingleOrDefault();
            }

            return entry;
        }

        public void AddEntry(Entry entry)
        {
            // Get the next available entry ID.
            int nextAvailableEntryId = Data.Entries
                .Max(e => e.Id) + 1;

            entry.Id = nextAvailableEntryId;

            Data.Entries.Add(entry);
        }

        public void UpdateEntry(Entry entry)
        {
            // Find the index of the entry that we need to update.
            int entryIndex = Data.Entries.FindIndex(e => e.Id == entry.Id);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", entry.Id));
            }

            Data.Entries[entryIndex] = entry;
        }

        public void DeleteEntry(int id)
        {
            // Find the index of the entry that we need to delete.
            int entryIndex = Data.Entries.FindIndex(e => e.Id == id);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", id));
            }

            Data.Entries.RemoveAt(entryIndex);
        }

    }
}