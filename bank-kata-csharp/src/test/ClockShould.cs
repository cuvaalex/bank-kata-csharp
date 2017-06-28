using NUnit.Framework;
using System;
using NFluent;
using com.finix.kata.bankkata;

namespace com.finix.kata.bankkata.test
{
    [TestFixture()]
    public class ClockShould
    {
        [Test()]
        public void return_today_date_in_dd_MM_YYYY()
        {
            var clock = new TestableClock();

            String date = clock.TodayToString();

            Check.That(date).IsEqualTo("28/06/2017");
        }

        private class TestableClock: Clock
        {
            protected override DateTime Date
            {
                get
                {
                    return new DateTime(2017, 6, 28);
                }
            }
        }
    }

}
