using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneTimeMgr : SingletonMono<SceneTimeMgr>
{
    // 存储所有场景的历史停留时间（秒）
    private Dictionary<string, int> sceneHistoryTimes = new Dictionary<string, int>();

    // 当前场景的计时变量
    private string currentSceneName;
    private int currentSceneRecordedSeconds = 0;
    private float currentSceneAccumulatedTime = 0f;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 保存当前场景的最终时间到历史记录
        SaveCurrentSceneTime();

        // 重置为新场景的计时
        currentSceneName = scene.name;
        currentSceneRecordedSeconds = 0;
        currentSceneAccumulatedTime = 0f;
    }

    void Update()
    {
        currentSceneAccumulatedTime += Time.deltaTime;

        // 每累积1秒更新整数值
        if (currentSceneAccumulatedTime >= 1f)
        {
            int secondsToAdd = Mathf.FloorToInt(currentSceneAccumulatedTime);
            currentSceneRecordedSeconds += secondsToAdd;
            currentSceneAccumulatedTime %= 1f;
        }
    }

    // 内部方法：保存当前场景时间到历史记录
    private void SaveCurrentSceneTime()
    {
        if (!string.IsNullOrEmpty(currentSceneName))
        {
            int totalSeconds = currentSceneRecordedSeconds + Mathf.FloorToInt(currentSceneAccumulatedTime);

            if (sceneHistoryTimes.ContainsKey(currentSceneName))
            {
                sceneHistoryTimes[currentSceneName] += totalSeconds;
            }
            else
            {
                sceneHistoryTimes.Add(currentSceneName, totalSeconds);
            }
        }
    }

    // 获取当前场景的停留时间（从进入场景开始重新计算）
    public int GetCurrentSceneTime()
    {
        return currentSceneRecordedSeconds + Mathf.FloorToInt(currentSceneAccumulatedTime);
    }

    // 获取指定场景的历史总停留时间（所有次进入的累计）
    public int GetSceneHistoryTime(string sceneName)
    {
        return sceneHistoryTimes.ContainsKey(sceneName) ? sceneHistoryTimes[sceneName] : 0;
    }

    // 手动重置当前场景计时（可选）
    public void ResetCurrentSceneTimer()
    {
        currentSceneRecordedSeconds = 0;
        currentSceneAccumulatedTime = 0f;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
