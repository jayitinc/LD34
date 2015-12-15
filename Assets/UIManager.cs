using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIs;

    public void SwitchUI(int ui)
    {
        for (int i = 0; i < UIs.Length; i++)
        {
            if (i == ui)
                UIs[i].SetActive(true);
            else
                UIs[i].SetActive(false);
        }
    }

    public void UnpauseGame()
    {
        Game.PAUSED = false;
    }

    public void ReloadGame()
    {
        Application.LoadLevel("Game");
    }
}