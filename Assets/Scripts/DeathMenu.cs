using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class DeathMenu : MonoBehaviour
{
    private CanvasGroup deathMenu;

    public GameObject restartButton;

    void Start()
    {
        deathMenu = GetComponent<CanvasGroup>();
        GameManager.RegisterDeathMenu(this);
    }

    public void OpenDeathMenu()
    {
        EventSystem.current.SetSelectedGameObject(restartButton);

        deathMenu.alpha = 1;
        deathMenu.blocksRaycasts = true;
        deathMenu.interactable = true;
    }
}
