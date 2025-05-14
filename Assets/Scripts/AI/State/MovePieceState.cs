using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TestTools;

public class MovePieceState : BaseState
{
    
    public MovePieceState(StateMachine machine) : base(machine)
    {

    }

    public override void EnterState()
    {
        //Debug.Log("AI 进入移动棋子状态");

        ChessPiece chessPiece = GetRandomEnemyPieceWithoutPlayerInDiamond();
        if (chessPiece != null)
        {
            //检测行动力是否足够
            if (GameDataMgr.Instance.enemyMobility > 0)
                MovePiece(chessPiece);
            else if (GameDataMgr.Instance.enemyMobility <= 0)
                stateMachine.ChangeState(E_AI_State.EndTurn);
        }

        // 移动后切换到结束回合状态
        stateMachine.ChangeState(E_AI_State.EndTurn);
    }

    
    /// <summary>
    /// 获取菱形范围内没有玩家棋子的随机敌人棋子
    /// </summary>
    /// <returns>随机选择的敌人棋子</returns>
    private ChessPiece GetRandomEnemyPieceWithoutPlayerInDiamond()
    {
        List<ChessPiece> validPieces = new List<ChessPiece>();

        // 遍历所有AI棋子
        foreach (ChessPiece piece in GameObjectMgr.Instance.AIChess)
        {
            // 获取棋子的菱形范围
            List<Vector2> diamondPoints = ChessBoard.chessBoard.GetDiamondPoints(piece.transform.position, piece.roleProperty.f_block);

            bool hasPlayer = false;
            // 检查菱形范围内是否有玩家棋子
            foreach (Vector2 point in diamondPoints)
            {
                ChessPiece checkPiece = ChessBoard.chessBoard.GetPiece(point);
                if (checkPiece != null && checkPiece.color == ChessPiece.PieceFaction.Player)
                {
                    hasPlayer = true;
                    break;
                }
            }

            // 如果菱形范围内没有玩家棋子，则将该棋子添加到有效列表中
            if (!hasPlayer)
            {
                validPieces.Add(piece);
            }
        }

        // 如果有效列表不为空，则随机选择一个棋子
        if (validPieces.Count > 0)
        {
            return validPieces[Random.Range(0, validPieces.Count)];
        }

        return null;
    }

    /// <summary>
    /// 移动棋子
    /// </summary>
    /// <param name="piece"></param>
    private void MovePiece(ChessPiece piece)
    {
        //移动的目标点
        Vector2 targetPos = Vector2.zero;

        // 向最近的玩家棋子移动最大移动力的格数
        ChessPiece nearestPlayer = FindNearestPlayerPiece(piece.transform.position);

        if (nearestPlayer == null)
            return;

        // 检查上下左右四个方向
        Vector2[] directions = new Vector2[]
        {
            new Vector2(0, ChessBoard.chessBoard.cellSize * piece.roleProperty.f_move),  // 上
            new Vector2(0, -ChessBoard.chessBoard.cellSize * piece.roleProperty.f_move), // 下
            new Vector2(-ChessBoard.chessBoard.cellSize * piece.roleProperty.f_move, 0), // 左
            new Vector2(ChessBoard.chessBoard.cellSize * piece.roleProperty.f_move, 0)   // 右
        };

        float minDistance = float.MaxValue; // 初始化最小距离为一个很大的值
        
        foreach (Vector2 dir in directions)
        {
            Vector2 neighbor = (Vector2)piece.transform.position + dir;
            //必须是空位
            if (ChessBoard.chessBoard.GetPiece(neighbor)==null)
            {
                float distance = Vector2.Distance(neighbor, nearestPlayer.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetPos = neighbor;
                }
            }
            
        }

        //GameObject targetObj = GameObject.Instantiate(ChessBoard.chessBoard.point, targetPos, Quaternion.identity);
        //GameObject.Destroy(targetObj,1.5f);

        if (ChessBoard.chessBoard.GetPiece(targetPos) == null&&ChessBoard.chessBoard.IsPositionValid(targetPos))
        {
            if (ChessBoard.chessBoard.GetPiece(targetPos) != null)
                return;

            //MonoMgr.Instance.StartCoroutine(CheckPosIsNull(targetPos, piece));
            //EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
            piece.MoveTo(targetPos);
            //敌人的行动力减1
            GameDataMgr.Instance.enemyMobility--;

            if (GameDataMgr.Instance.enemyMobility <= 0)
                GameDataMgr.Instance.enemyMobility = 0;
            //更新UI
            UIMgr.Instance.GetPanel<GamePanel>(panel =>
            {
                panel.ChangeEnemyMobility(GameDataMgr.Instance.enemyMobility);
            });
        }
        
    }

    /// <summary>
    /// 寻找最近的玩家棋子
    /// </summary>
    /// <param name="startPosition"></param>
    /// <returns></returns>
    private ChessPiece FindNearestPlayerPiece(Vector2 startPosition)
    {
        ChessPiece chessPiece = null;
        float minDistance = float.MaxValue; // 初始化最小距离为一个很大的值

        foreach (ChessPiece piece in GameObjectMgr.Instance.playerChess)
        {    
            if (piece != null)
            {
                //距离检测
                float sqrDistance = ((Vector2)piece.transform.position - startPosition).sqrMagnitude;
                if (sqrDistance < minDistance * minDistance)
                {
                    minDistance = sqrDistance;
                    chessPiece = piece;
                }
            }
            
        }

        return chessPiece;
        
    }

    private IEnumerator CheckPosIsNull(Vector2 pos,ChessPiece piece)
    {
        yield return new WaitForSeconds(0.2f);
        piece.MoveTo(pos);
    }

    public override void QuitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }


    
}
