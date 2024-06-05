using LibraryClass;
using LibraryLab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, new()
    {
        // Свойство
        public string Name { get; set; }

        // События
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        // Конструкторы
        public MyObservableCollection(string name) : base() { Name = name; }
        public MyObservableCollection(string name, int length) : base(length) { Name = name; }
        public MyObservableCollection(string name, MyCollection<T> c) : base(c) { Name = name; }

        // Методы
        public new void Add(T item)
        {
            base.Add(item);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Добавлен элемент", item));
        }
        public new bool Remove(T item)
        {
            bool res = base.Remove(item);
            if (res)
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Удалён элемент", item));
            return res;

        }
        public new T this[T item]
        {
            get => base[item];
            set
            {
                T oldItem = base[item];
                base[item] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs($"Был заменён элемент {item.ToString()}", base[item]));
            }
        }
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(this, args);
        }
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(this, args);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}