using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUiHandler : MonoBehaviour
{
    [SerializeField] private InputField playerNameField;

   public void StartGame()
    {
        GameStateHandler.instance.playerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }
}
