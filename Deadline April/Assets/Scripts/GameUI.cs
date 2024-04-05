using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;
    public  int currentScore;
    public static int oldScore=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   currentScore= GameManager.instance.GetScore();
        Score.SetText(GameManager.instance.GetScore().ToString());
        if(currentScore > oldScore){
            oldScore = currentScore;
            HighScore.SetText(oldScore.ToString());

        }else{
            HighScore.SetText(oldScore.ToString());

        }
        
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}
