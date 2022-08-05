using Component;
using TinyEventBusApp.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBusDataContracts;

namespace TinyEventBusApp
{
    /// <summary>
    /// Приложение
    /// </summary>
    public class App
    {
        /// <summary>
        /// Основной рабочий цикл приложения. выход из него по комманде "/e"
        /// </summary>
        public static void Run()
        {
            bool exit = false;
            //Словарь с компонентами
            Dictionary<string, ITinyComponent> components = new();
            //Шина событий
            IEventBus eventBus = new EventBus.EventBus();
            //Цикл, до ввода команды "/e"
            while (!exit)
            {
                //Покомпонентное отображение отправленных и полученных событий
                ShowStatistics(components);

                //Предложение пользователю ввести команду
                Console.WriteLine("Enter control action key (/? - for help)");
                var control = Console.ReadLine();

                //Обработчик команды
                switch (control)
                {
                    //Добавление компонента
                    case "/a":
                        Console.Clear();
                        TinyComponentBuilder.AddComponet(components, eventBus);
                        break;
                    //Компонент подписывается на события определенного типа
                    case "/s":
                        Console.Clear();
                        AddSubscription(components, eventBus);
                        break;
                    //Компонент отправляе событие
                    case "/se":
                        Console.Clear();
                        SendMessage(components, eventBus);
                        break;
                    //Выход
                    case "/e":
                        exit = true;
                        break;
                    //По-умолчанию и помощь
                    default:
                    case "/?":
                        Console.WriteLine(@"/? - this help
    /a - add component
    /s - subscribe
    /se - send event
    /e - exit
    Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Отправка сообщения
        private static void SendMessage(Dictionary<string, ITinyComponent> components, IEventBus eventBus)
        {
            //Получение типа компонента
            EventType type = EnterEventType();

            //подсказка ввиде имен компонентоы
            foreach (var key in components.Keys)
            {
                Console.WriteLine(key);
            }

            //Ввод имени
            Console.WriteLine("Enter Existing component name");
            string name = Console.ReadLine()??String.Empty;
            if (string.IsNullOrEmpty(name) && !components.ContainsKey(name))
            {
                Console.WriteLine("Can't recognize Name");
                return;
            }

            //Создание события
            Console.WriteLine("Enter event message");
            var tinyEvent = new Event()
            {
                EventBody = Console.ReadLine()??String.Empty,
                EventType = type,
                TimeStamp = DateTime.Now
            };
            //Отправка сообщения из компонента, используя делигирование
            components[name].Notify(tinyEvent);
        }

        //Подпись компонента на событие
        private static void AddSubscription(Dictionary<string, ITinyComponent> components, IEventBus eventBus)
        {
            //Получение типа компонента
            EventType type = EnterEventType();

            //подсказка ввиде имен компонентоы
            foreach (var key in components.Keys)
            {
                Console.WriteLine(key);
            }
            //Ввод имени компонента
            Console.WriteLine("Enter Existing component name");
            string name = Console.ReadLine()??String.Empty;
            if (string.IsNullOrEmpty(name) || !components.ContainsKey(name))
            {
                Console.WriteLine("Can't recognize Name");
                return;
            }

            //Подпись на событие
            components[name].Subscribe(type);

        }

        //Получение типа событий
        private static EventType EnterEventType()
        {
            
            Console.WriteLine(@"Chose  Event Type by id to Subscribe
    All = 0,
    Pawn = 1,
    Knight = 2,
    King = 3,
    Bishop = 4,
    Rook = 5,
    Queen = 6");
            return (EventType)int.Parse(Console.ReadLine() ?? "0"); ;
        }

        /// <summary>
        /// Показать компоненты, отправленные и полученные события
        /// </summary>
        /// <param name="components"></param>
        private static void ShowStatistics(Dictionary<string, ITinyComponent> components)
        {
            Console.Clear();

            foreach(var component in components)
            {
                var tmpForegroundColor = Console.ForegroundColor;
                //демо, что компоненты разных типов
                if ( component.Value is REDTinyComponent)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Name: {component.Value.GetName()}");
                Console.WriteLine("<---- Recieved");
                component.Value.GetRecievedEvents().ForEach(e => Console.WriteLine($"<----{e.TimeStamp} {e.EventType} {e.EventBody}"));
                Console.WriteLine("<---- Send");
                component.Value.GetSendEvents().ForEach(e => Console.WriteLine($"---->{e.TimeStamp} {e.EventType} {e.EventBody}"));

                Console.ForegroundColor = tmpForegroundColor;
            }
        }
    }
}
