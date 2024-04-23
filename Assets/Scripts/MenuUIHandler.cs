using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField PlayerNameInput;
    [SerializeField] private string userName = "";

    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        PlayerNameInput = GameObject.Find("Name Field").GetComponent<TMP_InputField>();
        highScoreText.text = "High Score: " + DataPersistence.Instance.playerName + " : " + DataPersistence.Instance.highScore;
    }

    public void StartNew()
    {
        Debug.Log("Loaded");
        SceneManager.LoadScene(1);
    }
    public void InputPlayerName()
    {
        userName = PlayerNameInput.text;
        Debug.Log(userName);
        DataPersistence.Instance.playerName = userName;
    }
}