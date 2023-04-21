﻿using System.ComponentModel.DataAnnotations; 

namespace Models; 

public class Flashcard{
    
    public Flashcard(){}

    public Flashcard(string q, string a){
        this.question = q; 
        this.answer = a; 
    }

    public int ID {get; }

    [Required]
    [MaxLength(255)]
    public string question{get; set;} = "?";

    [Required]
    public string answer{get; set;} =  "?";

    public bool correct{get; set;} = false; 

    public string category{get; set;} = "";

    public override string ToString()
    {
        return $"{question}: {answer}";
    }


}