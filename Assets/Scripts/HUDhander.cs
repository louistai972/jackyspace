using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Animator))]

public class HUDHandler : MonoBehaviour
{


    [Header("Game")]
    public Player Player;

    [Header("Interface")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI AmmoText;
    public Image HealthBar;

    [HeaderAttribute("Settings")]
    public float ScoreFrameIncrementSpeed = 200f;
    private Animator _animator;
    public int _currentScore;

    void Awake()
    {
        Assert.IsNotNull(Player);
        Assert.IsNotNull(ScoreText);
        Assert.IsNotNull(AmmoText);
        Assert.IsNotNull(HealthBar);

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            AmmoText.text = "x " + Player.Ammo;
            HealthBar.fillAmount = Mathf.Max(0,Player.CurrentHealth / Player.MaxHealth);
            if (HealthBar.fillAmount >= 0.8f)
            {
                HealthBar.color = new Color(0, 255, 0);
            }
            else if (HealthBar.fillAmount >= 0.4)
            {
                HealthBar.color = new Color(255f, 185f, 7f);
            }
            else
            {
                HealthBar.color = new Color(255, 0, 0);
            }

            if(Player.Score > _currentScore)
            {
                _currentScore += Mathf.RoundToInt(Time.deltaTime + ScoreFrameIncrementSpeed);
                if (_currentScore > Player.Score)
                    _currentScore = Player.Score;
            }
            else if (Player.Score < _currentScore)
            {
                _currentScore -= Mathf.RoundToInt(Time.deltaTime + ScoreFrameIncrementSpeed);
                if (_currentScore < Player.Score)
                    _currentScore = Player.Score;
            }


            ScoreText.text = _currentScore.ToString();
        }
    }

    public void TakeDamage()
    {
        _animator.SetTrigger("TakeDamage");
    }
}

public class TextMeshProUGUI
{
    internal string text;
}
