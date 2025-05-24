using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLifePanel : BasePanel
{
    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
            UIMgr.Instance.HidePanel<ReLifePanel>();
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);

        switch (btnName)
        {
            case "btnSure":
                UIMgr.Instance.HidePanel<ReLifePanel>();
                ChessBoard.chessBoard.DeleteTenAIPiece();
                AdvertisementMgr.Instance.ShowAdv();
                break;
        }
    }
}
