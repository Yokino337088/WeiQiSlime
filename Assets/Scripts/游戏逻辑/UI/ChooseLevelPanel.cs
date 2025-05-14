using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ChooseLevelPanel : BasePanel
{
    private Text txtCoinNum;
    private ScrollRect svChoose;
    
    private List<LevelItem> levelItems = new List<LevelItem>();

    public Text txtDifficulty;
    public Text txtCoin;
    public Text txtReward;
    public Text txtNum;
    public Text txtLevel;

    public override void HideMe()
    {
        foreach (var item in levelItems)
        {
            Destroy(item.gameObject);

        }
        levelItems.Clear();
    }

    public override void ShowMe()
    {
        txtDifficulty.gameObject.SetActive(false);
        txtCoin.gameObject.SetActive(false);
        txtReward.gameObject.SetActive(false);
        txtNum.gameObject.SetActive(false);
        txtLevel.gameObject.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
        txtCoinNum = GetControl<Text>("txtCoinNum");
        svChoose = GetControl<ScrollRect>("svChoose");
    }

    public void ChangePlayerCoin(long coin)
    {
        txtCoinNum.text = coin.ToString();
    }

    public void ChangeTips(T_Level levelInfo)
    {
        txtDifficulty.gameObject.SetActive(true);
        txtReward.gameObject.SetActive(true);
        if (levelInfo.f_gklx != 3)
        {
            txtCoin.gameObject.SetActive(true);
            txtNum.gameObject.SetActive(true);
            txtLevel.gameObject.SetActive(true);
        }

        txtDifficulty.text = "难度星级：" + levelInfo.f_gklevel.ToString();
        txtCoin.text = "敌人金币：" + levelInfo.f_gkdrjb.ToString();
        txtReward.text= "通关奖励：" + levelInfo.f_gktgjl.ToString();
        txtNum.text= "敌人开局数量：" + levelInfo.f_gkkjsl.ToString();
        txtLevel.text = "关卡等级：" + levelInfo.f_level.ToString();
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnBack":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                UIMgr.Instance.HidePanel<ChooseLevelPanel>();
                GameLevelMgr.Instance.nowLevelInfo = null;
                break;
            case "btnChoose":
                //MusicMgr.Instance.PlaySound("按钮点击");
                if (GameLevelMgr.Instance.nowLevelInfo == null)
                    return;
                MusicMgr.Instance.ClearSound();
                PoolMgr.Instance.ClearPool();
                UIMgr.Instance.HidePanel<ChooseLevelPanel>();
                UIMgr.Instance.HidePanel<BeginPanel>();
               
                //切换至游戏场景
                if (GameLevelMgr.Instance.nowLevelInfo.f_gklx == 3)
                {
                    SceneMgr.Instance.LoadSceneAsyn("新手教学", () =>
                    {
                        if (GameLevelMgr.Instance.nowLevelInfo.f_gkname == "新手教学1")
                        {
                            ChessBoard.chessBoard.TrainPlaceAIPiece(4, 2);
                        }
                        if (GameLevelMgr.Instance.nowLevelInfo.f_gkname == "新手教学2")
                        {
                            ChessBoard.chessBoard.TrainPlaceAIPiece(4, 2);
                            ChessBoard.chessBoard.TrainPlacePlayerPiece(4, 4);
                            ChessBoard.chessBoard.TrainPlacePlayerPiece(2, 2);
                            ChessBoard.chessBoard.TrainPlacePlayerPiece(4, 0);
                            ChessBoard.chessBoard.TrainPlacePlayerPiece(6, 2);
                        }
                        UIMgr.Instance.ShowPanel<GamePanel>(E_UILayer.Bottom, (panel) =>
                        {
                            panel.ChangeEnemyCoin(GameDataMgr.Instance.AICoin);
                            panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                            
                        });
                        UIMgr.Instance.ShowPanel<TipPanel>(E_UILayer.Top, panel =>
                        {
                            panel.ChangeText();
                        });
                        GameLevelMgr.Instance.SetCheck();
                    });
                }
                else
                {
                    SceneMgr.Instance.LoadSceneAsyn("游戏场景", () =>
                    {
                        UIMgr.Instance.ShowPanel<GamePanel>(E_UILayer.Bottom, (panel) =>
                        {
                            GameDataMgr.Instance.AICoin = GameLevelMgr.Instance.nowLevelInfo.f_gkdrjb;
                            panel.ChangeEnemyCoin(GameDataMgr.Instance.AICoin);
                            panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                        });
                        GameLevelMgr.Instance.SetCheck();
                    });
                }
                break;
            case "btnSetting":
                MusicMgr.Instance.PlaySound("按钮点击");
                UIMgr.Instance.ShowPanel<SettingPanel>();
                break;
        }
    }

    public void UpdateSV(E_LevelType type)
    {
        switch (type)
        {
            case E_LevelType.Adventure:
                AddItem2Content(GameLevelMgr.Instance.adventureList);
                break;
            case E_LevelType.War:
                AddItem2Content(GameLevelMgr.Instance.warList);
                break;
            case E_LevelType.train:
                AddItem2Content(GameLevelMgr.Instance.trainList);
                break;
        }
    }

    /// <summary>
    /// 将角色物件加载到Content下
    /// </summary>
    /// <param name="lists"></param>
    private void AddItem2Content(List<T_Level> lists)
    {
        foreach (T_Level levelInfo in lists)
        {
            
            if (levelInfo.isShow)
            {
                ABResMgr.Instance.LoadResAsync<GameObject>("object", "levelItem", (obj) =>
                {
                    LevelItem levelItem = Instantiate(obj).GetComponent<LevelItem>();
                    levelItem.transform.SetParent(svChoose.content, false);
                    levelItem.InitInfo(levelInfo);
                    levelItems.Add(levelItem);
                });
            }
           
        }
    }
}
