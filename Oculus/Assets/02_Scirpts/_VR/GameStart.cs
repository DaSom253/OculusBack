using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public Button startButton;

    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
