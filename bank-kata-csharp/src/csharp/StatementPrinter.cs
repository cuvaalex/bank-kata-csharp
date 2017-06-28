using System;
using System.Collections.Generic;

namespace com.finix.kata.bankkata
{
    public class StatementPrinter: IStatementPrinter 
    {

        private IConsole console;

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

		public void print(List<ITransaction> transactions)
		{
            console.print("date || credit || debit || balance");
		}

	}
}
