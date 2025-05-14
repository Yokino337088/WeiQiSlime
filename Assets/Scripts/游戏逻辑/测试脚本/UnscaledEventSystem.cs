using UnityEngine;
using UnityEngine.EventSystems;

public class UnscaledEventSystem : EventSystem
{
    protected override void Update()
    {
        // 保存原始时间缩放
        float originalTimeScale = Time.timeScale;
        // 临时强制时间缩放为1（确保UI正常）
        Time.timeScale = 1f;
        // 执行父类Update（会处理UI点击事件）
        base.Update();
        // 恢复原始时间缩放
        Time.timeScale = originalTimeScale;
    }
}