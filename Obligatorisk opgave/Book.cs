namespace Obligatorisk_opgave
{
    public class Book
    {
        //OPGAVE 1

        public int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Title}, {Price}";
        }


        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters");
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price must be between 0 and 1200");
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }

    }
}