using Microsoft.EntityFrameworkCore;
using TestDemo.Data;
using TestDemo.Models;

namespace TestDemo.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private FootballDbContext fc;

    public PlayerRepository(FootballDbContext context)
    {
        fc = context;
    }

    public Player GetPlayer(int id)
    {
        var player = fc.Players.Find(id);
        Console.WriteLine(player.FirstName+" "+player.LastName+" "+player.ClubName);
        return player;
    }

    public List<Player> GetPlayersByClub(string footballclub)
    {
        var players = (from user in fc.Players.Include(p => p.Club)
            where user.ClubName == footballclub
            select user).ToList();
        foreach (var player in players)
        {
            Console.WriteLine(player.FirstName+" "+player.LastName+" "+player.ClubName);
        }
        return players;
    }
    
    public List<Player> GetAllPlayers()
    {
        var players = (from user in fc.Players select user).ToList();
        foreach (var player in players)
        {
            Console.WriteLine(player.FirstName+" "+player.LastName+" "+player.ClubName);
        }
        return players;
    }

    public void CreatePlayer(string firstname, string lastname, string clubname)
    {
        if (firstname == null) firstname = "Artem";
        if (lastname == null) lastname = "Besedin";
        if (clubname == null) clubname = "dynamo";

        fc.Players.Add(new Player { FirstName = firstname, LastName = lastname, ClubName = clubname});
        fc.SaveChanges();
    }
}