using TestDemo.Data;
using TestDemo.Models;

namespace TestDemo.Repositories;

public class ClubRepository : IClubRepository
{
    private FootballDbContext fc;

    public ClubRepository(FootballDbContext context)
    {
        fc = context;
    }

    public Club GetClub(string name)
    {
        var club = fc.Clubs.Find(name);
        Console.WriteLine(club.Name+" "+club.League);
        return club;
    }

    public void CreateClub(string name, string league)
    {
        if (name == null) name = "logName";
        if (league == null) league = "logLeague";
        fc.Clubs.Add(new Club{Name = name, League = league});
        fc.SaveChanges();
    }

    public List<Club> GetAllClubs()
    {
        var clubs = (from club in fc.Clubs select club ).ToList();
        foreach (var club in clubs)
        {
            Console.WriteLine(club.Name+" "+club.League);
        }
        return clubs;
    }
}