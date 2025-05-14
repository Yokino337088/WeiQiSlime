using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPieceState : BaseState
{    
    public SelectPieceState(StateMachine machine) : base(machine)
    {
    }

    public override void EnterState()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            return;

        //Debug.Log("AI 进入选择棋子状态");

        //如果行动力小于等于0，就返回
        if (GameDataMgr.Instance.enemyMobility <= 0)
            stateMachine.ChangeState(E_AI_State.EndTurn);

        //随机百分比
        int percent = Random.Range(5, 15);

        int targetGold = (int)GameDataMgr.Instance.AICoin * percent / 100; // 目标金币为剩余金币的 5%
        GameObjectMgr.Instance.AIRoleInfo = SelectPieceByGold(targetGold);

             
        if (GameObjectMgr.Instance.AIRoleInfo != null)
        {
            //判断金币是否小于0
            if (GameDataMgr.Instance.AICoin - GameObjectMgr.Instance.AIRoleInfo.f_exp < 0)
                stateMachine.ChangeState(E_AI_State.EndTurn);

            // 根据棋子类型切换到不同的落子状态
            if (GameObjectMgr.Instance.AIRoleInfo.f_profession == 1|| GameObjectMgr.Instance.AIRoleInfo.f_profession == 2|| GameObjectMgr.Instance.AIRoleInfo.f_profession == 3|| GameObjectMgr.Instance.AIRoleInfo.f_profession == 4)
            {
                stateMachine.ChangeState(E_AI_State.MeleePlace); 
            }
            else
            {
                stateMachine.ChangeState(E_AI_State.RangedPlace);    
            }
        }
        else
        {
            // 如果没有合适的棋子，切换到移动棋子状态
            stateMachine.ChangeState(E_AI_State.MovePiece);
        }
    }

    /// <summary>
    /// 根据金币选择最接近的职业
    /// </summary>
    /// <param name="targetGold"></param>
    /// <returns></returns>
    private T_Role SelectPieceByGold(int targetGold)
    {
        // 检查 AI 金币是否小于等于 0
        if (GameDataMgr.Instance.AICoin <= 0)
        {
            Debug.LogWarning("AI 金币不足，无法选择棋子");
            return null; // 返回空值
        }

        // 根据金币选择最接近的职业
        // 这里假设有一个棋子列表 pieces
        T_Role role = null;
        int minDifference = int.MaxValue;

        Dictionary<string, T_Role> roleContainer = BinaryDataMgr.Instance.GetTable<T_RoleContainer>().dataDic;

        foreach (var key in roleContainer.Keys)
        {
            int difference = Mathf.Abs(roleContainer[key].f_exp - targetGold);
            if (difference < minDifference)
            {
                minDifference = difference;
                role = roleContainer[key];
            }
        }

        return role;
    }

    public override void QuitState()
    {
        // 释放资源
        Resources.UnloadUnusedAssets();
    }

    public override void UpdateState()
    {
        
    }

}
