using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 有限状态机类 它主要用于管理各个状态之间的切换
/// </summary>
public class StateMachine 
{
    //他要管理AI的所有状态
    //所以我们通过一个容器去存储这些状态
    //这些状态会随时的取出来进行切换 因此我们要选用一个方便查找获取的容器存储
    //key —— 状态类型(是有限的状态类型，那么就可以是一开始定死的，
    //                 即使以后策划天马行空 有了新状态需求 ，我们改代码即可，因为我们有了热更新技术 所以也没有太大的影响)
    //value —— 代表的是处理状态的逻辑对象
    private Dictionary<E_AI_State, BaseState> stateDic = new Dictionary<E_AI_State, BaseState>();

    //表示当前有限状态 处于的状态（也就是对应的怪物或玩家当前处于的AI状态)
    private BaseState nowState;

    //我们的有限状态机制作的AI 里面有很多的AI状态
    //那么这些AI状态逻辑当中，最终要去针对什么处理对应的状态逻辑
    //处理的其实是 游戏当中需要AI的对象 比如 怪物、玩家、宠物、NPC等等

    //虽然这些对象都是不一样的对象 但是 他们理论上来说需要具备共同的行为
    //这样在处理AI逻辑时 才更方便进行一些行为的调用

    //我们其实可以尝试 在AI模块把这些内容提取出来 作为接口 让这些需要AI的对象 必须要实现这个接口 才行

    //这个就是ai有限状态机 管理的 ai对象 会去通过ai状态命令该对象 执行对应的行为
    public IAIObj aiObj;

    

    /// <summary>
    /// 初始化有限状态机类 
    /// </summary>
    /// <param name="aiObj">传入 ai对象 用于之后的行为控制</param>
    public StateMachine(IAIObj aiObj)
    {
        this.aiObj = aiObj;
    }


    /// <summary>
    /// 改变状态
    /// </summary>
    public void ChangeState(E_AI_State state)
    {
        //如果当前处于另一个状态 就退出该状态
        if (nowState != null)
            nowState.QuitState();

        //如果存在该状态的逻辑出来对象 那么就进入该状态
        if (stateDic.ContainsKey(state))
        {
            nowState = stateDic[state];
            nowState.EnterState();
        }
    }

    /// <summary>
    /// 更新当前状态逻辑处理
    /// </summary>a
    public void UpdateState()
    {
        if (nowState != null)
            nowState.UpdateState();
    }

    /// <summary>
    /// 添加AI状态的函数
    /// </summary>
    /// <param name="state">ai状态</param>
    public void AddState(E_AI_State state)
    {
        switch (state)
        {
            case E_AI_State.SelectPiece:
                stateDic.Add(E_AI_State.SelectPiece, new SelectPieceState(this));
                break;
            case E_AI_State.MeleePlace:
                stateDic.Add(E_AI_State.MeleePlace, new MeleePlaceState(this));
                break;
            case E_AI_State.RangedPlace:
                stateDic.Add(E_AI_State.RangedPlace, new RangedPlaceState(this));
                break;
            case E_AI_State.MovePiece:
                stateDic.Add(E_AI_State.MovePiece, new MovePieceState(this));
                break;
            case E_AI_State.EndTurn:
                stateDic.Add(E_AI_State.EndTurn, new EndTurnState(this));
                break;
        }
    }

    
}
