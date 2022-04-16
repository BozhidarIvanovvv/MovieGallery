using MovieGalleryApp.Core.Models.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Core.Contracts
{
    public interface IActorService
    {
        Task<ICollection<ActorCastVM>> GetAllActorsForAMovie(Guid movieId);
        Task<ICollection<ActorCastVM>> GetAllActors();
        Task AddActor(ActorCastAddVM model, Guid movieId);
    }
}
