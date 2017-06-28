using System;
namespace com.finix.kata.bankkata
{
    public class Clock : IClock
    {
        private DateTime date;

        public Clock()
        {
        }

        protected virtual DateTime Date { get => date; }

        public string TodayToString()
        {
            var today = Date;
            return today.ToString("dd/MM/yyyy");
        }
    }
}
