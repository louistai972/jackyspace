using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

public class HUDHandler : MonoBehaviour
{


    [Header("Game")]
    public Player Player;

    [Header("Interface")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI AmmoText;
    public Image HealtBar;
    // Use this for initialization
    void Awake()
    {
        Assert.IsNotNull(Player);
        Assert.IsNotNull(ScoreText);
        Assert.IsNotNull(AmmoText);
        Assert.IsNotNull(HealtBar);

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            AmmoText.text = "x " + Player.Ammo;
        }
    }
}

public class TextMeshProUGUI
{
    internal string text;
}