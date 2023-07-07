using TestDemo.Models;

namespace TestDemo.Repositories;

public interface IClubRepository
{
    public Club GetClub(string name);
    public void CreateClub(string name, string league);
    public List<Club> GetAllClubs();
}