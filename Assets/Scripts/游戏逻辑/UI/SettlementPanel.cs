using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettlementPanel : BasePanel
{
    public Text txtTitle;

    public Text txtReward;
    public Text txtSpend;
    public Text txtRecord;

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);

        switch (btnName)
        {
            case "btnSure":
                //记录金币，返回开始场景
                GameObjectMgr.Instance.playerRoleInfo = null;
                GameObjectMgr.Instance.AIRoleInfo = null;
                GameLevelMgr.Instance.SetCheckFalse();
                GameObjectMgr.Instance.ClearPiece();
                MusicMgr.Instance.ClearSound();
                PoolMgr.Instance.ClearPool();
                if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
                {
                    UIMgr.Instance.HidePanel<GamePanel>();
                    //对玩家金币进行存档
                    GameDataMgr.Instance.playCoin += GameLevelMgr.Instance.nowLevelInfo.f_gktgjl;
                    GameDataMgr.Instance.SavePlayerCoin();
                    for (int i = 0; i < GameAchieveMgr.Instance.enemyCount; i++)
                    {
                        GameAchieveMgr.Instance.CompleteAchievement(4);
                    }
                    GameAchieveMgr.Instance.SaveAchieveData();
                    GameAchieveMgr.Instance.enemyCount = 0;
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    UIMgr.Instance.HidePanel<PvpPanel>();
                }
                UIMgr.Instance.HidePanel<SettlementPanel>();
                UIMgr.Instance.HidePanel<ReLifePanel>();
                
                SceneMgr.Instance.LoadSceneAsyn("开始场景", () =>
                {
                    UIMgr.Instance.ShowPanel<BeginPanel>(E_UILayer.Middle, (panel) =>
                    {
                        panel.ChangeCoinNum(GameDataMgr.Instance.playCoin);
                    });
                    UIMgr.Instance.HidePanel<SettlementPanel>();
                    //将玩家消费归0
                    GameDataMgr.Instance.playerSpend = 0;
                    GameLevelMgr.Instance.SetCheck();
                    //清空对象池
                    MusicMgr.Instance.ClearSound();
                    PoolMgr.Instance.ClearPool();
                });
                break;
        }
    }

    public void ChangeReward(int reward)
    {
        txtReward.text = reward.ToString();
        //GameDataMgr.Instance.playCoin += reward;
    }

    public void ChangeSpend(int spend)
    {
        txtSpend.text = spend.ToString();
    }

    public void ChangeRecord(int record)
    {
        txtRecord.text = record.ToString();
    }

    public void ChangeTitle(string title)
    {
        txtTitle.text = title;
    }

    /// <summary>
    /// 隐藏多余的字体
    /// </summary>
    public void HideText()
    {
        txtRecord.gameObject.SetActive(false);
        txtSpend.gameObject.SetActive(false);
        txtReward.gameObject.SetActive(false);
    }
}
