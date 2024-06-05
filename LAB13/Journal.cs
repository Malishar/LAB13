using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class Journal
    {
        public int Count => entries.Count;

        List<JournalEntry> entries = new List<JournalEntry>();
        public void WriteRecord(object source, CollectionHandlerEventArgs args)
        {
            entries.Add(new JournalEntry(source.ToString(), args.ChangeType, args.ChangedItem.ToString()));
        }
        public void Print()
        {
            if (entries.Count > 0)
            {
                foreach (JournalEntry entry in entries)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
            else
            {
                Console.WriteLine("Журнал пустой!");
            }
        }
    }
}