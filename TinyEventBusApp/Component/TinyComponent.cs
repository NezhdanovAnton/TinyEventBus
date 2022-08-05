using EventBusDataContracts;

namespace Component
{
    /// <summary>
    /// Демо наследования и множественной реализации интерфейса, демо полиморфизм (без override)
    /// </summary>
    public class TinyComponent : BaseTinyComponent, ITinyComponent
    {
        public TinyComponent(string Name, int ComponentID) : base(Name, ComponentID)
        {
            
        }

        public string GetName()
        {
            return Name;
        }

        public List<Event> GetRecievedEvents()
        {
            return RecievedEvents;
        }

        public List<Event> GetSendEvents()
        {
            return SendEvents;
        }

        public void Notify(Event tinyEvent)
        {
            NotifyEventHandler(tinyEvent);
            SendEvents.Add(tinyEvent);
        }

        public void Subscribe(EventType eventType)
        {
            SubscribeEventHandler(eventType, this);
        }

        public void Update(Event tinyEvent)
        {
            RecievedEvents.Add(tinyEvent);
        }
    }
}