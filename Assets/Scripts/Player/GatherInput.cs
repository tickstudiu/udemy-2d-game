using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class GatherInput : MonoBehaviour
{
    public AudioMixer mixer;

    public CanvasGroup gameUI;
    public CanvasGroup pauseMenu;

    public GameObject resumeButton;

    private Controls myControls;

    public float valueX;
    public bool jumpInput;

    public bool tryAttack;

    public float valueY;
    public bool tryToClimb;

    private bool pause = false;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.Player.MOVE.performed += StartMove;
        myControls.Player.MOVE.canceled += StopMove;

        myControls.Player.JUMP.performed += JumpStart;
        myControls.Player.JUMP.canceled += JumpStop;

        myControls.Player.ATTACK.performed += AttackStart;
        myControls.Player.ATTACK.canceled += AttackStop;

        myControls.Player.CLIMB.performed += ClimbStart;
        myControls.Player.CLIMB.canceled += ClimbStop;

        myControls.UI.PAUSE.performed += PauseStart;

        myControls.Player.Enable();
        myControls.UI.PAUSE.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.MOVE.performed -= StartMove;
        myControls.Player.MOVE.canceled -= StopMove;

        myControls.Player.JUMP.performed -= JumpStart;
        myControls.Player.JUMP.canceled -= JumpStop;

        myControls.Player.ATTACK.performed -= AttackStart;
        myControls.Player.ATTACK.canceled -= AttackStop;

        myControls.Player.CLIMB.performed -= ClimbStart;
        myControls.Player.CLIMB.canceled -= ClimbStop;

        myControls.UI.PAUSE.performed -= PauseStart;

        myControls.Player.Disable();
        myControls.UI.PAUSE.Disable();
        //myControls.Disable();
    }

    public void DisableControls()
    {
        myControls.Player.MOVE.performed -= StartMove;
        myControls.Player.MOVE.canceled -= StopMove;

        myControls.Player.JUMP.performed -= JumpStart;
        myControls.Player.JUMP.canceled -= JumpStop;

        myControls.Player.ATTACK.performed -= AttackStart;
        myControls.Player.ATTACK.canceled -= AttackStop;

        myControls.Player.CLIMB.performed -= ClimbStart;
        myControls.Player.CLIMB.canceled -= ClimbStop;

        myControls.Player.Disable();
        myControls.UI.PAUSE.Disable();
        valueX = 0;
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = Mathf.RoundToInt(ctx.ReadValue<float>());
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }

    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }

    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }

    private void AttackStart(InputAction.CallbackContext ctx)
    {
        tryAttack = true;
    }

    private void AttackStop(InputAction.CallbackContext ctx)
    {
        tryAttack = false;
    }

    private void ClimbStart(InputAction.CallbackContext ctx)
    {
        valueY = Mathf.RoundToInt(ctx.ReadValue<float>());

        if(Mathf.Abs(valueY) > 0)
        {
            tryToClimb = true;
        }
    }

    private void ClimbStop(InputAction.CallbackContext ctx)
    {
        valueY = 0;
        tryToClimb = false;
    }

    private void PauseStart(InputAction.CallbackContext ctx)
    {
        pause = !pause;
        if (pause)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        pause = true;

        EventSystem.current.SetSelectedGameObject(resumeButton);

        mixer.SetFloat("MusicVolume", -80f);
        mixer.SetFloat("SFXVolume", -80f);
        myControls.Player.Disable();
        Time.timeScale = 0;

        gameUI.alpha = 0;
        gameUI.blocksRaycasts = false;
        gameUI.interactable = false;

        pauseMenu.alpha = 1;
        pauseMenu.blocksRaycasts = true;
        pauseMenu.interactable = true;
    }

    public void UnPauseGame()
    {
        pause = false;

        mixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 30f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 30f);
        myControls.Player.Enable();
        Time.timeScale = 1;

        gameUI.alpha = 1;
        gameUI.blocksRaycasts = true;
        gameUI.interactable = true;

        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
        pauseMenu.interactable = false;
    }
}
