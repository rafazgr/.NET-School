namespace BookCatalogTask
{
    public class Author
    {
        private string _firstName;
        private string _lastName;

        public const int MAX_LENGTH = 200;

        public string FirstName
        {
            get => _firstName;
            init => ValidateAndSetProperty(value, MAX_LENGTH, nameof(FirstName), ref _firstName);
        }

        public string LastName
        {
            get => _lastName;
            init => ValidateAndSetProperty(value, MAX_LENGTH, nameof(LastName), ref _lastName);
        }

        public DateTime? DateOfBirth { get; init; }

        private static void ValidateAndSetProperty(string value, int maxLength, string propertyName, ref string field)
        {
            if (value == null)
            {
                throw new ArgumentNullException(propertyName, $"{propertyName} cannot be null.");
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{propertyName} cannot exceed {maxLength} characters.", propertyName);
            }

            field = value;
        }
    }
}
