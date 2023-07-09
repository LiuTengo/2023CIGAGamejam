using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : IGameState
{
    public GameStateController controller;
    public LoseState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        controller.playManager.gameObject.SetActive(false);

        controller.LosePanel.SetActive(true);
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[6]);

    }
    public void UpdateState()
    {
        
    }
    public void ExitState()
    {
        controller.LosePanel.SetActive(false);
    }

}
