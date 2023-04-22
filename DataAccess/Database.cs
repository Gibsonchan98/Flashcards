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
            string query = "SELECT * FROM FLASHCARDS";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ques", cardToBeCreated.question);
            cmd.Parameters.AddWithValue("@ans", cardToBeCreated.question);

            int newId = (int) cmd.ExecuteScalar();
            cardToBeCreated.ID = newId; 
            if(newId != 0){
                return cardToBeCreated;
            }
            
            return null;

        } catch(SqlException){
            throw; 
        }                                
    }

    public bool deleteCard(int id)
    {
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("", conn);
            return false;
        } catch(SqlException){
            throw;
        }
    }

    public List<Flashcard>? getAllCards()
    {   
        List<Flashcard> flashcards = new();
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM FLASHCARDS";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows){
                while(reader.Read()){
                    int id = (int) reader["ID"];
                    string que = (string) reader["Question"];
                    string ans = (string) reader["Answer"];
                    bool corr = (bool) reader["Correct"];

                    Flashcard card = new Flashcard {
                        ID = id, 
                        question = que,
                        answer = ans, 
                        correct = corr
                    };

                    flashcards.Add(card);
                }
            }

            return flashcards;

        } catch(SqlException){
            throw; 
        }       
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