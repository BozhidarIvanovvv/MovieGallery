using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
                            ImgUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt5108870%2F&psig=AOvVaw0ecFAVkfWF9ogET3lNPEP8&ust=1649333323157000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCPjY5ciz__YCFQAAAAAdAAAAABAJ",
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
                            MovieId = Guid.Parse("BC3C6E04-A518-4974-8E9C-0B4F7EA9C07D"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("BC3C6E04-A518-4974-8E9C-0B4F7EA9C07D"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("BC3C6E04-A518-4974-8E9C-0B4F7EA9C07D"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        },
                        // Schindler's List: - Drama, Historical
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("609CC854-C77D-4555-A70E-2367C79A79E3"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("609CC854-C77D-4555-A70E-2367C79A79E3"),
                            GenreId = Guid.Parse("2749A311-69DE-430E-BC8F-D3A8EA7A38B0")
                        },
                        // The Lord of the Rings: The Two Towers - Action, Fantasy, Adventure
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("5F33652C-B882-419F-95C5-2882661E34EC"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("5F33652C-B882-419F-95C5-2882661E34EC"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("5F33652C-B882-419F-95C5-2882661E34EC"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        },
                        // Turning Red - Comedy, Fantasy
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("8BFB9A6F-3991-4122-9D60-29B19D6964F4"),
                            GenreId = Guid.Parse("BC27B002-B5B7-4E50-BD0A-742FFDB76FBD")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("8BFB9A6F-3991-4122-9D60-29B19D6964F4"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        // The Godfather - Crime, Drama
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("983B176C-E5D2-4792-A2E8-2BEB89DB072E"),
                            GenreId = Guid.Parse("832C44AC-D075-4B9C-888C-D4E38A1B61F0")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("983B176C-E5D2-4792-A2E8-2BEB89DB072E"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        // The Dark Knight - Action, Drama, Thriller, Crime, Mystery
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9ED3F7EC-BD63-4040-8B11-537DDEE7B241"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9ED3F7EC-BD63-4040-8B11-537DDEE7B241"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9ED3F7EC-BD63-4040-8B11-537DDEE7B241"),
                            GenreId = Guid.Parse("F4FCC005-7393-4B87-8B48-014044BDEC32")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9ED3F7EC-BD63-4040-8B11-537DDEE7B241"),
                            GenreId = Guid.Parse("832C44AC-D075-4B9C-888C-D4E38A1B61F0")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9ED3F7EC-BD63-4040-8B11-537DDEE7B241"),
                            GenreId = Guid.Parse("88737204-754B-40E4-9FC3-10843F27A337")
                        },
                        // Spider-Man: No Way Home - Action, Fantasy, Comedy
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("D519BB62-2AE3-4061-8241-5C573CB47169"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("D519BB62-2AE3-4061-8241-5C573CB47169"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("D519BB62-2AE3-4061-8241-5C573CB47169"),
                            GenreId = Guid.Parse("BC27B002-B5B7-4E50-BD0A-742FFDB76FBD")
                        },
                        // Star Wars: Episode V - The Empire Strikes Back - Action, Adventure, Fantasy
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("F4D25756-B160-4493-84D4-6FA7CAA0B967"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("F4D25756-B160-4493-84D4-6FA7CAA0B967"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("F4D25756-B160-4493-84D4-6FA7CAA0B967"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        // Dune - Action, Fantasy, Drama
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A3A33A65-F36C-4595-AF39-7E4AA037FCCB"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A3A33A65-F36C-4595-AF39-7E4AA037FCCB"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A3A33A65-F36C-4595-AF39-7E4AA037FCCB"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        // The Lord of the Rings: The Return of the King - Action, Fantasy, Adventure
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A1FE71E5-7460-40C0-ADD5-97CE8BE641D2"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A1FE71E5-7460-40C0-ADD5-97CE8BE641D2"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("A1FE71E5-7460-40C0-ADD5-97CE8BE641D2"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        },
                        // Uncharted - Action, Adventure
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("DFF3A26C-198B-48AA-A307-98E1B6493438"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("DFF3A26C-198B-48AA-A307-98E1B6493438"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        },
                        // Pulp Fiction - Drama, Comedy, Thriller, Crime
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("52DBA5D2-5FCC-4AE6-A299-B4F46B53990B"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("52DBA5D2-5FCC-4AE6-A299-B4F46B53990B"),
                            GenreId = Guid.Parse("BC27B002-B5B7-4E50-BD0A-742FFDB76FBD")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("52DBA5D2-5FCC-4AE6-A299-B4F46B53990B"),
                            GenreId = Guid.Parse("F4FCC005-7393-4B87-8B48-014044BDEC32")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("52DBA5D2-5FCC-4AE6-A299-B4F46B53990B"),
                            GenreId = Guid.Parse("832C44AC-D075-4B9C-888C-D4E38A1B61F0")
                        },
                        // Morbius - Action, Drama, Fantasy
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9F90B08B-9C06-4BE7-978F-B70C92C68772"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9F90B08B-9C06-4BE7-978F-B70C92C68772"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("9F90B08B-9C06-4BE7-978F-B70C92C68772"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        // The Batman - Action, Drama, Mystery
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("E45DC9BA-F777-4AA6-8983-E586DCEF2484"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("E45DC9BA-F777-4AA6-8983-E586DCEF2484"),
                            GenreId = Guid.Parse("52E8E275-3943-4964-83C7-75FB859B3D49")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("E45DC9BA-F777-4AA6-8983-E586DCEF2484"),
                            GenreId = Guid.Parse("88737204-754B-40E4-9FC3-10843F27A337")
                        },
                        // Inception - Action, Fantasy, Thriller
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("6ED2DF93-33B1-4928-AA59-E7DE6D1D413B"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("6ED2DF93-33B1-4928-AA59-E7DE6D1D413B"),
                            GenreId = Guid.Parse("3D8E372B-15CD-48CD-B330-9C2D53A28F67")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("6ED2DF93-33B1-4928-AA59-E7DE6D1D413B"),
                            GenreId = Guid.Parse("F4FCC005-7393-4B87-8B48-014044BDEC32")
                        },
                        //The Good, the Bad and the Ugly - Action, Adventure
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("D7B6E15E-4174-4194-B89D-FB4D9ADFA1A6"),
                            GenreId = Guid.Parse("4E6E55C5-5E32-4589-B8EC-A042E9BF4BF9")
                        },
                        new MovieGenre()
                        {
                            MovieId = Guid.Parse("D7B6E15E-4174-4194-B89D-FB4D9ADFA1A6"),
                            GenreId = Guid.Parse("54CFDD2C-2273-4D89-9719-9AC07FA0DF7D")
                        }
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
