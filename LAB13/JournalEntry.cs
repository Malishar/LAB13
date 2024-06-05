using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class JournalEntry
    {
        // Свойства
        public string? CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string? ObjectData { get; set; }

        // Конструктор
        public JournalEntry(string collectionName, string changeType, string objectData)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ObjectData = objectData;
        }

        // Метод
        public override string ToString()
        {
            return $"Коллекция: {CollectionName}. {ChangeType}. Элемент: {ObjectData}.";
        }
    }
}
