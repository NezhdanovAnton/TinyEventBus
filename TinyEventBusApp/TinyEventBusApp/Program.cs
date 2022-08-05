namespace TinyEventBusApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, EventBus World!");
            //Запускаем класс, в котором будут работать компоненты, перенесено, так как считаю, что точка входа в программу должна
            //работать с внешними аргументами и конфигурациями
            App.Run();
        }
    }
}