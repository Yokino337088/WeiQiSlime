using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 跨平台二进制数据管理器（最终版）
/// 功能：
/// 1. 支持Android/iOS/PC多平台
/// 2. 保留原有所有接口
/// 3. 增强错误处理和日志
/// </summary>
public class BinaryDataMgr : BaseManager<BinaryDataMgr>
{
    public enum DuplicateKeyBehavior
    {
        Overwrite,
        Skip,
        ThrowError
    }

    [Header("数据配置")]
    public DuplicateKeyBehavior duplicateKeyHandling = DuplicateKeyBehavior.Overwrite;
    public bool allowEmptyKeys = false;

    // 路径定义
    private static readonly string BINARY_SUB_PATH = "Binary/";
    private static readonly string SAVE_PATH = Application.persistentDataPath + "/Data/";
    private Dictionary<string, object> tableDic = new Dictionary<string, object>();


    private BinaryDataMgr()
    {

    }

    /// <summary> 获取StreamingAssets二进制文件路径（自动适配平台） </summary>
    private string GetBinaryFilePath(string fileName)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.streamingAssetsPath, BINARY_SUB_PATH, fileName);
#elif UNITY_IOS && !UNITY_EDITOR
        return "file://" + Path.Combine(Application.streamingAssetsPath, BINARY_SUB_PATH, fileName);
#else
        return Path.Combine(Application.streamingAssetsPath, BINARY_SUB_PATH, fileName);
#endif
    }

    // 初始化方法保持不变
    public void InitData()
    {
#if UNITY_EDITOR
        LoadTable<T_RoleContainer, T_Role>();
        LoadTable<T_LevelContainer, T_Level>();
        LoadTable<T_AchieveContainer, T_Achieve>();
#else
        MonoMgr.Instance.StartCoroutine(InitDataAsync());
#endif
    }

    private IEnumerator InitDataAsync()
    {
        yield return LoadTableAsync<T_RoleContainer, T_Role>();
        yield return LoadTableAsync<T_LevelContainer, T_Level>();
        yield return LoadTableAsync<T_AchieveContainer, T_Achieve>();
    }

    // 主加载接口保持不变
    public void LoadTable<T, K>()
    {
#if UNITY_ANDROID || UNITY_IOS
        MonoMgr.Instance.StartCoroutine(LoadTableAsync<T, K>());
#else
        LoadTableDesktop<T, K>();
#endif
    }

    // Android/iOS专用异步加载
    private IEnumerator LoadTableAsync<T, K>()
    {
        string fileName = typeof(K).Name + ".tang";
        string filePath = GetBinaryFilePath(fileName);

        using (UnityWebRequest request = UnityWebRequest.Get(filePath))
        {
            request.timeout = 15;
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"加载失败: {filePath}\nError: {request.error}");
                yield break;
            }

            ProcessBinaryData<T, K>(request.downloadHandler.data);
        }
    }

    // PC/Editor专用同步加载
    private void LoadTableDesktop<T, K>()
    {
        string fileName = typeof(K).Name + ".tang";
        string filePath = GetBinaryFilePath(fileName);

        if (!File.Exists(filePath))
        {
            Debug.LogError($"文件不存在: {filePath}");
            return;
        }

        try
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            ProcessBinaryData<T, K>(bytes);
        }
        catch (Exception ex)
        {
            Debug.LogError($"加载失败: {filePath}\n{ex.Message}");
        }
    }

    // 统一的二进制数据处理核心（保持原有逻辑）
    private void ProcessBinaryData<T, K>(byte[] bytes)
    {
        try
        {
            int index = 0;
            int count = BitConverter.ToInt32(bytes, index);
            index += 4;

            int keyNameLength = BitConverter.ToInt32(bytes, index);
            index += 4;
            string keyName = Encoding.UTF8.GetString(bytes, index, keyNameLength);
            index += keyNameLength;

            Type containerType = typeof(T);
            object containerObj = Activator.CreateInstance(containerType);
            object dicObject = containerType.GetField("dataDic").GetValue(containerObj);

            MethodInfo containsKey = dicObject.GetType().GetMethod("ContainsKey");
            MethodInfo addMethod = dicObject.GetType().GetMethod("Add");
            PropertyInfo indexer = dicObject.GetType().GetProperty("Item");

            int successCount = 0;
            Type classType = typeof(K);
            FieldInfo[] fields = classType.GetFields();
            FieldInfo keyField = classType.GetField(keyName);

            for (int i = 0; i < count; i++)
            {
                object dataObj = ReadTableRow(bytes, ref index, classType, fields, out bool isValid);
                if (!isValid) continue;

                object keyValue = keyField.GetValue(dataObj);
                if (!ValidateKey(keyValue, classType, i + 1)) continue;

                bool isDuplicate = (bool)containsKey.Invoke(dicObject, new[] { keyValue });
                if (isDuplicate)
                {
                    HandleDuplicateKey(dicObject, keyValue, dataObj, containerType.Name, i + 1, indexer);
                }
                else
                {
                    addMethod.Invoke(dicObject, new[] { keyValue, dataObj });
                    successCount++;
                }
            }

            tableDic[typeof(T).Name] = containerObj;
            Debug.Log($"{typeof(T).Name} 加载完成: {successCount}/{count}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"处理二进制数据失败: {typeof(T).Name}\n{ex}");
        }
    }

    // 保留原有的字段读取方法
    private object ReadTableRow(byte[] bytes, ref int index, Type classType, FieldInfo[] fields, out bool isValid)
    {
        object dataObj = Activator.CreateInstance(classType);
        isValid = true;

        foreach (FieldInfo field in fields)
        {
            try
            {
                if (!ReadFieldValue(bytes, ref index, field, dataObj))
                {
                    isValid = false;
                    break;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"读取字段失败: {field.Name}\n{ex}");
                isValid = false;
            }
        }

        return isValid ? dataObj : null;
    }

    // 保留原有的字段值读取方法
    private bool ReadFieldValue(byte[] bytes, ref int index, FieldInfo field, object target)
    {
        if (field.FieldType == typeof(int))
        {
            field.SetValue(target, BitConverter.ToInt32(bytes, index));
            index += 4;
        }
        else if (field.FieldType == typeof(float))
        {
            field.SetValue(target, BitConverter.ToSingle(bytes, index));
            index += 4;
        }
        else if (field.FieldType == typeof(bool))
        {
            field.SetValue(target, BitConverter.ToBoolean(bytes, index));
            index += 1;
        }
        else if (field.FieldType == typeof(string))
        {
            int length = BitConverter.ToInt32(bytes, index);
            index += 4;
            string value = Encoding.UTF8.GetString(bytes, index, length);
            field.SetValue(target, value);
            index += length;
        }
        else
        {
            Debug.LogError($"不支持的类型: {field.FieldType}");
            return false;
        }
        return true;
    }

    // 保留原有的键值验证方法
    private bool ValidateKey(object keyValue, Type classType, int rowNum)
    {
        if (keyValue == null)
        {
            Debug.LogError($"空键值: {classType.Name} 行{rowNum}");
            return false;
        }
        return true;
    }

    // 保留原有的重复键处理方法
    private void HandleDuplicateKey(object dic, object key, object value, string tableName, int rowNum, PropertyInfo indexer)
    {
        string msg = $"重复键: {tableName} 行{rowNum}\n键值: {key}";
        switch (duplicateKeyHandling)
        {
            case DuplicateKeyBehavior.Overwrite:
                indexer.SetValue(dic, value, new[] { key });
                break;
            case DuplicateKeyBehavior.Skip:
                Debug.LogWarning(msg + " (已跳过)");
                break;
            case DuplicateKeyBehavior.ThrowError:
                throw new Exception(msg);
        }
    }

    // 保留原有的表格获取方法
    public T GetTable<T>() where T : class
    {
        string tableName = typeof(T).Name;
        if (tableDic.TryGetValue(tableName, out object table))
        {
            return table as T;
        }
        Debug.LogError($"表不存在: {tableName}");
        return null;
    }

    // 保留原有的保存方法（用于可读写数据）
    public void Save(object obj, string fileName)
    {
        if (!Directory.Exists(SAVE_PATH))
            Directory.CreateDirectory(SAVE_PATH);

        string filePath = Path.Combine(SAVE_PATH, fileName + ".tang");
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
                Debug.Log($"数据已保存到: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"保存失败: {filePath}\n{ex.Message}");
        }
    }

    // 保留原有的加载方法（用于可读写数据）
    public T Load<T>(string fileName) where T : class
    {
        string filePath = Path.Combine(SAVE_PATH, fileName + ".tang");

        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"文件不存在: {filePath}");
            return default;
        }

        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(fs) as T;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"加载失败: {filePath}\n{ex.Message}");
            return default;
        }
    }

    // 保留原有的数据验证方法
    public void VerifyTableIntegrity<T>() where T : class
    {
        string tableName = typeof(T).Name;
        if (!tableDic.TryGetValue(tableName, out object container))
        {
            Debug.LogError($"验证失败: 表 {tableName} 未加载");
            return;
        }

        var dicField = container.GetType().GetField("dataDic");
        if (dicField == null)
        {
            Debug.LogError($"验证失败: {tableName} 缺少 dataDic 字段");
            return;
        }

        if (!(dicField.GetValue(container) is IDictionary dic))
        {
            Debug.LogError($"验证失败: {tableName}.dataDic 不是字典类型");
            return;
        }

        HashSet<object> keySet = new HashSet<object>();
        ArrayList duplicateKeys = new ArrayList();

        foreach (var key in dic.Keys)
        {
            if (!keySet.Add(key))
            {
                duplicateKeys.Add(key);
            }
        }
        if (duplicateKeys.Count > 0)
        {
            Debug.LogError($"表 {tableName} 完整性验证失败 - 发现 {duplicateKeys.Count} 个重复键:");
            foreach (var key in duplicateKeys)
            {
                Debug.LogError($"重复键: {key} (类型: {key.GetType().Name})");
            }
        }
        else
        {
            Debug.Log($"表 {tableName} 完整性验证通过 - 共 {dic.Count} 条记录");
        }
    }

    // 新增辅助方法：检查存档是否存在
    public bool HasSavedData(string fileName)
    {
        string filePath = Path.Combine(SAVE_PATH, fileName + ".tang");
        return File.Exists(filePath);
    }
}