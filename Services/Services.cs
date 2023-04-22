using DataAccess; 
using Models;

namespace Services;

public class FService{
    
    private readonly Database _database; 

    public FService(Database db){
        this._database = db;
    }

    ///get all cards  
    public List<Flashcard>? getAllCards(){
        return null; 
    }

    /// get card by id 
    public Flashcard? getCardByID(int id){
        return null;
    }

    /// create card 
    public Flashcard? createCard(Flashcard newCard){
        return null;
    }

    /// update card
    public Flashcard? updateCard(int id, Flashcard updatedCard){
        return null;
    } 

    /// delete card 
    public bool deleteCard(int id){
        return false; 
    }
}