using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScpoe = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScpoe.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Morbius",
                            Description = "Biochemist Michael Morbius tries to cure himself of a rare blood disease, but he inadvertently infects himself with a form of vampirism instead.",
                            Rating = 5.2,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNWExYzEwY2UtZTNhYi00MDRjLTg4YzYtN2QzN2E3MjIwY2Q5XkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_FMjpg_UX1000_.jpg",
                            Budget = "75 000 000 USD",
                            ReleaseDate = DateTime.Parse("04/01/2022"),
                        },
                        new Movie()
                        {
                            Title = "The Batman",
                            Description = "When the Riddler, a sadistic serial killer, begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
                            Rating = 8.3,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BOGE2NWUwMDItMjA4Yi00N2Y3LWJjMzEtMDJjZTMzZTdlZGE5XkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_.jpg",
                            Budget = "185 000 000 USD",
                            ReleaseDate = DateTime.Parse("03/04/2022"),
                        },
                        new Movie()
                        {
                            Title = "Spider-Man: No Way Home",
                            Description = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                            Rating = 8.5,
                            ImgUrl = "https://pbs.twimg.com/media/FEP_b6MVgAANu5M.jpg:large",
                            Budget = "200 000 000 USD",
                            ReleaseDate = DateTime.Parse("12/17/2021"),
                        },
                        new Movie()
                        {
                            Title = "Turning Red",
                            Description = "A 13-year-old girl named Meilin turns into a giant red panda whenever she gets too excited.",
                            Rating = 7.1,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNjY0MGEzZmQtZWMxNi00MWVhLWI4NWEtYjQ0MDkyYTJhMDU0XkEyXkFqcGdeQXVyODc0OTEyNDU@._V1_FMjpg_UX1000_.jpg",
                            Budget = "175 000 000 USD",
                            ReleaseDate = DateTime.Parse("02/21/2022"),
                        },
                        new Movie()
                        {
                            Title = "Uncharted",
                            Description = "Street-smart Nathan Drake is recruited by seasoned treasure hunter Victor \"Sully\" Sullivan to recover a fortune amassed by Ferdinand Magellan, and lost 500 years ago by the House of Moncada.",
                            Rating = 6.7,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMWEwNjhkYzYtNjgzYy00YTY2LThjYWYtYzViMGJkZTI4Y2MyXkEyXkFqcGdeQXVyNTM0OTY1OQ@@._V1_.jpg",
                            Budget = "120 000 000 USD",
                            ReleaseDate = DateTime.Parse("02/18/2022"),
                        },
                        new Movie()
                        {
                            Title = "Dune",
                            Description = "A noble family becomes embroiled in a war for control over the galaxy's most valuable asset while its heir becomes troubled by visions of a dark future.",
                            Rating = 8.1,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BN2FjNmEyNWMtYzM0ZS00NjIyLTg5YzYtYThlMGVjNzE1OGViXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg",
                            Budget = "165 000 000 USD",
                            ReleaseDate = DateTime.Parse("09/03/2021"),
                        },
                        new Movie()
                        {
                            Title = "The Godfather",
                            Description = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                            Rating = 9.2,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                            Budget = "6 000 000 USD",
                            ReleaseDate = DateTime.Parse("03/24/1972"),
                        },
                        new Movie()
                        {
                            Title = "Schindler's List",
                            Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                            Rating = 9.0,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UY1200_CR85,0,630,1200_AL_.jpg",
                            Budget = "22 000 000 USD",
                            ReleaseDate = DateTime.Parse("02/04/1994"),
                        },
                        new Movie()
                        {
                            Title = "The Dark Knight",
                            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                            Rating = 9.1,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg",
                            Budget = "185 000 000 USD",
                            ReleaseDate = DateTime.Parse("07/25/2008"),
                        },
                        new Movie()
                        {
                            Title = "The Lord of the Rings: The Return of the King",
                            Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                            Rating = 9.0,
                            ImgUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/e1cb0f101469109.5f1fad837297c.jpg",
                            Budget = "94 000 000 USD",
                            ReleaseDate = DateTime.Parse("01/10/2004"),
                        },
                        new Movie()
                        {
                            Title = "Pulp Fiction",
                            Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Rating = 8.9,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
                            Budget = "8 000 000 USD",
                            ReleaseDate = DateTime.Parse("10/14/1994"),
                        },
                        new Movie()
                        {
                            Title = "The Lord of the Rings: The Fellowship of the Ring",
                            Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                            Rating = 8.9,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_.jpg",
                            Budget = "93 000 000 USD",
                            ReleaseDate = DateTime.Parse("03/22/2002"),
                        },
                        new Movie()
                        {
                            Title = "The Lord of the Rings: The Two Towers",
                            Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                            Rating = 8.8,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
                            Budget = "94 000 000 USD",
                            ReleaseDate = DateTime.Parse("01/10/2003"),
                        },
                        new Movie()
                        {
                            Title = "The Good, the Bad and the Ugly",
                            Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                            Rating = 8.8,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNjJlYmNkZGItM2NhYy00MjlmLTk5NmQtNjg1NmM2ODU4OTMwXkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_.jpg",
                            Budget = "1 200 000 USD",
                            ReleaseDate = DateTime.Parse("12/23/1966"),
                        },
                        new Movie()
                        {
                            Title = "Inception",
                            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                            Rating = 8.8,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_FMjpg_UX1000_.jpg",
                            Budget = "160 000 000 USD",
                            ReleaseDate = DateTime.Parse("07/23/2010"),
                        },
                        new Movie()
                        {
                            Title = "Star Wars: Episode V - The Empire Strikes Back",
                            Description = "After the Rebels are brutally overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jedi training with Yoda, while his friends are pursued across the galaxy by Darth Vader and bounty hunter Boba Fett.",
                            Rating = 8.7,
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BYmU1NDRjNDgtMzhiMi00NjZmLTg5NGItZDNiZjU5NTU4OTE0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
                            Budget = "30 500 000 USD",
                            ReleaseDate = DateTime.Parse("04/23/1984"),
                        }
                    });
                }

                //Genres
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new List<Genre>()
                    {
                        new Genre()
                        {
                            GenreTitle = "Action",
                        },
                        new Genre()
                        {
                            GenreTitle = "Comedy",
                        },
                        new Genre()
                        {
                            GenreTitle = "Drama",
                        },
                        new Genre()
                        {
                            GenreTitle = "Fantasy",
                        },
                        new Genre()
                        {
                            GenreTitle = "Horror",
                        },
                        new Genre()
                        {
                            GenreTitle = "Mystery",
                        },
                        new Genre()
                        {
                            GenreTitle = "Romance",
                        },
                        new Genre()
                        {
                            GenreTitle = "Thriller",
                        },
                        new Genre()
                        {
                            GenreTitle = "Adventure",
                        },
                        new Genre()
                        {
                            GenreTitle = "Crime",
                        },
                        new Genre()
                        {
                            GenreTitle = "Historical",
                        },
                        new Genre()
                        {
                            GenreTitle = "Satire",
                        }
                    });                   
                }

                //Movie Genres
                if (!context.MovieGenres.Any())
                {
                    context.MovieGenres.AddRange(new List<MovieGenre>()
                    {
                        // The Lord of the Rings: The Fellowship of the Ring - Action, Fantasy, Adventure
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                        // Schindler's List: - Drama, Historical
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Schindler's List").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Schindler's List").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Historical").GenreId
                        },
                        // The Lord of the Rings: The Two Towers - Action, Fantasy, Adventure
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                        // Turning Red - Comedy, Fantasy
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Turning Red").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Comedy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Turning Red").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        // The Godfather - Crime, Drama
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Crime").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        // The Dark Knight - Action, Drama, Thriller, Crime, Mystery
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Thriller").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Crime").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Mystery").GenreId
                        },
                        // Spider-Man: No Way Home - Action, Fantasy, Comedy
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Comedy").GenreId
                        },
                        // Star Wars: Episode V - The Empire Strikes Back - Action, Adventure, Fantasy
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        // Dune - Action, Fantasy, Drama
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        // The Lord of the Rings: The Return of the King - Action, Fantasy, Adventure
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                        // Uncharted - Action, Adventure
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                        // Pulp Fiction - Drama, Comedy, Thriller, Crime
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Comedy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Thriller").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Crime").GenreId
                        },
                        // Morbius - Action, Drama, Fantasy
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        // The Batman - Action, Drama, Mystery
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Drama").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Mystery").GenreId
                        },
                        // Inception - Action, Fantasy, Thriller
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Fantasy").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Thriller").GenreId
                        },
                        //The Good, the Bad and the Ugly - Action, Adventure
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Action").GenreId
                        },
                        new MovieGenre()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            GenreId = context.Genres.First(g => g.GenreTitle == "Adventure").GenreId
                        },
                    });
                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        // The Batman
                        new Actor()
                        {
                            FirstName = "Robert",
                            LastName = "Pattinson",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNzk0MDQ5OTUxMV5BMl5BanBnXkFtZTcwMDM5ODk5Mg@@._V1_UY1200_CR136,0,630,1200_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Zoë",
                            LastName = "Kravitz",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BM2NmMWViOTYtOGJhYi00MzU2LWI5ODYtOGJhYzhkMWViODY5XkEyXkFqcGdeQXVyNjk2NTA3MTc@._V1_UY1200_CR80,0,630,1200_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Paul",
                            LastName = "Dano",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjMwMzE1OTc0OF5BMl5BanBnXkFtZTcwMDU2NTg0Nw@@._V1_.jpg"
                        },
                        // Schindler's List
                        new Actor()
                        {
                            FirstName = "Liam",
                            LastName = "Neeson",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjA1MTQ3NzU1MV5BMl5BanBnXkFtZTgwMDE3Mjg0MzE@._V1_UY1200_CR286,0,630,1200_AL_.jpg"
                        },
                        // Star Wars: Episode V - The Empire Strikes Back
                        new Actor()
                        {
                            FirstName = "Mark",
                            LastName = "Hamill",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BOGY2MjI5MDQtOThmMC00ZGIwLWFmYjgtYWU4MzcxOGEwMGVkXkEyXkFqcGdeQXVyMzM4MjM0Nzg@._V1_UY1200_CR753,0,630,1200_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Harrison",
                            LastName = "Ford",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTY4Mjg0NjIxOV5BMl5BanBnXkFtZTcwMTM2NTI3MQ@@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Carrie",
                            LastName = "Fisher",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjM4ODU5MDY4MV5BMl5BanBnXkFtZTgwODY1MjQ5MDI@._V1_.jpg"
                        },
                        // The Good, the Bad and the Ugly
                        new Actor()
                        {
                            FirstName = "Clint",
                            LastName = "Eastwood",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTg3MDc0MjY0OV5BMl5BanBnXkFtZTcwNzU1MDAxOA@@._V1_.jpg"
                        },
                        // Dune
                        new Actor()
                        {
                            FirstName = "Timothée",
                            LastName = "Chalamet",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BOWU1Nzg0M2ItYjEzMi00ODliLThkODAtNGEyYzRkZTBmMmEzXkEyXkFqcGdeQXVyNDk2Mzk2NDg@._V1_UY1200_CR138,0,630,1200_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Zendaya",
                            LastName = "Maree",
                            ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/28/Zendaya_-_2019_by_Glenn_Francis.jpg/1200px-Zendaya_-_2019_by_Glenn_Francis.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Oscar",
                            LastName = "Isaac",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTQ2ODE2NDQ5OF5BMl5BanBnXkFtZTcwOTU3OTM1OQ@@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Jason",
                            LastName = "Momoa",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BODJlNWQ4ZjUtYjRhNi00NGQ1LWE3YTItYjRmZGI3YzI4YTEyXkEyXkFqcGdeQXVyMTA2MDIzMDE5._V1_.jpg"
                        },
                        // Uncharted
                        new Actor()
                        {
                            FirstName = "Tom",
                            LastName = "Holland",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTA1MDc2MTEwNzReQTJeQWpwZ15BbWU4MDE2ODU1NzAy._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Mark",
                            LastName = "Wahlberg",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTU0MTQ4OTMyMV5BMl5BanBnXkFtZTcwMTQxOTY1NA@@._V1_.jpg"
                        },
                        // Spider-Man: No Way Home
                        new Actor()
                        {
                            FirstName = "Benedict",
                            LastName = "Cumberbatch",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjE0MDkzMDQwOF5BMl5BanBnXkFtZTgwOTE1Mjg1MzE@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Andrew",
                            LastName = "Garfield",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjE2MjI2OTk1OV5BMl5BanBnXkFtZTgwNTY1NzM4MDI@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Tobey",
                            LastName = "Maguire",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTYwMTI5NTM2OF5BMl5BanBnXkFtZTcwODk3MDQ2Mg@@._V1_UY1200_CR105,0,630,1200_AL_.jpg"
                        },
                        // Pulp Fiction
                        new Actor()
                        {
                            FirstName = "Quentin",
                            LastName = "Tarantino",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTgyMjI3ODA3Nl5BMl5BanBnXkFtZTcwNzY2MDYxOQ@@._V1_.jpg"
                        },
                        // Morbius
                        new Actor()
                        {
                            FirstName = "Jared",
                            LastName = "Leto",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTczMjUwNDUzMF5BMl5BanBnXkFtZTgwNDA4OTAzMTE@._V1_.jpg"
                        },
                        // The Godfather
                        new Actor()
                        {
                            FirstName = "Al",
                            LastName = "Pacino",
                            ImgUrl = "http://media.silive.com/entertainment_impact_tvfilm/photo/12-8pacinojpg-be944711fa383c11.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Robert",
                            LastName = "DeNiro",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjAwNDU3MzcyOV5BMl5BanBnXkFtZTcwMjc0MTIxMw@@._V1_UY1200_CR139,0,630,1200_AL_.jpg"
                        },
                        // The Lord of the Rings
                        new Actor()
                        {
                            FirstName = "Elijah",
                            LastName = "Wood",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NDIxMzQ5OF5BMl5BanBnXkFtZTcwNzAyNTA4Nw@@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Ian",
                            LastName = "McKellen",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTQ2MjgyNjk3MV5BMl5BanBnXkFtZTcwNTA3NTY5Mg@@._V1_UY264_CR8,0,178,264_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Viggo",
                            LastName = "Mortensen",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BNDQzOTg4NzA2Nl5BMl5BanBnXkFtZTcwMzkwNjkxMg@@._V1_UY1200_CR88,0,630,1200_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Sean",
                            LastName = "Astin",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjEzMjczOTQ1NF5BMl5BanBnXkFtZTcwMzI2NzYyMQ@@._V1_UY264_CR5,0,178,264_AL_.jpg"
                        },
                        // The Dark Knight
                        new Actor()
                        {
                            FirstName = "Christian",
                            LastName = "Bale",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTkxMzk4MjQ4MF5BMl5BanBnXkFtZTcwMzExODQxOA@@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Heath",
                            LastName = "Ledger",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTI2NTY0NzA4MF5BMl5BanBnXkFtZTYwMjE1MDE0._V1_UX178_CR0,0,178,264_AL_.jpg"
                        },
                        // Inception
                        new Actor()
                        {
                            FirstName = "Leonardo",
                            LastName = "DiCaprio",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMjI0MTg3MzI0M15BMl5BanBnXkFtZTcwMzQyODU2Mw@@._V1_UY264_CR9,0,178,264_AL_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Tom",
                            LastName = "Hardy",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTQ3ODEyNjA4Nl5BMl5BanBnXkFtZTgwMTE4ODMyMjE@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FirstName = "Cillian",
                            LastName = "Murphy",
                            ImgUrl = "https://www.pinkvilla.com/imageresize/cilian_murphy_peaky_blinders.jpg?width=752&format=webp&t=pvorg"
                        },
                        // Turning Red
                        new Actor()
                        {
                            FirstName = "Sandra",
                            LastName = "Oh",
                            ImgUrl = "https://m.media-amazon.com/images/M/MV5BMTMyNzYyNDE4MV5BMl5BanBnXkFtZTcwOTkxMDQ2NA@@._V1_.jpg"
                        }
                    });
                }

                //Movie Actors
                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActor>()
                    {
                        // The Lord of the Rings: The Fellowship of the Ring - Elijah Wood, Ian McKellen, Viggo Mortensen, Sean Astin
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Elijah" && a.LastName == "Wood").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Ian" && a.LastName == "McKellen").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Viggo" && a.LastName == "Mortensen").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Sean" && a.LastName == "Astin").ActorId
                        },
                        // Schindler's List - Liam Neeson
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Schindler's List").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Liam" && a.LastName == "Neeson").ActorId
                        },
                        // The Lord of the Rings: The Two Towers - Elijah Wood, Ian McKellen, Viggo Mortensen, Sean Astin
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Elijah" && a.LastName == "Wood").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Ian" && a.LastName == "McKellen").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Viggo" && a.LastName == "Mortensen").ActorId
                        },new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Sean" && a.LastName == "Astin").ActorId
                        },
                        // Turning Red - Sandra Oh
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Turning Red").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Sandra" && a.LastName == "Oh").ActorId
                        },
                        // The Godfather - Al Pacino, Robert DeNiro
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Al" && a.LastName == "Pacino").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Robert" && a.LastName == "DeNiro").ActorId
                        },
                        // The Dark Knight - Christian Bale, Heath Ledger 
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Christian" && a.LastName == "Bale").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Heath" && a.LastName == "Ledger").ActorId
                        },
                        // Spider-Man: No Way Home - Tom Holland, Zendaya, Benedict Cumberbatch, Andrew Garfield, Tobey Maguire
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Tom" && a.LastName == "Holland").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Zendaya" && a.LastName == "Maree").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Benedict" && a.LastName == "Cumberbatch").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Andrew" && a.LastName == "Garfield").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Tobey" && a.LastName == "Maguire").ActorId
                        },
                        // Star Wars: Episode V - The Empire Strikes Back - Mark Hamill, Harrison Ford, Carrie Fisher
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Mark" && a.LastName == "Hamill").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Harrison" && a.LastName == "Ford").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Carrie" && a.LastName == "Fisher").ActorId
                        },
                        // Dune - Timothée Chalamet, Zendaya Maree, Oscar Isaac, Jason Momoa
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Timothée" && a.LastName == "Chalamet").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Zendaya" && a.LastName == "Maree").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Oscar" && a.LastName == "Isaac").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Jason" && a.LastName == "Momoa").ActorId
                        },
                        // The Lord of the Rings: The Return of the King - Action, Fantasy, Adventure
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Elijah" && a.LastName == "Wood").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Ian" && a.LastName == "McKellen").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Viggo" && a.LastName == "Mortensen").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Sean" && a.LastName == "Astin").ActorId
                        },
                        // Uncharted - Tom Holland, Mark Wahlberg
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Tom" && a.LastName == "Holland").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Mark" && a.LastName == "Wahlberg").ActorId
                        },
                        // Pulp Fiction - Quentin Tarantino
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Quentin" && a.LastName == "Tarantino").ActorId
                        },
                        // Morbius - Jared Leto
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Jared" && a.LastName == "Leto").ActorId
                        },
                        // The Batman - Robert Pattinson, Zoë Kravitz, Paul Dano
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Robert" && a.LastName == "Pattinson").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Zoë" && a.LastName == "Kravitz").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Paul" && a.LastName == "Dano").ActorId
                        },
                        // Inception - Leonardo DiCaprio, Tom Hardy, Cillian Murphy
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Leonardo" && a.LastName == "DiCaprio").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Tom" && a.LastName == "Hardy").ActorId
                        },
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Cillian" && a.LastName == "Murphy").ActorId
                        },
                        // The Good, the Bad and the Ugly - Clint Eastwood
                        new MovieActor()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            ActorId = context.Actors.First(a => a.FirstName == "Clint" && a.LastName == "Eastwood").ActorId
                        },
                    });
                }

                //Countries
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(new List<Country>()
                    {
                        new Country()
                        {
                            CountryName = "United States",
                        },
                        new Country()
                        {
                            CountryName = "New Zealand",
                        },
                        new Country()
                        {
                            CountryName = "Spain",
                        },
                        new Country()
                        {
                            CountryName = "Germany",
                        },
                        new Country()
                        {
                            CountryName = "Italy",
                        }
                    });
                }

                //MovieCountries
                if (!context.MovieCountries.Any())
                {
                    context.MovieCountries.AddRange(new List<MovieCountry>() 
                    {
                        // The Lord of the Rings: The Fellowship of the Ring
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "New Zealand").CountryId
                        },
                        
                        // Schindler's List
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Schindler's List").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Lord of the Rings: The Two Towers
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "New Zealand").CountryId
                        },

                        // Turning Red
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Turning Red").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Godfather
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Dark Knight
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Spider-Man: No Way Home
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Star Wars: Episode V - The Empire Strikes Back
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Dune
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Lord of the Rings: The Return of the King
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "New Zealand").CountryId
                        },

                        // Uncharted
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Pulp Fiction
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Morbius
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Batman
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // Inception
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },

                        // The Good, the Bad and the Ugly
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "Italy").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "United States").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "Germany").CountryId
                        },
                        new MovieCountry()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            CountryId = context.Countries.First(a => a.CountryName == "Spain").CountryId
                        }
                    });
                }

                //Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Arena Deluxe Bulgaria Mall",
                            Location = "Sofia, 69 Bulgaria Blvd.",
                            ImgUrl = "https://programata.bg/img/gallery/place_6983.jpg",
                        },
                        new Cinema()
                        {
                            Name = "Arena The Mall",
                            Location = "Sofia, 115 Tsarigradsko shose Blvd.",
                            ImgUrl = "https://programata.bg/img/gallery/place_5981.jpg",
                        },
                        new Cinema()
                        {
                            Name = "Cine Grand Park Center",
                            Location = "Sofia, 2 Arsenalski Blvd.",
                            ImgUrl = "http://programata.bg/img/gallery/place_3681.jpg",
                        },
                        new Cinema()
                        {
                            Name = "Cinema City Paradise",
                            Location = "Sofia, 100 Cherni Vrah Blvd.",
                            ImgUrl = "https://programata.bg/img/gallery/place_7037.jpg",
                        }
                    });
                }

                //MovieCinemas
                if (!context.MovieCinemas.Any())
                {
                    context.MovieCinemas.AddRange(new List<MovieCinema>()
                    {
                        // The Lord of the Rings: The Fellowship of the Ring
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Fellowship of the Ring").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena Deluxe Bulgaria Mall").CinemaId
                        },
                        
                        // Schindler's List
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Schindler's List").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena Deluxe Bulgaria Mall").CinemaId
                        },

                        // The Lord of the Rings: The Two Towers
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Two Towers").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena Deluxe Bulgaria Mall").CinemaId
                        },

                        // Turning Red
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Turning Red").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena Deluxe Bulgaria Mall").CinemaId
                        },

                        // The Godfather
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Godfather").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena The Mall").CinemaId
                        },

                        // The Dark Knight
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Dark Knight").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena The Mall").CinemaId
                        },

                        // Spider-Man: No Way Home
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Spider-Man: No Way Home").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena The Mall").CinemaId
                        },

                        // Star Wars: Episode V - The Empire Strikes Back
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Star Wars: Episode V - The Empire Strikes Back").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Arena The Mall").CinemaId
                        },

                        // Dune
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Dune").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cine Grand Park Center").CinemaId
                        },

                        // The Lord of the Rings: The Return of the King
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Lord of the Rings: The Return of the King").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cine Grand Park Center").CinemaId
                        },

                        // Uncharted
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Uncharted").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cine Grand Park Center").CinemaId
                        },

                        // Pulp Fiction
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Pulp Fiction").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cine Grand Park Center").CinemaId
                        },

                        // Morbius
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Morbius").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cinema City Paradise").CinemaId
                        },

                        // The Batman
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Batman").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cinema City Paradise").CinemaId
                        },

                        // Inception
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "Inception").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cinema City Paradise").CinemaId
                        },

                        // The Good, the Bad and the Ugly
                        new MovieCinema()
                        {
                            MovieId = context.Movies.First(m => m.Title == "The Good, the Bad and the Ugly").MovieId,
                            CinemaId = context.Cinemas.First(a => a.Name == "Cinema City Paradise").CinemaId
                        },
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
