using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        // Свойства
        public string ChangeType { get; set; }
        public object ChangedItem { get; set; }

        // Конструктор
        public CollectionHandlerEventArgs(string changeType, object changedItem)
        {
            ChangeType = changeType;
            ChangedItem = changedItem;
        }
    }
}
