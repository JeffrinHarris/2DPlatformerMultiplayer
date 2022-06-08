using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    [SerializeField]
    private GameObject mainMenuPage;
    [SerializeField]
    private GameObject pauseMenuPage;
    [SerializeField]
    private GameObject steamPlayerInfo;
    [SerializeField]
    private GameObject faceChooser;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuPage.SetActive(true);
        pauseMenuPage.SetActive(false);
        steamPlayerInfo.SetActive(true);
        faceChooser.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void HostGame()
    {
        if (SteamLobbyManager.instance.isOnline)
        {
            Debug.Log("HOSTING LOBBY");
            mainMenuPage.SetActive(false);
            SteamLobbyManager.instance.HostLobby();
            pauseMenuPage.SetActive(false);
            steamPlayerInfo.SetActive(false);
            faceChooser.SetActive(false);
        }
    }

    public void JoinGame()
    {
        SteamLobbyManager.instance.OpenSteamOverlay();
    }

    public void PauseGame()
    {
        pauseMenuPage.SetActive(true);
        steamPlayerInfo.SetActive(true);
        faceChooser.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenuPage.SetActive(false);
        steamPlayerInfo.SetActive(false);
        faceChooser.SetActive(false);
    }

    public void HideUI()
    {
        mainMenuPage.SetActive(false);
        pauseMenuPage.SetActive(false);
        steamPlayerInfo.SetActive(false);
        faceChooser.SetActive(false);
    }    

    public void Invite()
    {
        SteamLobbyManager.instance.Invite();
    }
}
