using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update


    private int score =0;
      
   
   
    public int GetScore(){
        return this.score;
    }

    public void IncreaseScore(){
        this.score++;
    }

    public void resetScore(){
        this.score = 0;
    }

    public void Notification(){
        Debug.Log("đã truy cập được vào scoreKeeper");
        Debug.Log(this.score);
    }

}
