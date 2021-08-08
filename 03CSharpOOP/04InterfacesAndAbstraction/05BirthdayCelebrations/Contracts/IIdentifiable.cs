namespace BirthdayCelebrations.Contracts
{
    interface IIdentifiable
    {
        public string Id { get; }

        public bool CheckId(string fakeIdsLastDigits);
    }
}
