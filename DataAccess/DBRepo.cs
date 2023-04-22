using Models;
using Microsoft.Data.SqlClient;
using System;

namespace DataAccess;

public class DBRepo : IDatabaseRepo
{
    private readonly string _connectionString;
    public DBRepo(string connectionString){
       this._connectionString = connectionString;
    }
    public Flashcard? createFlashcard(Flashcard cardToBeCreated)
    {
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "INSERT into FLASHCARDS (Question, Answer, Correct) VALUES (@ques, @ans, @corr)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ques", cardToBeCreated.question);
            cmd.Parameters.AddWithValue("@ans", cardToBeCreated.question);
            cmd.Parameters.AddWithValue("@corr", cardToBeCreated.category);

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
            string query = "DELETE FROM FLASHCARDS WHERE ID = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            return true;
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
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "SELECT * FROM FLASHCARDS WHERE ID = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows){
                while(reader.Read()){
                    int Id = (int) reader["ID"];
                    string que = (string) reader["Question"];
                    string ans = (string) reader["Answer"];
                    bool corr = (bool) reader["Correct"];

                    Flashcard card = new Flashcard {
                        ID = Id, 
                        question = que,
                        answer = ans, 
                        correct = corr
                    };

                    return card; 
                }
            }
            return null;

        } catch(SqlException){
            throw; 
        }   
    }

    public Flashcard? updateCard(Flashcard cardToUpdate)
    {
        Flashcard card = new();
        try{
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = "UPDATE FLASHCARDS SET Question = @ques, Answer = @ans, Correct = @corr WHERE ID = @Id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ques", cardToUpdate.question);
            cmd.Parameters.AddWithValue("@ans", cardToUpdate.answer);
            cmd.Parameters.AddWithValue("@corr", cardToUpdate.correct);
            cmd.Parameters.AddWithValue("@Id", cardToUpdate.ID);

            using SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows){
                reader.Read();

                card = new Flashcard {
                    ID = (int) reader["ID"], 
                    question = (string) reader["Question"],
                    answer = (string) reader["Answer"],
                    correct = (bool) reader["Correct"]
                }; 

            }

            return card;
        } catch(SqlException){
            throw;
        }
    }
}