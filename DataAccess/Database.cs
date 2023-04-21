using Models;
using System;

namespace DataAccess;

public class Database : IDatabase
{
    private readonly string _connectionString;
    public Database(string connectionString){
       this._connectionString = connectionString;
    }
    public Flashcard createFlashcard(Flashcard cardToBeCreated)
    {
        throw new NotImplementedException();
    }

    public bool deleteCard(Flashcard cardToBeDeleted)
    {
        throw new NotImplementedException();
    }

    public List<Flashcard> getAllCards()
    {
        throw new NotImplementedException();
    }

    public Flashcard getCard(int id)
    {
        throw new NotImplementedException();
    }

    public Flashcard updateCard(Flashcard cardToUpdate)
    {
        throw new NotImplementedException();
    }
}