using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionTile;
    // Start is called before the first frame update
    [SerializeField] List<QuestionOS> questions = new List<QuestionOS>();

    private QuestionOS currentQuestion;


    [Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    
    [Header("AnswerImage")]
    [SerializeField] Sprite defaultImg;
    [SerializeField] Sprite correctImg;

    [Header("Timer")]
    Timer timerController;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("ScoreKeeper")]

    ScoreKeeper scoreKeeper;
    

    
    [Header("LogicQuiz")]
     bool isAnswerEarly ;
    public bool finishGame;

    [Header("slider")]
    [SerializeField] Slider sliderQuiz;

    void Awake(){
        isAnswerEarly = false;
        finishGame = false;
        timerController = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }



    void Start()
    {
        
        scoreKeeper.Notification();
        this.scoreText.text = "Score: " + scoreKeeper.GetScore() ;
    }

    void Update(){
        timerController.UpdateTime();
        if(timerController.getNextQuestion){
            if(sliderQuiz.value == sliderQuiz.maxValue){
                this.finishGame = true;
                return;
            }
            getNextQuestion();
            timerController.getNextQuestion = false;
        }else if(!isAnswerEarly && !timerController.isAnsweringQuestion){
            DisplayTheAnswer();
        }
        
    }

    public bool GetIsAnswerEarly(){
        return this.isAnswerEarly;
    }

    // Update is called once per frame
    void SetAnswerButton(int index, string answerContent)
    {
        answerButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = answerContent;
    }

    public void OnClickAnswerEvent(int index)
    {
        int indexCorrectAnswer = this.currentQuestion.GetCorrectAnswerIndex();
        if (index == indexCorrectAnswer)
        {
            questionTile.text = "Correct!";
            scoreKeeper.IncreaseScore();
            this.scoreText.text = "Score: " + scoreKeeper.GetScore();
        }
        else
        {
            questionTile.text = "Wrong! This correct answer is: " + this.currentQuestion.GetAnswer(indexCorrectAnswer);
        }
        answerButtons[indexCorrectAnswer].GetComponent<Image>().sprite = correctImg;
        isAnswerEarly = true;
        timerController.CancelTimer();
        // Debug.Log("slider: " + this.sliderQuiz.value);
    
        SetButtonState(false);
    }

    void DisplayTheAnswer(){
        int indexCorrectAnswer = this.currentQuestion.GetCorrectAnswerIndex();
        questionTile.text = "Time up! this correct answer is" + this.currentQuestion.GetAnswer(indexCorrectAnswer);
        answerButtons[indexCorrectAnswer].GetComponent<Image>().sprite = correctImg;
        SetButtonState(false);
    }

    void DisplayQuestion(){
       
         this.questionTile.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            string answerContent = currentQuestion.GetAnswer(i);
            SetAnswerButton(i, answerContent);
        }
        SetButtonState(true);

    }

    void SetButtonState(bool state){
        for(int i=0; i< answerButtons.Length; i++){
            Button currentButton = answerButtons[i].GetComponent<Button>();
            currentButton.interactable = state;
        }
    }

    void SetButtonDefaultImg(){
        for(int i =0; i<answerButtons.Length;i++){
            Image currentImg = answerButtons[i].GetComponent<Image>();
            currentImg.sprite = defaultImg;
        }
    }

    void getNextQuestion() {
        this.isAnswerEarly = false;
        SetButtonState(true);
        SetButtonDefaultImg();
        System.Random random = new System.Random();
        int questionIndex = random.Next(0, questions.Count);
        this.currentQuestion = questions[questionIndex];
        sliderQuiz.value++;
        DisplayQuestion();
        Debug.Log("hichic: " , this.currentQuestion);
        questions.Remove(currentQuestion);
        
    }

}
