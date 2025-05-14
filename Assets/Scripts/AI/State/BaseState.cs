using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态基类 所有状态类都会继承它
/// </summary>
public abstract class BaseState 
{
    //有限状态机实现的AI中的 这些 状态类 它的本质 对于我们来说 是在做什么？
    //逻辑处理（不仅仅是做AI，不管你用代码做什么样的事情 都是在进行逻辑处理）

    //AI状态的切换 
    //切换这个词 就意味着
    // 状态1 ——> 状态2

    //在这个基类中 可以去实现所有状态共有的 进入、离开、处于状态的行为（函数、方法）
    //但是这些方法中 由于是基类，没有明确是哪种状态，也就意味着方法中不会写内容
    //那么 不能写内容的函数 你能联想到什么？
    //1.如果是接口 ，那么直接声明
    //2.如果是类，那么可以考虑抽象方法——一定是抽象类

    //管理自己的有限状态机对象
    protected StateMachine stateMachine;

    //当前状态的类型
    public virtual E_AI_State AIState
    {
        get;
    }

    /// <summary>
    /// 初始化状态类时  将管理者传入 进行记录
    /// </summary>
    /// <param name="machine"></param>
    public BaseState(StateMachine machine)
    {
        stateMachine = machine;
    }

    // 1.离开状态时 做什么
    public abstract void QuitState();

    // 2.进入状态时 做什么
    public abstract void EnterState();

    // 3.处于状态时 做什么（核心逻辑处理）
    public abstract void UpdateState();
}
