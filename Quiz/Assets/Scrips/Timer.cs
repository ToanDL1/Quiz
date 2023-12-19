using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject timerImgObj;

    [SerializeField] float timeToAnswerQuestion = 30f;
    [SerializeField] float timeToShowTheAnswer = 10f;

    public bool isAnsweringQuestion = false;

    public bool getNextQuestion = true;

    float timerValue;

    private Image timerImg;

    // Start is called before the first frame update
    void Start()
    {
        timerImg = timerImgObj.GetComponent<Image>();
    }

    // Update is called once per frame
   
  

    void ChangeImg(float time){
        timerImg.fillAmount -= 1/time * Time.deltaTime;
    }

    void ResetImg(){
        if(timerImg.fillAmount == 0){
            timerImg.fillAmount = 1;
        }
    }

     public void UpdateTime(){
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion){
            ChangeImg(timeToAnswerQuestion);
           
           if(timerValue <= 0){
                isAnsweringQuestion = false;
                timerValue = timeToShowTheAnswer;
                ResetImg();
           }        
        }else{
            ChangeImg(timeToShowTheAnswer);
            if(timerValue <= 0){
                getNextQuestion = true;
                isAnsweringQuestion = true;
                timerValue = timeToAnswerQuestion;
                ResetImg();
                
            }
        }
    }

    public void CancelTimer(){
        this.timerValue = 0;
    }

    
}
