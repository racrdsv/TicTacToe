using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class TicTacToeController : Controller
    {
        private readonly TicTacToeModel _model;

        public TicTacToeController(TicTacToeModel model)
        {
            _model = model;
        }

        public IActionResult Index()
        {
            return View(_model);
        }

        public IActionResult MakeMove(int row, int col)
        {
            if (_model.MakeMove(row, col))
            {
                char winner;

                if (_model.IsGameOver(out winner))
                {
                    return RedirectToAction("GameOver", new { winner = winner });
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult GameOver(char winner)
        {
            ViewBag.Winner = winner;
            return View();
        }

    }
}
