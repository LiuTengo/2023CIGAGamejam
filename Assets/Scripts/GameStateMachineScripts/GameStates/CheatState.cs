using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatState : IGameState
{
    public GameStateController controller;
    public CheatState(GameStateController controller)
    {
        this.controller = controller;
    }

    public void EnterState()
    {
        controller.playManager.gameObject.SetActive(false);
        controller.CheatPanel.SetActive(true);
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[5]);
    }
    public void UpdateState()
    {
        
    }
    public void ExitState()
    {
        controller.CheatPanel.SetActive(false);
    }
}
