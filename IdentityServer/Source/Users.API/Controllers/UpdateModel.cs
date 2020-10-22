namespace User.API.Controllers
{
    public record UpdateModel
    {
        public string FirstName { get; }
        public string LastName { get; }

        public UpdateModel(string firstName, string lastName) =>
        (FirstName, LastName) = (firstName, lastName);
    }
}