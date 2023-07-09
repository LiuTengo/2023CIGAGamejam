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

    [Header("�˵�")]
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GuessPanel;
    public GameObject LosePanel;
    public GameObject WinPanel;
    public GameObject CheatPanel;
    public GameObject PlayPanel;

    [Header("ȫ�ֱ���")]
    public bool _isPlaying;


    [Header("�²�״̬")]
    [Header("��ʱ��")]
    public float maxTime;//��ʼʱ��
    public Image sliderImg;//����������ͼƬ
    public Slider countDownSlider;//������
    [HideInInspector]public float originMaxTime;

    [Header("��ѧ����")]
    public GameObject TeachPanel;
    public GameObject TeachPanelButton;
    public GameObject CloseIntroButton;

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

    //�ṩ����ť�����л���Ϸ״̬�ķ���
    public void SwitchGameState(string stateType)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        fsm.SwitchState(stateType);
    }

    //�ṩ����ť�����л���Ϸ�����ķ���
    public void SwitchGameScene(string sceneName)
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.clips[9]);

        SceneManager.LoadScene(sceneName);
    }

    //�ṩ����ť�����˳���Ϸ
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
