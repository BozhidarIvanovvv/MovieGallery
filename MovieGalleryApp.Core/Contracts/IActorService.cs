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
        Task<IEnumerable<ActorCastVM>> GetAllActorsForAMovie(Guid movieId);

        Task AddActor(ActorCastAddVM model, Guid movieId);
    }
}
