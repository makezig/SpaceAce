using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private GameManager gameManagerScript;

    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";

    }

    public void Restart ()
    {
        SceneManager.LoadScene("AnimalFarm");
    }

    public void ExitButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
