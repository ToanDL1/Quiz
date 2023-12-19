using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Question", menuName = "New Question", order = 1)]
public class QuestionOS : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter the question which you want";
    [SerializeField] string[] answer = new string[4];

    [SerializeField] int correctAnswerIndex;

    public string GetQuestion(){
        return this.question;
    }

    public int GetCorrectAnswerIndex(){
        return this.correctAnswerIndex;
    }

    public string GetAnswer(int index){
        return this.answer[index];
    }

    
}

