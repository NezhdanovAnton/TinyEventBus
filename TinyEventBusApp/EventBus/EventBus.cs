using Component;
using EventBusDataContracts;

namespace TinyEventBusApp.EventBus
{
    /// <summary>
    /// Шина событий, реализация подписки и сообщений
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly List<KeyValuePair<EventType, ITinyComponent>> listeners;

        public EventBus()
        {
            listeners = new List<KeyValuePair<EventType, ITinyComponent>>();
        }
        public void Notify(Event tinyEvent)
        {
            listeners.Where(l => l.Key == tinyEvent.EventType)
                .ToList()
                .ForEach(l => l.Value.Update(tinyEvent));
        }

        public void Subscribe(EventType eventType, ITinyComponent tinyComponent)
        {
            listeners.Add(new KeyValuePair<EventType, ITinyComponent>(eventType, tinyComponent));
        }
    }
}