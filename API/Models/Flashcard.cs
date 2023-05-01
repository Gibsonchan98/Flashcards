using System.ComponentModel.DataAnnotations; 

namespace Models; 

public class Flashcard{
    
    public Flashcard(){}

    public Flashcard(string q, string a){
        this.question = q; 
        this.answer = a; 
    }

    public int ID {get; set;}

    [Required]
    [MaxLength(500)]
    public string question{get; set;} = "?";

    [Required]
    [MaxLength(500)]
    public string answer{get; set;} =  "?";

    public bool correct{get; set;} = false; 

    [Required]
    [MaxLength(150)]
    public string category{get; set;} = "?";

    public override string ToString()
    {
        return $"{question}: {answer}";
    }

     // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Flashcard card = (Flashcard)obj;

        if(card.answer != this.answer || this.question!= card.question || this.category != card.category || this.correct != card.correct){
            return false;
        }
        
        return true;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
