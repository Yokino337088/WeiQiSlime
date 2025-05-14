using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAI : MonoBehaviour,IAIObj
{
    public StateMachine stateMachine;

    public static PCAI Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //初始化AI模块的有限状态机对象
        //把ai对象自己 传入其中进行初始化
        stateMachine = new StateMachine(this);

        stateMachine.AddState(E_AI_State.SelectPiece);
        stateMachine.AddState(E_AI_State.MeleePlace);
        stateMachine.AddState(E_AI_State.RangedPlace);
        stateMachine.AddState(E_AI_State.MovePiece);
        stateMachine.AddState(E_AI_State.EndTurn);

        StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(1f);
        stateMachine.ChangeState(E_AI_State.SelectPiece);
    }

    void Update()
    {
        
    }
}
