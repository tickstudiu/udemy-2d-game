using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private DeathMenu deathMenu;
    private Door theDoor;

    [HideInInspector] public List<Lever> levers;
    private static int totalLever;
    public static int totalUnlockLever = 0;
    private static Text leverComponent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        levers = new List<Lever>();
    }

    public static void RegisterDeathMenu(DeathMenu dM)
    {
        if (Instance == null) return;
        Instance.deathMenu = dM;
    }

    public static void RegisterLever(Lever lever)
    {
        if (Instance == null) return;
        if (!Instance.levers.Contains(lever))
        {
            Instance.levers.Add(lever);

            totalLever = Instance.levers.Count;
            leverComponent = GameObject.FindGameObjectWithTag("LeverUI").GetComponentInChildren<Text>();
            leverComponent.text = totalUnlockLever + "/" + totalLever.ToString();
        }
    }

    public static void RemoveLeverFromList(Lever lever)
    {
        if (Instance == null) return;
        Instance.levers.Remove(lever);

        totalUnlockLever++;
        leverComponent = GameObject.FindGameObjectWithTag("LeverUI").GetComponentInChildren<Text>();
        leverComponent.text = totalUnlockLever + "/" + totalLever.ToString();

        if (Instance.levers.Count == 0) Instance.theDoor.UnlockDoor();
    }

    public static void RegisterDoor(Door door)
    {
        if (Instance == null) return;
        Instance.theDoor = door;
    }

    public static void ManagerOpenDeathMenu()
    {
        if (Instance == null) return;

        Instance.levers.Clear();
        totalUnlockLever = 0;
        Instance.deathMenu.OpenDeathMenu();
    }
}
