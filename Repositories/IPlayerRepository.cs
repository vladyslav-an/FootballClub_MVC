using TestDemo.Models;

namespace TestDemo.Repositories;

public interface IPlayerRepository
{
    public Player GetPlayer(int id);
    public void CreatePlayer(string firstname, string lastname, string clubname);
    public List<Player> GetPlayersByClub(string footballclub);
    public List<Player> GetAllPlayers();
}