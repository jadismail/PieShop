using PieShop.Models.Context;

namespace PieShop.Models.Repositories;

public class PieRepository : IPieRepository
{
    private readonly PieContext _context;
    
    public PieRepository(PieContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Pie> GetPies()
    {
       return _context.Pies.ToList();
    }

    public Pie GetPieById(int pieId)
    {
        return _context.Pies.FirstOrDefault(p => p.PieId == pieId) ?? throw new InvalidOperationException();
    }

    public void AddPie(Pie pie)
    {
        _context.Pies.Add(pie);
        _context.SaveChanges();
    }

    public void UpdatePie(Pie pie)
    {
        ArgumentNullException.ThrowIfNull(pie);

        // Mark the pie entity as modified
        _context.Pies.Update(pie);
        _context.SaveChanges();
    }

    public void DeletePie(int pieId)
    {
        var reqPie = _context.Pies.FirstOrDefault(p => p.PieId == pieId);
        if (reqPie != null) _context.Pies.Remove(reqPie);
        _context.SaveChanges();
    }

    public IEnumerable<Pie> GetPiesOfTheWeek()
    {
       return _context.Pies.Where(p => p.IsPieOfWeek).ToList();
    }
}