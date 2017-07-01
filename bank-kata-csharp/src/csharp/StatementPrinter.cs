using System;
using System.Collections.Generic;
using System.Linq;

namespace com.finix.kata.bankkata
{
    public class StatementPrinter : IStatementPrinter
    {
        readonly string HEADER = "date || credit || debit || balance";
        readonly string STATEMENT_FORMAT = "{0} || {1:N} || {2:N} || {3:N}";

        private IConsole console;
        private Double totalTransaction = 0.0;

        public StatementPrinter(IConsole console)
        {
            this.console = console;
        }

        public void print(List<ITransaction> transactions)
        {
            var listOfString = transactions.Select(
                item => CreateSatementLine(item)).ToList();
            console.print(HEADER);
            listOfString.Reverse();
            listOfString.ForEach(console.print);
        }

        private string CreateSatementLine(ITransaction item)
        {
            totalTransaction += item.Amount;
            if(item.Amount < 0){
                return CreateWithdrawString(item);
            } else {
                return CreateDepositString(item);
            }
        }

        private string CreateDepositString(ITransaction transaction)
        {
            return String.Format(STATEMENT_FORMAT, transaction.Date, transaction.Amount, "", totalTransaction);
        }

        private string CreateWithdrawString(ITransaction transaction)
        {
            return String.Format(STATEMENT_FORMAT, transaction.Date, "", -transaction.Amount, totalTransaction);
		}
    }
}