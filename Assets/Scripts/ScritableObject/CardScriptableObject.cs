using UnityEngine;


[CreateAssetMenu(fileName = "CardInfo", menuName = "ScriptableObject/卡牌信息", order = 0)]
public class CardScriptableObject : ScriptableObject
{
    [Header("卡牌花色：\n1--方片\n2--红桃\n3--黑桃\n4--梅花")]
    public int CardSuit;

    [Header(" 卡牌大小：")]
    public int CardValue;

    [Header("卡背:")]
    public Sprite CardBack;

    [Header("卡面:")]
    public Sprite CardFront;

    //碰撞体位置--根据花色序号、卡牌大小以及之后确定好的间隔即可确定
}
