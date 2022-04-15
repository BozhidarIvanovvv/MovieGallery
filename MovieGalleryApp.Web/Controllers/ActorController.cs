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
            IEnumerable<ActorCastVM> actors = null;

            try
            {
                actors = await _actorService.GetAllActorsForAMovie(Id);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View();
            }

            ViewBag.MovieId = Id;
            
            return View(actors);
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ActorCastVM> actors = null;

            try
            {
                actors = await _actorService.GetAllActors();
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View();
            }

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
                ViewData[MessageConstants.WarningMessage] = MessageConstants.InvalidModelState;
                return View(model);
            }

            try
            {
                await _actorService.AddActor(model, Id);
            }
            catch (ArgumentException ex)
            {
                ViewData[MessageConstants.ErrorMessage] = ex.Message;
                return View();
            }

            return Redirect($"/Actor/Cast/{Id}");
        }
    }
}
