using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件类型 枚举
/// </summary>
public enum E_EventType 
{
    /// <summary>
    /// 怪物死亡事件 —— 参数：Monster
    /// </summary>
    E_Monster_Dead,
    /// <summary>
    /// 玩家获取奖励 —— 参数：int
    /// </summary>
    E_Player_GetReward,
    /// <summary>
    /// 测试用事件 —— 参数：无
    /// </summary>
    E_Test,
    /// <summary>
    /// 场景切换时进度变化获取
    /// </summary>
    E_SceneLoadChange,

    /// <summary>
    /// 输入系统触发技能1 行为
    /// </summary>
    E_Input_Skill1,
    /// <summary>
    /// 输入系统触发技能2 行为
    /// </summary>
    E_Input_Skill2,
    /// <summary>
    /// 输入系统触发技能3 行为
    /// </summary>
    E_Input_Skill3,

    /// <summary>
    /// 水平热键 -1~1的事件监听
    /// </summary>
    E_Input_Horizontal,

    /// <summary>
    /// 竖直热键 -1~1的事件监听
    /// </summary>
    E_Input_Vertical,

    /// <summary>
    /// 触摸开始
    /// </summary>
    E_TouchStart,
    /// <summary>
    /// 触摸移动
    /// </summary>
    E_TouchMove,
    /// <summary>
    /// 触摸结束
    /// </summary>
    E_TouchEnd,
    /// <summary>
    /// 多点触摸
    /// </summary>
    E_MultiTouch,

    /// <summary>
    /// 滑动输入
    /// </summary>
    E_Swipe,

    /// <summary>
    /// 棋子销毁
    /// </summary>
    E_ChessPieceRemove,

    /// <summary>
    /// 棋子被围事件
    /// </summary>
    E_IsSurrounded,
}
