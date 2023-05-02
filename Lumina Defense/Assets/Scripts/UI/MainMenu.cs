using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonQuit.onClick.AddListener(OnButtonQuitClick);
        buttonPlay.onClick.AddListener(OnButtonPlayClick);
    }
    private void OnButtonPlayClick()
    {
      SceneManager.LoadScene("MainGame");
  
    }

    private void OnButtonQuitClick()
    {
        Application.Quit();
    }
  
}
