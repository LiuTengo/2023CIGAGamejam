using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameStateFSM fsm;

    [Header("�˵�")]
    public GameObject StartPanel;
    public GameObject PausePanel;

    [Header("ȫ�ֱ���")]
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
}
