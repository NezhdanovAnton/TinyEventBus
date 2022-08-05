using EventBusDataContracts;

namespace Component
{
    /// <summary>
    /// Интерфей. Методы компонентов
    /// </summary>
    public interface ITinyComponent
    {
        public string GetName();
        public List<Event> GetRecievedEvents();
        public List<Event> GetSendEvents();
        public void Update(Event tinyEvent);

        public void Notify(Event tinyEvent);
        public void Subscribe(EventType eventType);
    }
}
