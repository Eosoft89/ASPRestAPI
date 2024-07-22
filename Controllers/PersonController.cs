using ASPRestAPI.Models;
using ASPRestAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPRestAPI.Controllers;

[ApiController]
[Route("[controller]")]  //El atributo [Route] define una asignación al token [controller]. Dado que esta clase de controlador se denomina PersonController, este controlador controla las solicitudes a https://localhost:{PORT}/person.
public class PersonController : ControllerBase
{
    public PersonController()
    {
        
    }

    [HttpGet]
    public ActionResult<List<Person>> GetAll() => PersonService.GetAll(); //El tipo ActionResult es la clase base para todos los resultados de acción en ASP.NET Core.

    [HttpGet("{id}")]
    public ActionResult<Person> Get(int id)
    {
        var person = PersonService.Get(id);

        if(person == null)
            return NotFound();
        
        return person;
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        PersonService.Add(person);
        return CreatedAtAction(nameof(Get), new {id = person.Id}, person);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Person person)
    {
        if(id != person.Id)
            return BadRequest();

        var existingPerson = PersonService.Get(id);
        
        if(existingPerson is null)
            return NotFound();

        PersonService.Update(person);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = PersonService.Get(id);

        if(person is null)
            return NotFound();

        PersonService.Delete(id);

        return NoContent();    
    }
}