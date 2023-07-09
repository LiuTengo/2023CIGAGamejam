using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;

    public GameStateFSM fsm;

    [Header("菜单")]
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GuessPanel;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public GameObject CheatPanel;
    public GameObject PlayPanel;

    [Header("全局变量")]
    public bool _isPlaying;


    [Header("猜测状态")]
    [Header("计时器")]
    public float maxTime;//初始时间
    public Image sliderImg;//填充进度条的图片
    public Slider countDownSlider;//进度条
    [HideInInspector]public float originMaxTime;

    [Header("教学界面")]
    public GameObject TeachPanel;
    public GameObject TeachPanelButton;
    public GameObject CloseIntroButton;

    [Header("卡牌管理")]
    public PlaySceneManager playManager;

    public void Awake()
    {
        originMaxTime = maxTime;

        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);

        fsm = new GameStateFSM();

        //Example
        fsm.AddNewState("StartState",new StartState(this));
        fsm.AddNewState("PauseState", new PauseState(this));
        fsm.AddNewState("TeachState", new TeachState(this));
        fsm.AddNewState("GachaState",new GachaState(this));
        fsm.AddNewState("GuessState", new GuessState(this));
        fsm.AddNewState("CheatState", new CheatState(this));
        fsm.AddNewState("WinState", new WinState(this));
        fsm.AddNewState("LoseState", new LoseState(this));

        //Initialize
        fsm.currentState = fsm.states["StartState"];
        StartPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
        Debug.Log(fsm.currentState);
    }

    //提供给按钮——切换游戏状态的方法
    public void SwitchGameState(string stateType)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        fsm.SwitchState(stateType);
    }

    //提供给按钮——切换游戏场景的方法
    public void SwitchGameScene(string sceneName)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        SceneManager.LoadScene(sceneName);
    }

    //提供给按钮——退出游戏
    public void QuitApplication()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);
        Application.Quit();
    }

    public void LeftButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        TeachPanel.transform.Find("01").GetComponent<RectTransform>().DOMove(Vector3.zero, 2f);
        TeachPanel.transform.Find("02").GetComponent<RectTransform>().DOMove(new Vector3(17.778f, 0, 0), 2f);
    }
    public void RightButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        TeachPanel.transform.Find("01").GetComponent<RectTransform>().DOMove(new Vector3(-17.778f, 0, 0), 2f);
        TeachPanel.transform.Find("02").GetComponent<RectTransform>().DOMove(Vector3.zero, 2f);
    }

    public void PauseGame()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        Time.timeScale= 0f;
    }
    public void ContinueGame()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        Time.timeScale = 1f;
    }

}
