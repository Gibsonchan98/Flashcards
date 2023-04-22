using Models;
using Microsoft.Data.SqlClient;
using System;

namespace DataAccess;

public class Database : IDatabase
{
    private readonly string _connectionString;
    public Database(string connectionString){
       this._connectionString = connectionString;
    }
    public Flashcard? createFlashcard(Flashcard cardToBeCreated)
    {
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("", conn);
            cmd.Parameters.AddWithValue("@ques", cardToBeCreated.question);
            cmd.Parameters.AddWithValue("@ans", cardToBeCreated.question);

            int newId = (int) cmd.ExecuteScalar();
            cardToBeCreated.ID = newId; 
            if(newId != 0){
                return cardToBeCreated;
            }

        } catch(SqlException){
            throw; 
        }                                
        return null;
    }

    public bool deleteCard(int id)
    {
        throw new NotImplementedException();
    }

    public List<Flashcard>? getAllCards()
    {   
        List<Flashcard> flashcards = new();
        throw new NotImplementedException();
    }

    public Flashcard? getCard(int id)
    {
        throw new NotImplementedException();
    }

    public Flashcard? updateCard(Flashcard cardToUpdate)
    {
        throw new NotImplementedException();
    }
}