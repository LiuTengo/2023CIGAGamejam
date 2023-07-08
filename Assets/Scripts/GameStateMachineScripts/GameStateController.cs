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

    [Header("�˵�")]
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GuessPanel;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public GameObject CheatPanel;

    [Header("ȫ�ֱ���")]
    public bool _isPlaying;


    [Header("�²�״̬")]
    [Header("��ʱ��")]
    public float maxTime;//��ʼʱ��
    public Image sliderImg;//����������ͼƬ
    public Slider countDownSlider;//������
    [HideInInspector]public float originMaxTime;

    [Header("���ƹ���")]
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
        fsm.AddNewState("GachaState",new GachaState(this));
        fsm.AddNewState("GuessState", new GuessState(this));
        fsm.AddNewState("CheatState", new CheatState(this));
        fsm.AddNewState("WinState", new WinState(this));
        fsm.AddNewState("LoseState", new LoseState(this));

        //Initialize
        fsm.currentState = fsm.states["GachaState"];
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }

    //�ṩ����ť�����л���Ϸ״̬�ķ���
    public void SwitchGameState(string stateType)
    {
        fsm.SwitchState(stateType);
    }

    //�ṩ����ť�����л���Ϸ�����ķ���
    public void SwitchGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //�ṩ����ť�����˳���Ϸ
    public void QuitApplication()
    {
        Application.Quit();
    }
}
