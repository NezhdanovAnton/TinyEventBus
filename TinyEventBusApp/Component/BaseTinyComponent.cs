using EventBusDataContracts;

namespace Component
{
    /// <summary>
    /// Базовый класс, создание делегат, свойства компонентов
    /// </summary>
    public abstract class BaseTinyComponent
    {
        internal readonly string Name;
        internal readonly int ComponentID;
        public readonly List<Event> RecievedEvents;
        public readonly List<Event> SendEvents;

        public delegate void NotifyEvent(Event evt);
        public NotifyEvent NotifyEventHandler { get; set; }

        public delegate void SubscribeEvent(EventType eventType, ITinyComponent component);
        public SubscribeEvent SubscribeEventHandler { get; set; }

        public BaseTinyComponent(string Name, int ComponentID)
        {
            this.Name = Name;
            this.ComponentID = ComponentID;
            RecievedEvents = new List<Event>();
            SendEvents = new List<Event>();
        }
    }
}
