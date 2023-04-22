using System; 
 
using Models; 

namespace DataAccess;

public interface IDatabase{
    List<Flashcard>? getAllCards();

    Flashcard? createFlashcard(Flashcard cardToBeCreated);

    Flashcard? updateCard(Flashcard cardToUpdate);

    Flashcard? getCard(int id); 

    bool deleteCard(int id);
}