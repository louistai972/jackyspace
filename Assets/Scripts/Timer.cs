using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public Text stateText;
    public Text endText;
    public GameObject endLayout;

    private float _startTime;
    private float _maxTime;



    void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - _startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("00");
        timerText.text = minutes + " : " + seconds;
    }

    void OnTriggerEnter(Collider other)
    {
        endLayout.SetActive(true);
        if (other.CompareTag("Player"))
        {
            stateText.text = "VICTOIRE";
            stateText.color = Color.green;
            endText.text = timerText.text;
            endText.color = Color.white;
        }
    }


    /*void EndLevel()
    {
        endLayout.SetActive(true);

        if ( _maxTime == )
        {

            if (palierScore.Length > 0 && scoreToxic >= palierScore[0] && scoreToxic < palierScore[1])
            {
                mushBonus = bonusMushByPalier[0];
                //levelChampiValue += bonusMushByPalier[0] ;
            }
            else if (palierScore.Length >= 1 && scoreToxic >= palierScore[1] && scoreToxic < palierScore[2])
            {
                //levelChampiValue += bonusMushByPalier[1] ;
                mushBonus = bonusMushByPalier[1];
                Debug.Log("Palier2");
            }

            if (GameManager.Instance() != null)
            {
                GameManager.Instance().ChampiBank(levelChampiValue + mushBonus);
                LvlSucces();
                pointAdded = true;
            }

        }

        levelIsEnd = true;
        EndText();
        GameManager.Instance().SaveGame();

    }

    void EndText()
    {
        endLayout.SetActive(true);
        if (scoreToxic < scoreNeed)
        {
            if (GameManager.Instance().ReturnLanguage())
            {
                stateText.color = Color.red;
                stateText.text = "DEFEAT";
                timeLeftText.text = "<b>No time left !</b>";
                scoreEndText.text = "Score : " + "<b>" + scoreToxic.ToString("") + "</b>" + " / " + "<b>" + scoreNeed.ToString("") + "</b>";
                mushGainText.text = "Mushroom gain : " + "<b>" + mushBonus + "</b>";
            }
        }
    }*/
}