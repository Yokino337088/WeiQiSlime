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
    /// 储存玩家棋子的列表
    /// </summary>
    public List<ChessPiece> playerChess = new List<ChessPiece>();

    /// <summary>
    /// 储存电脑AI棋子的列表
    /// </summary>
    public List<ChessPiece> AIChess = new List<ChessPiece>();

    /// <summary>
    /// 储存玩家1棋子的列表
    /// </summary>
    public List<ChessPiece> player1List = new List<ChessPiece>();

    /// <summary>
    /// 储存玩家2棋子的列表
    /// </summary>
    public List<ChessPiece> player2List = new List<ChessPiece>();

    /// <summary>
    /// 储存所有角色的列表
    /// </summary>
    public List<T_Role> AllRoleList = new List<T_Role>();

    /// <summary>
    /// 储存所有棋子的列表
    /// </summary>
    public List<ChessPiece> allChessList = new List<ChessPiece>();

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
    /// 清除场景上棋子的方法
    /// </summary>
    public void ClearPiece()
    {
        foreach (var piece in playerChess)
        {
            Destroy(piece.gameObject);
        }
        playerChess.Clear();
        foreach (var piece in AIChess)
        {
            Destroy(piece.gameObject);
        }
        AIChess.Clear();
        foreach(var piece in player1List)
        {
            Destroy(piece.gameObject);
        }
        player1List.Clear();
        foreach (var piece in player2List)
        {
            Destroy(piece.gameObject);
        }
        player2List.Clear();
        foreach (var piece in allChessList)
        {
            Destroy(piece.gameObject);
        }
        allChessList.Clear();
    }



    public void ClearObject()
    {
        allChessList.Clear();
        AIChess.Clear();
        playerChess.Clear();
        MusicMgr.Instance.ClearSound();
        PoolMgr.Instance.ClearPool();
    }
}
