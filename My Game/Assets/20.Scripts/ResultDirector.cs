using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ResultDirector : MonoBehaviour
{
    public GameObject resultText;
    public GameObject timeText;
    float clickDelay = 2f;
    bool canClick = false;
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        float survivedTime = PlayerPrefs.GetFloat("Time");
        resultText.GetComponent<TextMeshProUGUI>().text = "Result : " + score;
        timeText.GetComponent<TextMeshProUGUI>().text = "Time : " + survivedTime.ToString("F1");
    }
    void Update()
    {
        if (!canClick)
        {
            clickDelay -= Time.deltaTime;
            if (clickDelay <= 0) canClick = true;
        }
    }
    public void PlayAgain()
    {
        if (!canClick) return;
        SceneManager.LoadScene("Main");
    }
}