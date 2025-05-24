using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class RoleItem : BasePanel
{
    public T_Role roleInfo;
    public Text txtLevelNum;
    public Text txtName;
    public Text txtPrice;
    public Image imgIcon;
    public Image imgBK;
    public Text txtLock;

    public Sprite spriteSelect;
    public Sprite spriteSource;

    public override void HideMe()
    {
       
    }

    public override void ShowMe()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        
    }

    public void InitInfo(T_Role role)
    {
        roleInfo = role;
        txtLevelNum.text = roleInfo.f_level.ToString();
        txtName.text = roleInfo.f_name.ToString();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            txtLock.text = roleInfo.isUnlock ? "已解锁" : "未解锁";
            txtLock.color = roleInfo.isUnlock ? Color.black : Color.red;
        }
        else
            txtLock.gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 0)
            txtPrice.text = (roleInfo.f_exp * 10 * roleInfo.f_level).ToString();
        else
            txtPrice.text = roleInfo.f_exp.ToString();

        imgBK.sprite = spriteSource;

        imgIcon.sprite = ResMgr.Instance.Load<SpriteAtlas>("图片/atlas").GetSprite(role.f_icon);
        

    }

    public void ClickIcon(BaseEventData data)
    {
        MusicMgr.Instance.PlaySound("按钮点击");
        //当玩家再次点击时，切换为初始状态的图片
        if (GameObjectMgr.Instance.nowRoleItem != null && GameObjectMgr.Instance.nowRoleItem != this)
        {
            GameObjectMgr.Instance.nowRoleItem.imgBK.sprite = spriteSource;

            GameObjectMgr.Instance.nowRoleItem=null;
            GameObjectMgr.Instance.playerRoleInfo=null;
        }

        //赋值变量
        if (SceneManager.GetActiveScene().buildIndex == 1|| SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObjectMgr.Instance.isPlayerSelect = true;
            GameObjectMgr.Instance.playerRoleInfo = roleInfo;
            GameObjectMgr.Instance.isClickPiece = false;
            
        }       

        GameObjectMgr.Instance.nowRoleItem = this;        
        GameObjectMgr.Instance.playerRoleInfo = roleInfo;
        imgBK.sprite = spriteSelect;


        //解锁角色
        if (SceneManager.GetActiveScene().buildIndex == 0 )
        {
            UIMgr.Instance.ShowPanel<BuyPanel>(E_UILayer.Top, (panel) =>
            {
                panel.ChangeTips(GameObjectMgr.Instance.playerRoleInfo.f_exp * 10* GameObjectMgr.Instance.playerRoleInfo.f_level, GameObjectMgr.Instance.playerRoleInfo.f_name);
                panel.SetRoleInfo(roleInfo);
            });
            
        }
        
        
        
    }

   /// <summary>
   /// 用于给外部复原图片的方法
   /// </summary>
    public void SetSprite()
    {
        imgBK.sprite = spriteSource;
    }
   
}
