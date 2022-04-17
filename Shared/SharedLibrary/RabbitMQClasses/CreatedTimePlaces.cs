using System;

namespace SharedLibrary.RabbitMQClasses
{
    public class CreatedTimePlaces
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}
