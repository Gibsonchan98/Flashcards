using Models; 
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashcardController : ControllerBase
{
     private readonly ILogger<FlashcardController> _logger;

    public FlashcardController(ILogger<FlashcardController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllFlashcards")]
    public List<Flashcard>? Get(){
        return null;
    }

    [HttpGet (Name = "GetFlashcardByID")]
    public Flashcard? GetByID(int id){
        return null; 
    }

    [HttpDelete]
    public bool Delete(int id){
        return false;
    }

    [HttpPost]
    public Flashcard? Create(Flashcard cardToBeCreated){
        return null;
    }

    [HttpPut]
    public Flashcard? Update(Flashcard cardToBeUpdated){
        return null;
    }
}