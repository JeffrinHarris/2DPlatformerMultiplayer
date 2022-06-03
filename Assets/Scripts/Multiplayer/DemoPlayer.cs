using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DemoPlayer : NetworkBehaviour
{
    [SerializeField]
    private PlayerMovementScript player;
    [SyncVar]
    public bool isPaused;

    public override void OnStartAuthority()
    {
        gameObject.name = "LocalPlayer";
        player.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    MainMenuManager.instance.PauseGame();
                    isPaused = true;
                }
                else
                {
                    MainMenuManager.instance.ResumeGame();
                    isPaused = false;
                }
            }
        }
    }
}
