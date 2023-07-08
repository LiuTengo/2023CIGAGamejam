using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public GameStateFSM fsm;

    [Header("�˵�")]
    public GameObject StartPanel;
    public GameObject PausePanel;
    

    [Header("ȫ�ֱ���")]
    public bool _isPlaying;


    [Header("�²�״̬��")]
    [Header("��ʱ��")]
    public float maxTime;//��ʼʱ��
    public Image sliderImg;//����������ͼƬ
    public Slider countDownSlider;//������
    [Header("���ƹ���")]
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
