using Component;
using EventBusDataContracts;

namespace TinyEventBusApp.EventBus
{
    //Интерфейс шины
    public interface IEventBus
    {
        public void Notify(Event tinyEvent);

        public void Subscribe(EventType eventType, ITinyComponent tinyComponent);
    }
}
