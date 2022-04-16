using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Constants
{
    public static class DatabaseConstants
    {
        public static class MovieEntityConstants
        {
            public const int TitleMaxLength = 208;
            public const int TitleMinLength = 3;
            public const int ImgUrlMaxLength = 2048;
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 10;
            public const int BudgetMaxLength = 50;
            public const int BudgetMinLength = 3;

            public const double RatingMinValue = 0.00;
            public const double RatingMaxValue = 10.00;
        }

        public static class CountryEntityConstants
        {
            public const int NameMaxLength = 56;
            public const int NameMinLength = 3;
            public const int ImgUrlMaxLength = 2048;
        }

        public static class GenreEntityConstants
        {
            public const int TitleMaxLength = 20;
            public const int TitleMinxLength = 3;
        }

        public static class ActorEntityConstants
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int FirstNameMinLength = 3;
            public const int LastNameMinLength = 3;
            public const int ImgUrlMaxLength = 2048;
        }
        public static class CinemaEntityConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int ImgUrlMaxLength = 2048;
            public const int LocationNameMaxLength = 200;
            public const int LocationNameMinLength = 3;
        }

        public static class ErrorMessageConstants
        {
            public static class ActorMessageConstants
            {
                public const string NameMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
                public const string ImgUrlMaxLength = "{0} cannot be longer than {1} characters!";
            }
            public static class CinemaMessageConstants
            {
                public const string NameMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
                public const string LocationMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
                public const string ImgUrlMaxLength = "{0} cannot be longer than {1} characters!";
            }
            public static class CountryMessageConstants
            {
                public const string NameMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
                public const string ImgUrlMaxLength = "{0} cannot be longer than {1} characters!";
            }
            public static class GenreMessageConstants
            {
                public const string NameMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
            }

            public static class MovieMessageConstants
            {
                public const string TitleMaxLength = "{0} cannot be longer than {1} characters and less than {2} characters!";
                public const string RatingMaxLength = "{0} must be in range {1} - {2}!";
                public const string ImgUrlMaxLength = "{0} cannot be longer than {1} characters!";
            }
        }
    }
}
