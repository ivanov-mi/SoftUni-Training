namespace Chainblock
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionsById;

        public Chainblock()
        {
            this.transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException($"Transaction with {tx.Id} already exists.");
            }

            this.transactionsById.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if(this.Contains(id) == false)
            {
                throw new ArgumentException("Id does not exist.");
            }

            var tx = this.GetById(id);
            tx.Status = newStatus;
        }

        public bool Contains(ITransaction tx) => this.Contains(tx.Id);

        public bool Contains(int id) => this.transactionsById.ContainsKey(id);

        //TODO IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {

            throw new System.NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} doesn`t exist.");
            }
            return this.transactionsById[id];
        }

        //TODO IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {

            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var filteredTransactions = this.transactionsById.Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount);

            if (filteredTransactions.Any() == false)
            {
                throw new InvalidOperationException("No transactions with the given status.");
            }

            return filteredTransactions;
        }

        //TODO IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        //TODO IEnumerator<ITransaction> GetEnumerator()
        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (this.Contains(id) == false)
            {
                throw new InvalidOperationException("Non existing Id.");
            }

            this.transactionsById.Remove(id);
        }

        //TODO IEnumerable.GetEnumerator()
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
