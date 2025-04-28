namespace PieShop.Models.Repositories;

public interface IPieRepository
{
    IEnumerable<Pie> GetPies();
    Pie GetPieById(int pieId);
    void AddPie(Pie pie);
    void UpdatePie(Pie pie);
    void DeletePie(int pieId);
    IEnumerable<Pie> GetPiesOfTheWeek();

    IEnumerable<Pie> SearchPies(string searchQuery);
}