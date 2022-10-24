using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;

    public TMP_Text ScoreText;

    void Start()
    {
        Score = PlayerPrefs.GetInt("_score", 0);
        ScoreText.text = "Score:" + Score;
    }

    public void ScorePoint()
    {
        Score += 1000;
        PlayerPrefs.SetInt("_score", Score);
        ScoreText.text = "Score: " + Score;
    }

    public bool isGameStart = false;

    // public GameObject ChildCamera;
    public GameObject Sensei;

    public bool SenseiCanStart;

    public GameObject Player;

    public Text StartText;

    public static GameManager _gamemanager;

    public Camera MainCamera;

    public Camera SceondCamera;

    public void Awake()
    {
        if (_gamemanager == null)
        {
            _gamemanager = this;
        }
    }


#region //Main Menu Play-Quit Part
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
#endregion



#region Top To Start
    public void TopToStart()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (Input.GetMouseButton(0))
            {
                isGameStart = true;

                StartText.gameObject.SetActive(false);
                return;
            }
        }
    }
#endregion


    public void _sensei()
    {
        if (SenseiCanStart == true)
        {
            Sensei.SetActive(true);
            Sensei.transform.position =
                Vector3
                    .Lerp(Sensei.transform.position,
                    new Vector3(Player.transform.position.x,
                        1.5f,
                        Sensei.transform.position.z),
                    Time.deltaTime * 2 / 3);
            SceondCamera.gameObject.SetActive(true);
            MainCamera.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _sensei();
        TopToStart();
    }


#region NextLevel Part
    [SerializeField]
    private GameObject NextLevelUI;

    public void CallNextLevelUI()
    {
        NextLevelUI.gameObject.SetActive(true);
    }

    public void NextLevelTimer() //call here
    {
        Invoke("CallNextLevelUI", 2f);
    }

    public void NextScene()
    {
        if (
            SceneManager.GetActiveScene().buildIndex + 1 ==
            SceneManager.sceneCountInBuildSettings
        )
        {
            SceneManager.LoadScene(sceneName: "Level1");
        }
        else
        {
            SceneManager
                .LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
#endregion



#region  GameOver Part
    [SerializeField]
    private GameObject _gameOver;

    private void CallGameOverUI()
    {
        _gameOver.gameObject.SetActive(true);
    }

    public void GameOverTimer() //call here
    {
        Invoke("CallGameOverUI", 2f);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endregion



#region PauseMenu Part
    public void GoToMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
#endregion
}
