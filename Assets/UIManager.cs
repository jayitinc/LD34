using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject[] uis;

    public void SwitchUI(int ui)
    {
        for (int i = 0; i < uis.Length; i++)
        {
            if (i == ui)
                uis[i].SetActive(true);
            else
                uis[i].SetActive(false);
        }
    }

    public void UnpauseGame()
    {
        Game.PAUSED = false;
    }

    public void ReloadGame()
    {
        Application.LoadLevel("SplashLogo");
    }
}