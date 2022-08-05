namespace EventBusDataContracts
{
    /// <summary>
    /// Типы событий, на которые могут подписываться компоненты
    /// </summary>
    public enum EventType
    {
        All = 0,
        Pawn = 1,
        Knight = 2,
        King = 3,
        Bishop = 4,
        Rook = 5,
        Queen = 6
    }
}
