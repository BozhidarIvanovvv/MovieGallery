using Microsoft.EntityFrameworkCore;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Actor;
using MovieGalleryApp.Infrastructure.Data;
using MovieGalleryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IApplicationDbRepository _repo;

        public ActorService(IApplicationDbRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ActorCastVM>> GetAllActorsForAMovie(Guid movieId) 
            => await _repo
                .All<MovieActor>(m => m.MovieId == movieId)
                .Select(m => new ActorCastVM()
                {
                    FirstName = m.Actor.FirstName,
                    LastName = m.Actor.LastName,
                    ImgUrl = m.Actor.ImgUrl
                })
                .ToListAsync();

        public async Task AddActor(ActorCastAddVM model, Guid movieId)
        {
            var dbActor = await _repo
                .All<Actor>(a => a.FirstName == model.FirstName && a.LastName == model.LastName)
                .FirstOrDefaultAsync();

            if (dbActor != null)
            {
                throw new ArgumentException("This actor already exists!");
            }

            var actor = new Actor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImgUrl = model.ImgUrl
            };

            actor.MovieActors.Add(new MovieActor
            {
                ActorId = actor.ActorId,
                MovieId = movieId,
            });
            
            await _repo.AddAsync(actor);
            _repo.SaveChanges();
        }
    }
}
