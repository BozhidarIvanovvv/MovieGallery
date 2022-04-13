using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieGalleryApp.Core.Constants;
using MovieGalleryApp.Core.Contracts;
using MovieGalleryApp.Core.Models.Actor;

namespace MovieGalleryApp.Web.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cast(Guid Id)
        {
            var actors = await _actorService.GetAllActorsForAMovie(Id);

            ViewBag.MovieId = Id;

            return View(actors);
        }

        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(Guid Id)
        {
            ViewBag.MovieId = Id;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.Roles.MovieAdministrator)]
        public async Task<IActionResult> Add(Guid Id, ActorCastAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _actorService.AddActor(model, Id);

            return Redirect($"/Actor/Cast/{Id}");
        }
    }
}
