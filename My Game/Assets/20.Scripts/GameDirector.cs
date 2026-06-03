using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameDirector : MonoBehaviour
{
    public GameObject timeText;
    public GameObject pointText;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject roundText;
    float time = 0.0f;
    int point = 0;
    int life = 3;
    bool isRound2 = false;
    void Update()
    {
        time += Time.deltaTime;
        if (!isRound2 && time >= 60.0f)
        {
            isRound2 = true;
            StartCoroutine(ShowRound2());
        }
        timeText.GetComponent<TextMeshProUGUI>().text =
            "Time : " + time.ToString("F1");
        pointText.GetComponent<TextMeshProUGUI>().text =
            "Point : " + point;
    }
    public void GetApple()
    {
        point += 100;
        if (point > 999999999) point = 999999999;
    }
    public void GetBomb()
    {
        life--;
        if (life == 2) heart3.SetActive(false);
        else if (life == 1) heart2.SetActive(false);
        else if (life <= 0)
        {
            heart1.SetActive(false);
            PlayerPrefs.SetInt("Score", point);
            PlayerPrefs.SetFloat("Time", time);
            SceneManager.LoadScene("Result");
        }
    }
    public void GetSuperBomb()
    {
        life -= 2;
        if (life <= 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            PlayerPrefs.SetInt("Score", point);
            PlayerPrefs.SetFloat("Time", time);
            SceneManager.LoadScene("Result");
        }
        else if (life == 1)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
        }
    }
    
    public void GetHeart()
    {
        if (life < 3)
        {
            life++;
            if (life == 2) heart2.SetActive(true);
            else if (life == 3) heart3.SetActive(true);
        }
    }

    IEnumerator ShowRound2()
    {
        roundText.SetActive(true);
        yield return new WaitForSeconds(2f);
        roundText.SetActive(false);
        ItemGenerator ig = FindFirstObjectByType<ItemGenerator>();
        ig.span = 0.7f;
        ig.isRound2 = true;
    }
}