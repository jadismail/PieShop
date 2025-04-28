using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.Models.Repositories;

namespace PieShop.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
  private readonly IPieRepository _pieRepository;

  public SearchController(IPieRepository pieRepository)
  {
    _pieRepository = pieRepository;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var allPies = _pieRepository.GetPies();
    return Ok(allPies);
  }

  [HttpGet("{id:int}")]
  public IActionResult GetPieById(int id)
  {
    if (_pieRepository.GetPies().All(p => p.PieId != id))
      return NotFound();
    return Ok(_pieRepository.GetPieById(id));
  }

  [HttpPost]
  public IActionResult SearchPies([FromBody] string searchQuery)
  {
    IEnumerable<Pie> pies = new List<Pie>();

    if (!string.IsNullOrEmpty(searchQuery))
      pies = _pieRepository.SearchPies(searchQuery);

    return new JsonResult(pies);
  }
}