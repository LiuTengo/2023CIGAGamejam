using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameStateFSM fsm;

    [Header("菜单")]
    public GameObject StartPanel;
    public GameObject PausePanel;

    [Header("全局变量")]
    public bool _isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        fsm = new GameStateFSM();

        //Example
        fsm.AddNewState("StartState",new StartState(this));
        fsm.AddNewState("PlayState",new PlayState(this));
        fsm.AddNewState("PauseState",new PauseState(this));

        //Initialize
        fsm.currentState = fsm.states["StartState"];
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }

    //提供给按钮——切换游戏状态的方法
    public void SwitchGameState(string stateType)
    {
        fsm.SwitchState(stateType);
    }

    //提供给按钮——切换游戏场景的方法
    public void SwitchGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
