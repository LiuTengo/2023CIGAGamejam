/// <summary>
/// 游戏状态接口，新建游戏状态需继承该类
/// </summary>
public interface IGameState
{
    public void EnterState();//开始进入当前状态时调用
    public void UpdateState();//每帧更新状态时调用
    public void ExitState();//结束当前状态时调用
}
