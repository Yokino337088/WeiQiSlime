using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPanel : BasePanel
{
    private InputField inputCoin;

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        inputCoin = GetControl<InputField>("inputCoin");
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnCanel":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                UIMgr.Instance.HidePanel<InputPanel>();
                break;
            case "btnSure":
                //MusicMgr.Instance.PlaySound("按钮点击");
                //跳转到游戏场景
                UIMgr.Instance.HidePanel<InputPanel>();
                UIMgr.Instance.HidePanel<BeginPanel>();
                GameDataMgr.Instance.player1Coin = int.Parse(inputCoin.text);
                GameDataMgr.Instance.player2Coin = int.Parse(inputCoin.text);
                MusicMgr.Instance.ClearSound();
                PoolMgr.Instance.ClearPool();
                SceneMgr.Instance.LoadSceneAsyn("玩家对战", () =>
                {
                    UIMgr.Instance.ShowPanel<PvpPanel>(E_UILayer.Bottom, (panel) =>
                    {
                        panel.ChangePlayer1Coin(GameDataMgr.Instance.player1Coin);
                        panel.ChangePlayer2Coin(GameDataMgr.Instance.player2Coin);
                        
                    });

                    GameLevelMgr.Instance.SetCheck();
                });
                break;
        }
    }
}
