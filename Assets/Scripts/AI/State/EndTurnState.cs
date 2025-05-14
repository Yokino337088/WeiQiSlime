using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTurnState : BaseState
{
    public EndTurnState(StateMachine machine) : base(machine)
    {
    }

    public override void EnterState()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;

        //Debug.Log("AI 进入结束回合状态");
        
        // 结束回合逻辑
        EndTurn();
    }

    private void EndTurn()
    {
        
        //Debug.Log("AI 结束回合");
        MonoMgr.Instance.StartCoroutine(WaitToSelect());
    }

    private IEnumerator WaitToSelect()
    {
        yield return new WaitForSeconds(1.5f);

        // 检查是否满足切换条件
        if (GameDataMgr.Instance.enemyMobility > 0)
        {
            stateMachine.ChangeState(E_AI_State.SelectPiece);
        }
        else
        {
            Debug.Log("AI 行动力已耗尽，无法继续选择棋子");
        }
    }

    public override void QuitState()
    {
        // 停止所有协程
        MonoMgr.Instance.StopAllCoroutines();
    }

    public override void UpdateState()
    {
        
    }
}
