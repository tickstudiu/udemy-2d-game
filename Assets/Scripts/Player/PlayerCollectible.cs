using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerCollectible : MonoBehaviour
{
    private Text textComponent;
    public int gemNumber;


    // Start is called before the first frame update
    void Start()
    {
        LevelManager.RegisterPlayerCollectible(this);

        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();
        gemNumber = PlayerPrefs.GetInt("Gems");

        UpdateText();
    }

    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    public void GemCollected()
    {
        gemNumber += 1;
        UpdateText();
    }

    public void SaveGem()
    {
        PlayerPrefs.SetInt("Gems", gemNumber);
    }
}


