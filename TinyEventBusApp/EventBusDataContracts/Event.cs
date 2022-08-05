namespace EventBusDataContracts
{
    /// <summary>
    /// Модель события, не содержит ИД отправителя исходя из требований ТЗ
    /// </summary>
    public class Event
    {
        public EventType EventType { get; set; }
        public string EventBody { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}