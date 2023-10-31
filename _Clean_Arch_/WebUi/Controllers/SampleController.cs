using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Application;

namespace WebUi.Controllers;

public class SampleController : Controller
{
  /*
  readonly ISampleService _service;
  private readonly ILogger<SampleController> _logger;

  public SampleController(ISampleService service, ILogger<SampleController> logger)
  {
    _service = service;
    _logger = logger;
  }

  [HttpGet]
  public async Task<IActionResult> Index()
  {
    var result = await _service.GetAll();
    return View(result);
  }

  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(SampleDto dto)//public IActionResult Create([Bind("Id,Name")] SampleDto dto)
  {
    if (ModelState.IsValid)
    {
      _service.Add(dto);
      return RedirectToAction(nameof(Index));
    }
    return View(dto);
  }

  [HttpGet]
  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null) return NotFound();

    var dto = await _service.Get(id ?? 0);
    if (dto == null) return NotFound();

    return View(dto);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(SampleDto dto)
  {
    if (ModelState.IsValid)
    {
      try
      {
        _service.Update(dto);
      }
      catch (Exception)
      {
        throw;
      }
      return RedirectToAction(nameof(Index));
    }
    return View(dto);
  }

  [HttpGet]
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return NotFound();

    var dto = await _service.Get(id ?? 0);
    if (dto == null) return NotFound();

    return View(dto);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DoDelete(int? id) //<form asp-action="Delete">
  {
    _service.Remove(id ?? 0);
    return RedirectToAction(nameof(Index));
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
*/
}
