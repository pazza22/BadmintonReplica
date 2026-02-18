using Microsoft.AspNetCore.Mvc;
using badminton4all.Models;
using badminton4all.Services;

namespace badminton4all.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: Player
        public IActionResult Index()
        {
            var players = _playerService.GetAllPlayers();
            return View(players);
        }

        // GET: Player/Details/5
        public IActionResult Details(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // GET: Player/Register
        public IActionResult Register()
        {
            ViewBag.Courts = _playerService.GetAvailableCourts();
            return View();
        }

        // POST: Player/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Player player, List<string> selectedCourts)
        {
            if (ModelState.IsValid)
            {
                player.PreferredCourts = selectedCourts ?? new List<string>();
                _playerService.AddPlayer(player);
                TempData["SuccessMessage"] = "Registration successful! Welcome to Badminton4All!";
                return RedirectToAction(nameof(Details), new { id = player.Id });
            }
            ViewBag.Courts = _playerService.GetAvailableCourts();
            return View(player);
        }

        // GET: Player/Edit/5
        public IActionResult Edit(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewBag.Courts = _playerService.GetAvailableCourts();
            return View(player);
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Player player, List<string> selectedCourts)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                player.PreferredCourts = selectedCourts ?? new List<string>();
                _playerService.UpdatePlayer(player);
                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction(nameof(Details), new { id = player.Id });
            }
            ViewBag.Courts = _playerService.GetAvailableCourts();
            return View(player);
        }

        // GET: Player/Delete/5
        public IActionResult Delete(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _playerService.DeletePlayer(id);
            TempData["SuccessMessage"] = "Player deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Player/Rankings
        public IActionResult Rankings()
        {
            var players = _playerService.GetAllPlayers();
            return View(players);
        }
    }
}
