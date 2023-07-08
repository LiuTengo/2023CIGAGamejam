using UnityEngine;


[CreateAssetMenu(fileName = "CardInfo", menuName = "ScriptableObject/������Ϣ", order = 0)]
public class CardScriptableObject : ScriptableObject
{
    [Header("���ƻ�ɫ��\n1--��Ƭ\n2--����\n3--����\n4--÷��")]
    public int CardSuit;

    [Header(" ���ƴ�С��")]
    public int CardValue;

    [Header("����:")]
    public Sprite CardBack;

    [Header("����:")]
    public Sprite CardFront;

    //��ײ��λ��--���ݻ�ɫ��š����ƴ�С�Լ�֮��ȷ���õļ������ȷ��
}
