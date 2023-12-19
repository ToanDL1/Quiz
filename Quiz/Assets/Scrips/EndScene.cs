using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textEndGame;

    [SerializeField] Button replayButton;

    ScoreKeeper scoreKeeper;

    void Awake(){
        this.scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void SetTextEndGame(){
       
       textEndGame.text =   "Congratulation\n"+
                            "Your Score: " + scoreKeeper.GetScore();
    }
}
