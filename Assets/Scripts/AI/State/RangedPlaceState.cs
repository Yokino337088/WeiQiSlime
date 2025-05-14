using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedPlaceState : BaseState
{
    public RangedPlaceState(StateMachine machine) : base(machine)
    {
    }

    public override void EnterState()
    {
        // Debug.Log("AI 进入远程类职业落子状态");

        // 寻找上下左右是己方棋子最多的位置落子
        Vector2 targetPosition = FindBestPosition();

        if (targetPosition != Vector2.zero)
        {
            PlacePiece(targetPosition);
        }
        else
        {
            // 如果没有合适位置，随机落子
            PlaceRandomly();
        }

        // 落子后切换到结束回合状态
        stateMachine.ChangeState(E_AI_State.EndTurn);
    }

    /// <summary>
    ///  寻找上下左右是己方棋子最多的位置
    /// </summary>
    /// <returns></returns>
    private Vector2 FindBestPosition()
    {        
        Vector2 bestPosition = Vector2.zero;
        int maxCount = 0;

        // 遍历棋盘上所有可能的位置
        for (float x = ChessBoard.chessBoard.boardOffset.x; x <= ChessBoard.chessBoard.boardOffset.x + (ChessBoard.chessBoard.boardWidth - 1) * ChessBoard.chessBoard.cellSize; x += ChessBoard.chessBoard.cellSize)
        {
            for (float y = ChessBoard.chessBoard.boardOffset.y; y <= ChessBoard.chessBoard.boardOffset.y + (ChessBoard.chessBoard.boardHeight - 1) * ChessBoard.chessBoard.cellSize; y += ChessBoard.chessBoard.cellSize)
            {
                Vector2 position = new Vector2(x, y);

                if (ChessBoard.chessBoard.GetPiece(position)==null)
                {
                    int count = CountAllyNeighbors(position);

                    if (count > maxCount)
                    {
                        maxCount = count;
                        bestPosition = position;
                    }
                }
                
            }
        }

        return bestPosition;
    }

    /// <summary>
    /// 计算上下左右的己方棋子数量
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private int CountAllyNeighbors(Vector2 position)
    {        
        int count = 0;
        if (ChessBoard.chessBoard.GetPiece(position + Vector2.up * ChessBoard.chessBoard.cellSize)?.color == ChessPiece.PieceFaction.Enemy) count++;
        if (ChessBoard.chessBoard.GetPiece(position + Vector2.down * ChessBoard.chessBoard.cellSize)?.color == ChessPiece.PieceFaction.Enemy) count++;
        if (ChessBoard.chessBoard.GetPiece(position + Vector2.left * ChessBoard.chessBoard.cellSize)?.color == ChessPiece.PieceFaction.Enemy) count++;
        if (ChessBoard.chessBoard.GetPiece(position + Vector2.right * ChessBoard.chessBoard.cellSize)?.color == ChessPiece.PieceFaction.Enemy) count++;
        return count;
    }

    private void PlacePiece(Vector2 position)
    {
        // 落子逻辑
        //Debug.Log($"AI 在 {position} 落子");

        if (ChessBoard.chessBoard.GetPiece(position) != null)
            return;

        ABResMgr.Instance.LoadResAsync<GameObject>("enemypiece", GameObjectMgr.Instance.AIRoleInfo.f_icon, (obj) =>
        {
            MusicMgr.Instance.PlaySound("史莱姆落子");

            ChessPiece aiPiece = GameObject.Instantiate(obj, position, Quaternion.identity).GetComponent<ChessPiece>();

            //设置棋子的阵营
            aiPiece.color = ChessPiece.PieceFaction.Enemy;
            //初始化棋子的数值
            aiPiece.SetData(GameObjectMgr.Instance.AIRoleInfo);
            aiPiece.needCheckSurrounding = true;

            //Debug.Log(aiPiece.roleProperty.f_name);
            //将棋子添加至容器中，便于管理
            GameObjectMgr.Instance.AIChess.Add(aiPiece);
            GameObjectMgr.Instance.allChessList.Add(aiPiece);

        });

        GameDataMgr.Instance.AICoin -= GameObjectMgr.Instance.AIRoleInfo.f_exp;
        UIMgr.Instance.GetPanel<GamePanel>((panel) =>
        {
            panel.ChangeEnemyCoin(GameDataMgr.Instance.AICoin);
        });

        //GameObject pieceObj = PoolMgr.Instance.GetObj("enemypiece/" + GameObjectMgr.Instance.AIRoleInfo.f_icon);
        //pieceObj.transform.position = ChessBoard.chessBoard.GetSnappedPosition(position);
        //ChessPiece aiPiece = pieceObj.GetComponent<ChessPiece>();
        ////设置棋子的阵营
        //aiPiece.color = ChessPiece.PieceFaction.Enemy;
        ////初始化棋子的数值
        //aiPiece.SetData(GameObjectMgr.Instance.AIRoleInfo);
        ////将棋子添加至容器中，便于管理
        //GameObjectMgr.Instance.AIChess.Add(aiPiece);
        //GameObjectMgr.Instance.allChessList.Add(aiPiece);

        //减少行动力
        GameDataMgr.Instance.enemyMobility--;

        if (GameDataMgr.Instance.enemyMobility <= 0)
            GameDataMgr.Instance.enemyMobility = 0;

        UIMgr.Instance.GetPanel<GamePanel>((panel) =>
        {
            panel.ChangeEnemyMobility(GameDataMgr.Instance.enemyMobility);
        });
       // EventCenter.Instance.EventTrigger(E_EventType.E_IsSurrounded);
    }

    private void PlaceRandomly()
    {
        // 随机落子逻辑
        Debug.Log("AI 随机落子");

        // 存储所有空位置的列表
        List<Vector2> emptyPositions = new List<Vector2>();

        // 遍历棋盘网格，找到所有空位置
        for (int x = 0; x < ChessBoard.chessBoard.boardWidth; x++)
        {
            for (int y = 0; y < ChessBoard.chessBoard.boardHeight; y++)
            {
                Vector2 position = new Vector2(ChessBoard.chessBoard.boardOffset.x + x * ChessBoard.chessBoard.cellSize,
                                               ChessBoard.chessBoard.boardOffset.y + y * ChessBoard.chessBoard.cellSize);

                // 检查该位置是否为空
                if (ChessBoard.chessBoard.GetPiece(position) == null)
                {
                    emptyPositions.Add(position);
                }
            }
        }

        // 如果有空位置，随机选择一个
        if (emptyPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, emptyPositions.Count);
            Vector2 randomPosition = emptyPositions[randomIndex];

            // 在随机位置落子
            PlacePiece(randomPosition);
        }
        else
        {
            Debug.Log("棋盘已满，无法落子");
        }
    }

    public override void QuitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
