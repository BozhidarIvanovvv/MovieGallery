using Microsoft.Extensions.DependencyInjection;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Actor;
using MovieGalleryApp.Core.Services;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieGalleryApp.Tests
{
    public class ActorServiceTests
    {
        private ServiceProvider _serviceProvider;
        private InMemoryDbContext _dbcontext;

        [SetUp]
        public async Task Setup()
        {
            _dbcontext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            _serviceProvider = serviceCollection
                .AddSingleton(sp => _dbcontext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IActorService, ActorService>()
                .BuildServiceProvider();

            var _repo = _serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(_repo);

        }

        [Test]
        public async Task GetAllActorsForAMovieReturnsDataProperly()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var resultData = new List<ActorCastVM>()
            {
                new ActorCastVM()
                {
                    FirstName = "Bob",
                    LastName = "Bobov",
                    ImgUrl = ""
                },
                new ActorCastVM()
                {
                    FirstName = "Bob 2",
                    LastName = "Bobov 2",
                    ImgUrl = ""
                }
            };

            var actors = await _actorService.GetAllActorsForAMovie(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            Assert.AreEqual(resultData.Count, actors.Count);
        }

        [Test]
        public async Task GetAllActorsForAMovieReturnsNoDataWhenMovieIdIsWrong()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var resultData = new List<ActorCastVM>()
            {
                new ActorCastVM()
                {
                    FirstName = "Bob",
                    LastName = "Bobov",
                    ImgUrl = ""
                },
                new ActorCastVM()
                {
                    FirstName = "Bob 2",
                    LastName = "Bobov 2",
                    ImgUrl = ""
                }
            };

            var actors = await _actorService.GetAllActorsForAMovie(Guid.Empty);

            Assert.AreNotEqual(resultData.Count, actors.Count);
        }

        [Test]
        public async Task AddActorAddsActorProperlyWhenMovieIdIsEmpty()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var actor = new ActorCastAddVM()
            {
                FirstName = "Test",
                LastName = "Testov",
                ImgUrl = ""
            };

            await _actorService.AddActor(actor, Guid.Empty);

            var actors = await _actorService.GetAllActors();

            Assert.IsTrue(actors.Count == 3);
        }

        [Test]
        public async Task AddActorAddsActorProperlyWhenMovieIdIsNotEmpty()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var actor = new ActorCastAddVM()
            {
                FirstName = "Test",
                LastName = "Testov",
                ImgUrl = ""
            };

            await _actorService.AddActor(actor, Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            var actors = await _actorService.GetAllActorsForAMovie(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            Assert.IsTrue(actors.Count == 3);
        }

        [Test]
        public async Task AddActorThrowsWhenActorWithTheSameNameIsPresent()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var actor = new ActorCastAddVM()
            {
                FirstName = "Test",
                LastName = "Testov",
                ImgUrl = ""
            };

            var actor2 = new ActorCastAddVM()
            {
                FirstName = "Test",
                LastName = "Testov",
                ImgUrl = ""
            };

            await _actorService.AddActor(actor, Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));
            
            Assert.CatchAsync<ArgumentException>(async () => await _actorService.AddActor(actor2, Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953")), "This actor already exists!");
        }

        [Test]
        public async Task GetAllActorsReturnsDataProperly()
        {
            var _actorService = _serviceProvider.GetService<IActorService>();

            var actor = new ActorCastAddVM()
            {
                FirstName = "Test",
                LastName = "Testov",
                ImgUrl = ""
            };

            var actor2 = new ActorCastAddVM()
            {
                FirstName = "Test 2",
                LastName = "Testov 2",
                ImgUrl = ""
            };

            await _actorService.AddActor(actor, Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));
            await _actorService.AddActor(actor2, Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            var actors = await _actorService.GetAllActorsForAMovie(Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"));

            Assert.IsTrue(actors.Count == 4);
        }

        [TearDown]
        public void TearDown()
        {
            _dbcontext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository _repo)
        {
            var actor = new Actor()
            {
                FirstName = "Bob",
                LastName = "Bobov",
                ImgUrl = ""
            };

            var actor2 = new Actor()
            {
                FirstName = "Bob 2",
                LastName = "Bobov 2",
                ImgUrl = ""
            };

            var movie = new Movie()
            {
                MovieId = Guid.Parse("d40ca362-e32a-4c4f-88bd-54c3f434c953"),
                Title = "Test Movie",
                Budget = "",
                Description = "",
                ImgUrl = "",
                Rating = 10,
                ReleaseDate = DateTime.Now,
            };

            movie.MovieActors.Add(
                new MovieActor()
                {
                    Actor = actor,
                    ActorId = actor.ActorId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            movie.MovieActors.Add(
                new MovieActor()
                {
                    Actor = actor2,
                    ActorId = actor2.ActorId,
                    Movie = movie,
                    MovieId = movie.MovieId,
                }
            );

            await _repo.AddAsync(movie);
            await _repo.SaveChangesAsync();
        }
    }
}