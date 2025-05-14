using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI状态类型 是由策划决定的 一开始就置顶好的规则
/// </summary>
public enum E_AI_State 
{
    /// <summary>
    /// 选择棋子的状态
    /// </summary>
    SelectPiece,
    /// <summary>
    /// 近战棋子落子的状态
    /// </summary>
    MeleePlace,
    /// <summary>
    /// 远程棋子落子的状态
    /// </summary>
    RangedPlace,
    /// <summary>
    /// 移动棋子的状态
    /// </summary>
    MovePiece,
    /// <summary>
    /// 结束回合
    /// </summary>
    EndTurn
}
