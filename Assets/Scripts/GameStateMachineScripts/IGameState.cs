/// <summary>
/// ��Ϸ״̬�ӿڣ��½���Ϸ״̬��̳и���
/// </summary>
public interface IGameState
{
    public void EnterState();//��ʼ���뵱ǰ״̬ʱ����
    public void UpdateState();//ÿ֡����״̬ʱ����
    public void ExitState();//������ǰ״̬ʱ����
}
