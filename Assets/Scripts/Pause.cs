using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
    [SerializeField]
    private Button resumeBtn;
    [SerializeField]
    private Button quitBtn;
    [SerializeField]
    private GameObject pauseMenu;

    void Awake()
    {
        pauseMenu.SetActive(false);
        resumeBtn.onClick.AddListener(OnResumeClick);
        quitBtn.onClick.AddListener(OnQuitClick);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    void OnResumeClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnQuitClick()
    {
        Application.Quit();
    }
}
