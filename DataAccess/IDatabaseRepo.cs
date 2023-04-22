using Models; 

namespace DataAccess;

public interface IDatabaseRepo{
    List<Flashcard>? getAllCards();

    Flashcard? createFlashcard(Flashcard cardToBeCreated);

    Flashcard? updateCard(Flashcard cardToUpdate);

    Flashcard? getCard(int id); 

    bool deleteCard(int id);
}