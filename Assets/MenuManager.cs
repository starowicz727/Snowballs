using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Text pointsTxt;

    private void Update()
    {
        if(GameState.endOfGame == true)
        {
            startButton.gameObject.SetActive(true);
        }
        
        pointsTxt.text = "POINTS: " + GameState.points.ToString();
        
    }
    public void StartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
