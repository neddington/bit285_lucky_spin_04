using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.Services;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        //DIJ in 4 STEPS -
        //DONE: 0) Register the Repository class as a service in Program.cs 
        //DONE: 1) add an instance variable here of type Repository
        private readonly Repository _repository;



        /***
         * Constructor - TODO: 2) call for a DIJ Repository object to be passed to the constructor
         **/
        public SpinnerController(Repository repository)
        {
            //DONE: 3) save the DIJ Repository object into your instance variable
            _repository = repository;
        }

        /***
         * Index Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid)
            {
                // Return to Index view if the model is not valid
                return View();
            }


            // If the model is valid, redirect to the Spin action
            return RedirectToAction(nameof(Spin), player);
        }

        /***
         * Spin Action
         **/

        public IActionResult Spin(Player player)
        {
            //Create a new Spin with the player
            Spin spin = new Spin { Player = player };
            //DONE: Add to LuckList
            _repository.AddSpin(spin);


            return View("Spin", spin);
        }

        /***
         * ListSpins Action
         **/
        [HttpGet]
        public IActionResult LuckList()
        {
            //DONE: Pass the repository's Player Spins to the LuckList View
            var spins = _repository.PlayerSpins;
            return View(spins);
        }

    }
}

