
using Microsoft.AspNetCore.Mvc;
using TestDemo.Data;
using TestDemo.Models;
using TestDemo.Repositories;

namespace TestDemo.Controllers;

public class PlayerController : Controller
{
    private IPlayerRepository repository;

    public PlayerController(IPlayerRepository repository)
    {
        this.repository = repository;
    }

    // [HttpPost]
    // public void CreatePlayer([FromBody] CreatePlayer player)
    // {
    //     repository.CreatePlayer(player.FirstName, player.LastName, player.ClubName);
    // }
    
    [HttpPost]
    public IActionResult CreatePlayer(Player player)
    {
        repository.CreatePlayer(player.FirstName, player.LastName, player.ClubName);
        return RedirectToAction("Index");
    }

    public IActionResult GetPlayer(Player player)
    {
        Player gettedPlayer = repository.GetPlayer(player.Id);
        return View(gettedPlayer);
    }

    public IActionResult GetPlayersByClub(Player player)
    {
        List <Player> selectedPlayers= repository.GetPlayersByClub(player.ClubName);
        return View(selectedPlayers);
    }

    public IActionResult Index()
    {
        List<Player> allPlayers = repository.GetAllPlayers(); 
        return View(allPlayers);
    }

    public IActionResult ActionsWithPlayers()
    {
        return View();
    }
}