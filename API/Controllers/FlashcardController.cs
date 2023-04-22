using Services;
using Models;  
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashcardController : ControllerBase
{
     private readonly ILogger<FlashcardController> _logger;
     private readonly FService _service;

    public FlashcardController(ILogger<FlashcardController> logger, FService service)
    {
        this._logger = logger;
        this._service = service;
    }

    [HttpGet(Name = "GetAllFlashcards")]
    public List<Flashcard>? Get(){
        return this._service.getAllCards();
    }

    [HttpGet (Name = "GetFlashcardByID")]
    public Flashcard? GetByID([FromQuery] int id){
        if(id != 0){
            return this._service.getCardByID(id); 
        }
        return null;
    }

    [HttpDelete]
    public bool Delete([FromQuery] int id){
        if(id != 0){
            return this._service.deleteCard(id); 
        }
        return false;
    }

    [HttpPost]
    public Flashcard? Create([FromBody] Flashcard cardToBeCreated){
        if(cardToBeCreated != null){
            return this._service.createCard(cardToBeCreated);
        }
        return null;
    }

    [HttpPut("{id}")]
    public Flashcard? Update(int id, [FromBody] Flashcard cardToBeUpdated){
        if(cardToBeUpdated != null){
            return this._service.updateCard(id ,cardToBeUpdated);
        }
        return null;
    }
}