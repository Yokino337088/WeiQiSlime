using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    private Text txtCoinNum;
    private Text txtTips;


    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        txtCoinNum = GetControl<Text>("txtCoinNum");
        txtTips = GetControl<Text>("txtTips");
        
    }

    private void Start()
    {
        Invoke(nameof(DelayChangeCoin), 0.5f);
    }
    private void Update()
    {
       
    }

    /// <summary>
    /// 改变金币数量的方法
    /// </summary>
    /// <param name="num"></param>
    public void ChangeCoinNum(long num)
    {
        txtCoinNum.text = num.ToString();
    }

    public void DelayChangeCoin()
    {
        ChangeCoinNum(GameDataMgr.Instance.playCoin);
    }

    /// <summary>
    /// 改变提示文字的方法
    /// </summary>
    /// <param name="tips"></param>
    public void ChangeTips(string tips)
    {
        txtTips.text = tips;
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);

        switch (btnName)
        {
            case "btnAchieve":
                //打开成就面板
                MusicMgr.Instance.PlaySound("按钮点击");
                UIMgr.Instance.ShowPanel<AchievePanel>(E_UILayer.Top);
                break;
            case "btnSetting":
                //打开设置面板
                MusicMgr.Instance.PlaySound("按钮点击");
                UIMgr.Instance.ShowPanel<SettingPanel>(E_UILayer.Top);
                break;
            case "btnAdventure":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开选关面板（冒险关卡）然后跳转至游戏场景
                UIMgr.Instance.ShowPanel<ChooseLevelPanel>(E_UILayer.Middle,(panel) =>
                {
                    panel.UpdateSV(E_LevelType.Adventure);
                    panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                });
                
                break;
            case "btnTavern":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开酒馆面板
                UIMgr.Instance.ShowPanel<TavernPanel>();
                GameDataMgr.Instance.isShowTavernPanel = true;
                break;
            case "btnPVP":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开输入金币面板，然后跳转至游戏场景
                UIMgr.Instance.ShowPanel<InputPanel>();
                break;
            case "btnPVE":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开输入金币面板，然后跳转至游戏场景
                UIMgr.Instance.ShowPanel<InputPanel>();
                break;
            case "btnTrain":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开选关面板（新手训练营）然后跳转至游戏场景
                UIMgr.Instance.ShowPanel<ChooseLevelPanel>(E_UILayer.Middle, (panel) =>
                {
                    panel.UpdateSV(E_LevelType.train);
                    panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                });
                break;
            case "btnWar":
                MusicMgr.Instance.PlaySound("按钮点击");
                //打开选关面板（战争关卡）然后跳转至游戏场景
                UIMgr.Instance.ShowPanel<ChooseLevelPanel>(E_UILayer.Middle, (panel) =>
                {
                    panel.UpdateSV(E_LevelType.War);
                    panel.ChangePlayerCoin(GameDataMgr.Instance.playCoin);
                });
                
                break;
            case "btnJoin":
                //一键加群
                break;
            case "btnAdvertise":
                MusicMgr.Instance.PlaySound("按钮点击");
                //播放广告
                AdvertisementMgr.Instance.ShowAdv();
                break;
        }
    }

}
