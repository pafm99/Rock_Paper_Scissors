using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
 
namespace Game.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {   
            ViewBag.gamesWon = HttpContext.Session.GetInt32("gamesWon");
            ViewBag.playerpick = HttpContext.Session.GetString("PlayerPick");
            ViewBag.computerpick = HttpContext.Session.GetString("ComputerPick");
            ViewBag.result = HttpContext.Session.GetString("result");
            ViewBag.gamesPlayed = HttpContext.Session.GetInt32("gamesPlayed");
            return View("index");
        }

        [HttpPost]
        [Route("game")]
        public IActionResult PlayGame(string choice)
        {   
            Console.WriteLine(choice);
            Random rand = new Random();
            int compRoll = rand.Next(1,4);
            Console.WriteLine(compRoll);
            string compPick = "";
            int count = 0;
            int playerWins = 0;

            if(compRoll == 1){
                compPick = "rock";
            }
            if(compRoll == 2){
                compPick = "paper";
            }
            if(compRoll == 3){
                compPick = "scissor";
            }

            if(choice == "rock" && compPick == "rock"){
                HttpContext.Session.SetString("PlayerPick", "rock");
                HttpContext.Session.SetString("ComputerPick", "rock");
                HttpContext.Session.SetString("result", "Tie");
            }
            if(choice == "rock" && compPick == "paper"){
                HttpContext.Session.SetString("PlayerPick", "rock");
                HttpContext.Session.SetString("ComputerPick", "paper");
                HttpContext.Session.SetString("result", "Computer Wins");
            }
            if(choice == "rock" && compPick == "scissor"){
                HttpContext.Session.SetString("PlayerPick", "rock");
                HttpContext.Session.SetString("ComputerPick", "scissor");
                HttpContext.Session.SetString("result", "Player Wins");
                playerWins++;
            }

            if(choice == "scissor" && compPick == "rock"){
                HttpContext.Session.SetString("PlayerPick", "scissor");
                HttpContext.Session.SetString("ComputerPick", "rock");
                HttpContext.Session.SetString("result", "Computer Wins");
            }
            if(choice == "scissor" && compPick == "paper"){
                HttpContext.Session.SetString("PlayerPick", "scissor");
                HttpContext.Session.SetString("ComputerPick", "paper");
                HttpContext.Session.SetString("result", "Player Wins");
                playerWins++;
            }
            if(choice == "scissor" && compPick == "scissor"){
                HttpContext.Session.SetString("PlayerPick", "scissor");
                HttpContext.Session.SetString("ComputerPick", "scissor");
                HttpContext.Session.SetString("result", "Tie");
            }

            if(choice == "paper" && compPick == "rock"){
                HttpContext.Session.SetString("PlayerPick", "paper");
                HttpContext.Session.SetString("ComputerPick", "rock");
                HttpContext.Session.SetString("result", "Player Wins");
                playerWins++;
            }
            if(choice == "paper" && compPick == "paper"){
                HttpContext.Session.SetString("PlayerPick", "paper");
                HttpContext.Session.SetString("ComputerPick", "paper");
                HttpContext.Session.SetString("result", "Tie");
            }
            if(choice == "paper" && compPick == "scissor"){
                HttpContext.Session.SetString("PlayerPick", "paper");
                HttpContext.Session.SetString("ComputerPick", "scissor");
                HttpContext.Session.SetString("result", "Computer Wins");
            }
            count++;
            HttpContext.Session.SetInt32("gamesWon", playerWins);
            HttpContext.Session.SetInt32("gamesPlayed", count); 
            return RedirectToAction("index");
        }
    }
}