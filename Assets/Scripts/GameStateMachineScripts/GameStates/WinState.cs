using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : IGameState
{
    public GameStateController controller;
    public WinState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        controller.playManager.gameObject.SetActive(false);
        
        controller.WinPanel.SetActive(true);

        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[7]);

    }
    public void UpdateState()
    {
       
    }

    public void ExitState()
    {
        
    }


}
