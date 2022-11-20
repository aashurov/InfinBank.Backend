using InfinBank.Application.Interfaces;
using System;

namespace InfinBank.Persistence.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}

 