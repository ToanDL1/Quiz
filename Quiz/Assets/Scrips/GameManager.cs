using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScene endScene;

    // Start is called before the first frame update
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScene = FindObjectOfType<EndScene>();
    }

    void Start(){
        quiz.gameObject.SetActive(true);
        endScene.gameObject.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {
           if(quiz.finishGame){
            quiz.gameObject.SetActive(false);
            endScene.gameObject.SetActive(true);
            endScene.SetTextEndGame();
        }
    }

    public void Replay(){
        SceneManager.LoadScene(0);
    }
}
