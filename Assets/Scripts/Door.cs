using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite unlockedSprite;
    public int lvlToload;
    private BoxCollider2D boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();

        GameManager.RegisterDoor(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            boxCol.enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();

            LevelManager.Instance.ManagerLoadLevel(lvlToload);
            LevelManager.Instance.pC.SaveGem();
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCol.enabled = true;
    }
}
