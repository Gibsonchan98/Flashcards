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
        return _database.getAllCards(); 
    }

    /// get card by id 
    public Flashcard? getCardByID(int id){
        return _database.getCard(id);
    }

    /// create card 
    public Flashcard? createCard(Flashcard newCard){
        return _database.createFlashcard(newCard);
    }

    /// update card
    public Flashcard? updateCard(int id, Flashcard updatedCard){
        Flashcard? oldCard = _database.getCard(id);
        if(oldCard != null && !oldCard.Equals(updatedCard) && oldCard.ID == updatedCard.ID){
            return _database.updateCard(updatedCard);
        }
        return null;
    } 

    /// delete card 
    public bool deleteCard(int id){
        Flashcard? card = _database.getCard(id);
        if(card != null){
            return _database.deleteCard(id);
        }
        return false; 
    }
}