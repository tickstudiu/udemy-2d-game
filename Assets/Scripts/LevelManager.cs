using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public CanvasGroup loadingCanvas;
    public Slider prograssBar;

    [HideInInspector] public PlayerCollectible pC;
    private int lvlToload;

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
    }

    public void Restart()
    {
        ManagerLoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public static void RegisterPlayerCollectible(PlayerCollectible pc)
    {
        if (Instance == null) return;
        Instance.pC = pc;
    }

    public void ManagerLoadLevel(int index)
    {
        GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>().SetTrigger("FadeOut");

        GameManager.totalUnlockLever = 0;  
        GameManager.Instance.levers.Clear();

        lvlToload = index;

        Invoke("LoadLevel", 1.5f);
    }

    private async void LoadLevel()
    {
        var scene = SceneManager.LoadSceneAsync(lvlToload);
        scene.allowSceneActivation = false;
        loadingCanvas.alpha = 1;

        do
        {
            await Task.Delay(100);
            prograssBar.value = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(500);

        scene.allowSceneActivation = true;
        loadingCanvas.alpha = 0;

        await Task.Delay(500);

        GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
