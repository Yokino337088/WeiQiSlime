using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMgr : SingletonAutoMono<GameObjectMgr>
{
    /// <summary>
    /// 玩家是否在UI面板上选中了棋子
    /// </summary>
    public bool isPlayerSelect;

    public bool isClickPiece;

    /// <summary>
    /// 是否是玩家的回合
    /// </summary>
    public bool isPlayerRound;

    /// <summary>
    /// 玩家选择的角色信息
    /// </summary>
    public T_Role playerRoleInfo;

    /// <summary>
    /// 玩家当前选中的角色物件
    /// </summary>
    public RoleItem nowRoleItem;

    /// <summary>
    /// 电脑AI选择的角色信息
    /// </summary>
    public T_Role AIRoleInfo;

    /// <summary>
    /// 玩家棋子的列表（实际数据由 ChessPieceMgr 统一维护）
    /// </summary>
    public List<ChessPiece> playerChess => ChessPieceMgr.Instance.PlayerPieces;

    /// <summary>
    /// 电脑AI棋子的列表（实际数据由 ChessPieceMgr 统一维护）
    /// </summary>
    public List<ChessPiece> AIChess => ChessPieceMgr.Instance.EnemyPieces;

    /// <summary>
    /// 玩家1棋子的列表（实际数据由 ChessPieceMgr 统一维护）
    /// </summary>
    public List<ChessPiece> player1List => ChessPieceMgr.Instance.Player1Pieces;

    /// <summary>
    /// 玩家2棋子的列表（实际数据由 ChessPieceMgr 统一维护）
    /// </summary>
    public List<ChessPiece> player2List => ChessPieceMgr.Instance.Player2Pieces;

    /// <summary>
    /// 储存所有角色的列表
    /// </summary>
    public List<T_Role> AllRoleList = new List<T_Role>();

    /// <summary>
    /// 所有棋子的列表（实际数据由 ChessPieceMgr 统一维护）
    /// </summary>
    public List<ChessPiece> allChessList => ChessPieceMgr.Instance.AllPieces;

    /// <summary>
    /// 储存7级兵种的列表
    /// </summary>
    public List<T_Role> topRoleList = new List<T_Role>();

    public T_Role maoDie;

    /// <summary>
    /// 将所有的角色信息加载进列表
    /// </summary>
    public void GetAllRoleInfo()
    {
        Dictionary<string, T_Role> roleContainer = BinaryDataMgr.Instance.GetTable<T_RoleContainer>().dataDic;

        foreach (var key in roleContainer.Keys)
        {
            if (roleContainer[key].f_profession != 10)
                AllRoleList.Add(roleContainer[key]);
            else
                maoDie = roleContainer[key];
        }

        foreach (var role in AllRoleList)
        {
            if(role.f_level==7)
                topRoleList.Add(role);
        }
    }

    /// <summary>
    /// 清除场景上棋子的方法（销毁、各阵营容器与棋盘索引统一由 ChessPieceMgr 处理）
    /// </summary>
    public void ClearPiece()
    {
        ChessPieceMgr.Instance.ClearAll();
    }

    public void ClearObject()
    {
        MusicMgr.Instance.ClearSound();
        PoolMgr.Instance.ClearPool();
    }
}
