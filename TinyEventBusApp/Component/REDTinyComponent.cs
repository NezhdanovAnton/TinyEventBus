using EventBusDataContracts;

namespace Component
{
    /// <summary>
    /// Демо наследования и множественной реализации интерфейса, демо полиморфизм (без override)
    /// </summary>
    public class REDTinyComponent : BaseTinyComponent, ITinyComponent
    {
        public REDTinyComponent(string Name, int ComponentID) : base(Name, ComponentID)
        {
        }

        public string GetName()
        {
            //Используется для того, чтобы отличать разные компоненты
            return $"{Name} from RED";
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
