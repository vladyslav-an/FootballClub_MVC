using Microsoft.AspNetCore.Mvc;
using TestDemo.Data;
using TestDemo.Models;
using TestDemo.Repositories;

namespace TestDemo.Controllers;

public class ClubController : Controller
{
    private IClubRepository _clubRepository;

    public ClubController(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public IActionResult GetClub(Club club)
    {
        Club gettedClub = _clubRepository.GetClub(club.Name);
        return View(gettedClub);
    }

    // public void CreateClub([FromBody] CreateClub club)
    // {
    //     _clubRepository.CreateClub(club.Name, club.League);
    // }
    
    public IActionResult CreateClub(Club club)
    {
        _clubRepository.CreateClub(club.Name, club.League);
        return RedirectToAction("Index");
    }
    
    public List<Club> GetAllClubs()
    {
        return _clubRepository.GetAllClubs();
    }

    public IActionResult Index()
    {
        List<Club> allClubs = _clubRepository.GetAllClubs();
        return View(allClubs);
    }

    public IActionResult ActionsWithClubs()
    {
        return View();
    }
}