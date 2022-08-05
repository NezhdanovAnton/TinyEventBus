using Component;
using TinyEventBusApp.EventBus;

namespace TinyEventBusApp
{
    /// <summary>
    /// Билдер компонентов
    /// </summary>
    public static class TinyComponentBuilder
    {
        public static void AddComponet(Dictionary<string, ITinyComponent> componentsStore, IEventBus eventBus)
        {
            Console.WriteLine("Enter component Name:");

            //Если ввели пустую строку, то имя компонента будет EmptyName
            string name = Console.ReadLine() ?? "EmptyName";
            int componentsCount = componentsStore.Count;
            
            //Если компонент с таким именем уже существует, добавляем к имени индекс
            if (componentsStore.ContainsKey(name))
                name += componentsCount.ToString();

            //Демо что типы разные
            Console.WriteLine("Is component RED?(true/false)");
            if (Console.ReadLine() == "true")
            {
                var redComponent = new REDTinyComponent(name, componentsCount);
                redComponent.SubscribeEventHandler = eventBus.Subscribe;
                redComponent.NotifyEventHandler = eventBus.Notify;
                componentsStore.Add(name, redComponent);
            }
            else
            {
                var component = new TinyComponent(name, componentsCount);
                component.SubscribeEventHandler = eventBus.Subscribe;
                component.NotifyEventHandler = eventBus.Notify;
                componentsStore.Add(name, component);
            }
            Console.WriteLine($"Component {name} added!(Press any key to continue...)");
            Console.ReadKey();

        }
    }
}
