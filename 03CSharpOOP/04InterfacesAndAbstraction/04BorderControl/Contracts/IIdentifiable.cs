namespace BorderControl.Contracts
{
    interface IIdentifiable
    {
        public string Id { get; }

        public bool CheckId(string fakeIdsLastDigits);
    }
}
