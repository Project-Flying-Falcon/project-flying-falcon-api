using System;
namespace Flying.Falcon.Domain.Catalog
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }

        // Required by EF Core to load objects from the database
        // Think of it like a no-arg constructor Java sometimes needs for frameworks
        protected Rating() { }

        public Rating(int stars, string userName, string review)
        {
            if (stars < 1 || stars > 5)
            {
                throw new ArgumentException("Star rating must be an integer of: 1, 2, 3, 4, 5.");
            }
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("UserName cannot be null.");
            }
            this.Stars = stars;
            this.UserName = userName;
            this.Review = review;
        }
    }
}