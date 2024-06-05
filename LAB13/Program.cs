using LibraryClass;
using LibraryLab12;
namespace LAB13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyObservableCollection<BankCard> table1 = new MyObservableCollection<BankCard>("table1", 0);
            MyObservableCollection<BankCard> table2 = new MyObservableCollection<BankCard>("table2", 0);
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            int answer = 1;
            while (answer != 9)
            {
                try
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Создать две коллекции и два журнала к ним.");
                    Console.WriteLine("2. Распечатать коллекцию 1");
                    Console.WriteLine("3. Распечатать коллекцию 2");
                    Console.WriteLine("4. Добавить элемент в коллекцию 1");
                    Console.WriteLine("5. Добавить элемент в коллекцию 2");
                    Console.WriteLine("6. Удалить элемент из коллекции 1");
                    Console.WriteLine("7. Удалить элемент из коллекции 2");
                    Console.WriteLine("8. Изменить элемент в коллекции 1");
                    Console.WriteLine("9. Изменить элемент в коллекции 2");
                    Console.WriteLine("10. Вывести данные журнала 1");
                    Console.WriteLine("11. Вывести данные журнала 2");
                    Console.WriteLine("12. Выйти");
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            GenerateCollectionsAndJournals(ref table1, ref table2, ref journal1, ref journal2);
                            break;
                        case 2:
                            if (table1.Count > 0)
                            {
                                Console.WriteLine("Первая коллекция:");
                                table1.PrintCollection();
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Первая коллекция пуста!");
                            break;
                        case 3:
                            if (table2.Count > 0)
                            {
                                Console.WriteLine("Вторая коллекция:");
                                table2.PrintCollection();
                            }
                            else
                                Console.WriteLine("Вторая коллекция пуста!");
                            break;
                        case 4:
                            BankCard card1 = new BankCard();
                            card1.RandomInit();
                            table1.Add(card1);
                            break;
                        case 5:
                            BankCard card2 = new BankCard();
                            card2.RandomInit();
                            table2.Add(card2);
                            break;
                        case 6:
                            Console.WriteLine("Введите данные для элемента, который хотите удалить из коллекции 1:");
                            BankCard cardToRemove1 = new BankCard();
                            cardToRemove1.Init();
                            if (table1.Remove(cardToRemove1))
                            {
                                Console.WriteLine("Элемент успешно удален из коллекции 1.");
                            }
                            else
                            {
                                Console.WriteLine("Элемент не найден в коллекции 1.");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Введите данные для элемента, который хотите удалить из коллекции 2:");
                            BankCard cardToRemove2 = new BankCard();
                            cardToRemove2.Init();
                            if (table2.Remove(cardToRemove2))
                            {
                                Console.WriteLine("Элемент успешно удален из коллекции 2.");
                            }
                            else
                            {
                                Console.WriteLine("Элемент не найден в коллекции 2");
                            }
                            break;
                        case 8:
                            Console.WriteLine("Введите данные для элемента, который собираетесь изменить:");
                            BankCard item = new BankCard();
                            item.Init();
                            BankCard newItem = new BankCard();
                            newItem.RandomInit();
                            table1[item] = newItem;
                            break;
                        case 9:
                            Console.WriteLine("Введите данные для элемента, который собираетесь изменить:");
                            BankCard item2 = new BankCard();
                            item2.Init();
                            BankCard newItem2 = new BankCard();
                            newItem2.RandomInit();
                            table2[item2] = newItem2;
                            break;
                        case 10:
                            journal1.Print();
                            break;
                        case 11:
                            journal2.Print();
                            break;
                        case 12:
                            Console.WriteLine("Программа завершена");
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Попробуйте еще раз");
                            break;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        static void GenerateCollectionsAndJournals(ref MyObservableCollection<BankCard> col1, ref MyObservableCollection<BankCard> col2, ref Journal jor1, ref Journal jor2)
        {
            Console.WriteLine("Введите желаемую длину коллекций:");
            int len;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out len) && len > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Попробуйте ввести натуральное число");
                }
            }
            col1 = new MyObservableCollection<BankCard>("table1", len);
            col2 = new MyObservableCollection<BankCard>("table2", len);
            jor1 = new Journal();
            jor2 = new Journal();
            col1.CollectionCountChanged += jor1.WriteRecord;
            col1.CollectionReferenceChanged += jor1.WriteRecord;
            col2.CollectionCountChanged += jor2.WriteRecord;
            col2.CollectionReferenceChanged += jor2.WriteRecord;
            Console.WriteLine("Коллекции и журналы к ним успешно созданы");
        }
    }
}