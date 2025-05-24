using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 关卡类型
/// </summary>
public enum E_LevelType
{
    Adventure,
    War,
    train
}

public class GameLevelMgr : SingletonAutoMono<GameLevelMgr>
{
    //当前选中的关卡信息
    public T_Level nowLevelInfo;

    
    //储存冒险关卡的列表
    public List<T_Level> adventureList=new List<T_Level>();
    //储存战争关卡的列表
    public List<T_Level> warList=new List<T_Level>();
    //储存新手关卡的列表
    public List<T_Level> trainList=new List<T_Level>();

    //当前选中的关卡物件
    public LevelItem nowSelectItem;

    private bool isCheck = true;
    private bool isShow = true;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1&& SceneTimeMgr.Instance.GetCurrentSceneTime()> 20 && isCheck)
        {
            //判断输赢
            CheckWinOrFail();            
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && SceneTimeMgr.Instance.GetCurrentSceneTime() > 20 && isCheck)
        {
            CheckWinOrFailPVP();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && SceneTimeMgr.Instance.GetCurrentSceneTime() > 10 && isCheck)
        {
            CheckTrain();
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && SceneTimeMgr.Instance.GetCurrentSceneTime() < 580 && isShow)
            CheckAIPieceIsFull();
    }

    /// <summary>
    /// 加载关卡数据
    /// </summary>
    public void LoadLevelData()
    { 
        foreach (var key in BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic.Keys)
        {
            switch (BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic[key].f_gklx)
            {
                case 1:
                    warList.Add(BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic[key]);
                    break;
                case 2:
                    adventureList.Add(BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic[key]);
                    break;
                case 3:
                    trainList.Add(BinaryDataMgr.Instance.GetTable<T_LevelContainer>().dataDic[key]);
                    break;
            }
        }
    }

    /// <summary>
    /// 存档关卡数据
    /// </summary>
    public void SaveLevelData()
    {
        BinaryDataMgr.Instance.Save(warList, "warList");
        BinaryDataMgr.Instance.Save(adventureList, "adventureList");
        BinaryDataMgr.Instance.Save(trainList, "trainList");
    }

    /// <summary>
    /// 读取关卡存档
    /// </summary>
    public void GetLevelData()
    {
        if (BinaryDataMgr.Instance.Load<List<T_Level>>("warList") != null)
            warList = BinaryDataMgr.Instance.Load<List<T_Level>>("warList");

        if (BinaryDataMgr.Instance.Load<List<T_Level>>("adventureList") != null)
            adventureList = BinaryDataMgr.Instance.Load<List<T_Level>>("adventureList");

        if (BinaryDataMgr.Instance.Load<List<T_Level>>("trainList") != null)
            trainList = BinaryDataMgr.Instance.Load<List<T_Level>>("trainList");
    }

    /// <summary>
    /// 判断输赢
    /// </summary>
    private void CheckWinOrFail()
    {
        if (GameDataMgr.Instance.AICoin <= 10 && GameObjectMgr.Instance.AIChess.Count == 0)
        {
            if (warList.Contains(nowLevelInfo))
            {
                int index = warList.IndexOf(nowLevelInfo) + 1;
                if (index >= warList.Count)
                    index = warList.Count - 1;
                warList[index].isShow = true;
            }
            else if (adventureList.Contains(nowLevelInfo))
            {
                int index = adventureList.IndexOf(nowLevelInfo) + 1;
                if (index >= adventureList.Count)
                    index = adventureList.Count - 1;
                adventureList[index].isShow = true;
            }

            SaveLevelData();

            //玩家获胜的逻辑
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("胜利");
                panel.ChangeReward(nowLevelInfo.f_gktgjl);
                panel.ChangeSpend(GameDataMgr.Instance.playerSpend);                                    
                panel.ChangeRecord(GameDataMgr.Instance.MinLevelSpend);
            });
            //更新关卡成就
            GameAchieveMgr.Instance.CompleteAchievement(nowLevelInfo.f_gkid);
            
            isCheck = false;
        }
        else if (GameDataMgr.Instance.playCoin < 10 && GameObjectMgr.Instance.playerChess.Count == 0)
        {
            //AI获胜的逻辑
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("失败");
                nowLevelInfo.f_gktgjl = 0;
                panel.ChangeReward(nowLevelInfo.f_gktgjl);
                panel.ChangeSpend(GameDataMgr.Instance.playerSpend);                
                panel.ChangeRecord(GameDataMgr.Instance.MinLevelSpend);
            });
            
            
            isCheck = false;
        }
        else
            isCheck = true;

        if (SceneTimeMgr.Instance.GetCurrentSceneTime() >= 600)
        {
            if (GameObjectMgr.Instance.playerChess.Count > GameObjectMgr.Instance.AIChess.Count)
            {
                if (warList.Contains(nowLevelInfo))
                {
                    int index = warList.IndexOf(nowLevelInfo) + 1;
                    if (index >= warList.Count)
                        index = warList.Count - 1;
                    warList[index].isShow = true;
                }
                else if (adventureList.Contains(nowLevelInfo))
                {
                    int index = adventureList.IndexOf(nowLevelInfo) + 1;
                    if (index >= warList.Count)
                        index = warList.Count - 1;
                    adventureList[index].isShow = true;
                }

                SaveLevelData();
                //清除场景上的棋子
                GameObjectMgr.Instance.ClearPiece();
                //玩家获胜的逻辑
                UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
                {
                    panel.ChangeTitle("胜利");
                    panel.ChangeReward(nowLevelInfo.f_gktgjl);
                    panel.ChangeSpend(GameDataMgr.Instance.playerSpend);                
                    panel.ChangeRecord(GameDataMgr.Instance.MinLevelSpend);
                });
                //更新关卡成就
                GameAchieveMgr.Instance.CompleteAchievement(nowLevelInfo.f_gkid);
                GameAchieveMgr.Instance.CompleteAchievement(5);
                GameAchieveMgr.Instance.SaveAchieveData();
                isCheck = false;
            }
            else if(GameObjectMgr.Instance.AIChess.Count> GameObjectMgr.Instance.playerChess.Count)
            {
                //清除场景上的棋子
                GameObjectMgr.Instance.ClearPiece();
                //AI获胜的逻辑
                UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
                {
                    panel.ChangeTitle("失败");
                    nowLevelInfo.f_gktgjl = 0;
                    panel.ChangeReward(nowLevelInfo.f_gktgjl);
                    panel.ChangeSpend(GameDataMgr.Instance.playerSpend);                    
                    panel.ChangeRecord(GameDataMgr.Instance.MinLevelSpend);
                });
                //更新关卡成就
                GameAchieveMgr.Instance.CompleteAchievement(nowLevelInfo.f_gkid);
                isCheck = false;
            }
        }

        if (GameObjectMgr.Instance.playerChess.Count >= 81)
        {
            if (warList.Contains(nowLevelInfo))
            {
                int index = warList.IndexOf(nowLevelInfo) + 1;
                if (index >= warList.Count)
                    index = warList.Count - 1;
                warList[index].isShow = true;
            }
            else if (adventureList.Contains(nowLevelInfo))
            {
                int index = adventureList.IndexOf(nowLevelInfo) + 1;
                if (index >= adventureList.Count)
                    index = adventureList.Count - 1;
                adventureList[index].isShow = true;
            }

            SaveLevelData();
            //玩家获胜的逻辑
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("胜利");
                panel.ChangeReward(nowLevelInfo.f_gktgjl);
                panel.ChangeSpend(GameDataMgr.Instance.playerSpend);
                panel.ChangeRecord(GameDataMgr.Instance.MinLevelSpend);
            });

            //更新关卡成就
            GameAchieveMgr.Instance.CompleteAchievement(nowLevelInfo.f_gkid);

            isCheck = false;
        }
        
    }

    private void CheckWinOrFailPVP()
    {
        //玩家2胜利
        if (GameDataMgr.Instance.player1Coin < 10 && GameObjectMgr.Instance.player1List.Count == 0)
        {
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("玩家2胜利");
                
            });
            isCheck = false;
        }
        //玩家1胜利
        else if (GameDataMgr.Instance.player2Coin < 10 && GameObjectMgr.Instance.player2List.Count == 0)
        {
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("玩家1胜利");
                
            });
            isCheck = false;
        }
        else
            isCheck = true;
    }

    /// <summary>
    /// 检测新手关卡是否胜利
    /// </summary>
    private void CheckTrain()
    {
        if (GameObjectMgr.Instance.AIChess.Count == 0)
        {
            int index = trainList.IndexOf(nowLevelInfo) + 1;
            if (index >= trainList.Count)
                index = trainList.Count - 1;
            trainList[index].isShow = true;

            SaveLevelData();

            UIMgr.Instance.HidePanel<TipPanel>();
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("胜利");
                if (nowLevelInfo.f_gkname == "新手教学1")
                {
                    //nowLevelInfo.f_gktgjl = 100;
                    panel.ChangeRecord(40);
                }  
                if (nowLevelInfo.f_gkname == "新手教学2")
                {
                    //nowLevelInfo.f_gktgjl = 200;
                    panel.ChangeRecord(0);
                }
                panel.ChangeReward(nowLevelInfo.f_gktgjl);
                panel.ChangeSpend(GameDataMgr.Instance.playerSpend);
            });

            //更新成就
            GameAchieveMgr.Instance.CompleteAchievement(nowLevelInfo.f_gkid);
            isCheck = false;
        }
    }

    public void SetCheck()
    {
        isCheck=true;
    }

    public void SetCheckFalse()
    {
        isCheck =false;
    }

    /// <summary>
    /// pvp对战时间结束的判断输赢
    /// </summary>
    public void CheckTimeEndPvp()
    {
        if (GameObjectMgr.Instance.player1List.Count > GameObjectMgr.Instance.player2List.Count)
        {
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("玩家1胜利");
                panel.HideText();
            });
        }
        else if (GameObjectMgr.Instance.player1List.Count < GameObjectMgr.Instance.player2List.Count)
        {
            UIMgr.Instance.ShowPanel<SettlementPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTitle("玩家2胜利");
                panel.HideText();
            });
        }
    }

    /// <summary>
    /// 检测敌人棋子是否占满
    /// </summary>
    private void CheckAIPieceIsFull()
    {
        if (GameObjectMgr.Instance.AIChess.Count >= 81)
        {
            UIMgr.Instance.ShowPanel<ReLifePanel>(E_UILayer.Bottom);
            isShow = false;
        }
        else
        {
            isShow = true;
            return;
        }

    }

    public void SetRelifeIsShow()
    {
        isShow = true;
    }


}
