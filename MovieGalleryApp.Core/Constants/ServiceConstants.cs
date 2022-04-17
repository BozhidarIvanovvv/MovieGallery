using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Constants
{
    public static class ServiceConstants
    {
        public static class ActorServiceConstants
        {
            public const string ActorAlreadyExsists = "This actor already exists!";
        }

        public static class MovieServiceConstants
        {
            public const string MovieDoesNotExsist = "This movie doesn't exist!";
            public const string MovieAlreadyExists = "This movie already exists!";
            public const string MovieHasNoGenres = "This movie has no genres!";
            public const string MovieHasNoCountries = "This movie has no countries!";
            public const string MovieHasNoCinemas = "This movie has no cinemas!";
        }

        public static class CinemaServiceConstants
        {
            public const string CinemaAlreadyExsist = "This cinema already exists!";
            public const string CinemaDoesNotExsist = "This cinema does't exist!";
            public const string MovieDoesNotHaveAnyCinemas = "The movie: {0} doesn't have any cinemas!";
        }

        public static class CountryServiceConstants 
        {
            public const string CountryAlreadyExsist = "This country already exists!";
            public const string CountryDoesNotExsist = "This country doesn't exist!";
            public const string MovieDoesNotHaveAnyCountries = "The movie: {0} doesn't have any countries!";
        }

        public static class GenreServiceConstants
        {
            public const string GenreAlreadyExsist = "This genre already exists!";
            public const string GenreDoesNotExsist = "This genre doesn't exist!";
            public const string MovieDoesNotHaveAnyGenres = "The movie: {0} doesn't have any genres!";
        }
    }
}
