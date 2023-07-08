using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public GameStateFSM fsm;

    [Header("菜单")]
    public GameObject StartPanel;
    public GameObject PausePanel;
    

    [Header("全局变量")]
    public bool _isPlaying;


    [Header("猜测状态中")]
    [Header("计时器")]
    public float maxTime;//初始时间
    public Image sliderImg;//填充进度条的图片
    public Slider countDownSlider;//进度条
    [Header("卡牌管理")]
    public PlaySceneManager playManager;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        fsm = new GameStateFSM();

        //Example
        fsm.AddNewState("StartState",new StartState(this));
        fsm.AddNewState("PauseState",new PauseState(this));
        fsm.AddNewState("InitialState",new InitialState(this));
        fsm.AddNewState("GuessState", new GuessState(this));
        fsm.AddNewState("CompeteState", new CompeteState(this));
        fsm.AddNewState("WinState", new WinState(this));
        fsm.AddNewState("LoseState", new LoseState(this));

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

    //提供给按钮——退出游戏
    public void QuitApplication()
    {
        Application.Quit();
    }
}
