using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonMenu : MonoBehaviour {

    public string TestLD;

    public void ButtonPlay()
    {
        SceneManager.LoadScene(TestLD);
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
