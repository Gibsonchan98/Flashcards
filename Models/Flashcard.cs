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

    public string category{get; set;} = "";

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

        if(card.answer != this.answer || this.question!= this.question || this.category != card.category){
            return false;
        }
        
        return true;
    }
    

}
