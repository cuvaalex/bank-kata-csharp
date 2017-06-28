using System;
namespace com.finix.kata.bankkata
{
    public class Clock : IClock
    {
        
        public Clock()
        {
        }

        protected virtual DateTime Date { get => DateTime.Now; }

        public string TodayToString()
        {
            var today = Date;
            return today.ToString("dd/MM/yyyy");
        }
    }
}
