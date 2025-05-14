using Excel;
using System;
using System.Data;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ExcelTool
{
    public static string EXCEL_PATH = Application.dataPath + "/ArtRes/Excel/";
    public static string DATA_CLASS_PATH = Application.dataPath + "/Scripts/ExcelData/DataClass/";
    public static string DATA_CONTAINER_PATH = Application.dataPath + "/Scripts/ExcelData/Container/";
    public static string BINARY_OUTPUT_PATH = Application.streamingAssetsPath + "/Binary/";
    public static int BEGIN_INDEX = 4;

    [MenuItem("GameTool/GenerateExcel")]
    private static void GenerateExcelInfo()
    {
        DirectoryInfo dInfo = Directory.CreateDirectory(EXCEL_PATH);
        FileInfo[] files = dInfo.GetFiles();

        foreach (FileInfo file in files)
        {
            if (file.Extension != ".xlsx" && file.Extension != ".xls")
                continue;

            DataTableCollection tableCollection;
            using (FileStream fs = file.Open(FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                tableCollection = excelReader.AsDataSet().Tables;
            }

            foreach (DataTable table in tableCollection)
            {
                GenerateExcelDataClass(table);
                GenerateExcelContainer(table);
                GenerateExcelBinary(table);
            }
        }
        AssetDatabase.Refresh();
    }

    private static void GenerateExcelDataClass(DataTable table)
    {
        if (!Directory.Exists(DATA_CLASS_PATH))
            Directory.CreateDirectory(DATA_CLASS_PATH);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("[System.Serializable]");
        sb.AppendLine($"public class {table.TableName}");
        sb.AppendLine("{");

        DataRow rowName = table.Rows[0];
        DataRow rowType = table.Rows[1];

        for (int i = 0; i < table.Columns.Count; i++)
        {
            if (string.IsNullOrEmpty(rowName[i].ToString()))
                continue;

            string type = string.IsNullOrEmpty(rowType[i].ToString()) ? "int" : rowType[i].ToString();
            sb.AppendLine($"    public {type} {rowName[i]};");
        }

        sb.AppendLine("}");

        File.WriteAllText(DATA_CLASS_PATH + table.TableName + ".cs", sb.ToString());
    }

    private static void GenerateExcelContainer(DataTable table)
    {
        if (!Directory.Exists(DATA_CONTAINER_PATH))
            Directory.CreateDirectory(DATA_CONTAINER_PATH);

        int keyIndex = GetKeyIndex(table);
        string keyType = GetVariableTypeRow(table)[keyIndex].ToString();
        keyType = string.IsNullOrEmpty(keyType) ? "int" : keyType;

        string str = $@"using System.Collections.Generic;

public class {table.TableName}Container
{{
    public Dictionary<{keyType}, {table.TableName}> dataDic = new Dictionary<{keyType}, {table.TableName}>();
}}";

        File.WriteAllText(DATA_CONTAINER_PATH + table.TableName + "Container.cs", str);
    }

    private static void GenerateExcelBinary(DataTable table)
    {
        if (!Directory.Exists(BINARY_OUTPUT_PATH))
            Directory.CreateDirectory(BINARY_OUTPUT_PATH);

        string filePath = Path.Combine(BINARY_OUTPUT_PATH, table.TableName + ".tang");
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            int rowCount = table.Rows.Count - BEGIN_INDEX;
            fs.Write(BitConverter.GetBytes(rowCount), 0, 4);

            int keyIndex = GetKeyIndex(table);
            string keyName = GetVariableNameRow(table)[keyIndex].ToString();
            byte[] keyNameBytes = Encoding.UTF8.GetBytes(keyName);
            fs.Write(BitConverter.GetBytes(keyNameBytes.Length), 0, 4);
            fs.Write(keyNameBytes, 0, keyNameBytes.Length);

            DataRow rowType = GetVariableTypeRow(table);
            DataRow rowName = GetVariableNameRow(table);
            int validRowCount = 0;

            for (int i = BEGIN_INDEX; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                object keyValue = row[keyIndex];

                if (keyValue == null || string.IsNullOrEmpty(keyValue.ToString()))
                {
                    Debug.LogError($"表 {table.TableName} 第{i + 1}行键值为空，已跳过");
                    continue;
                }

                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(rowName[j].ToString()))
                        continue;

                    try
                    {
                        WriteFieldValue(fs, row[j], rowType[j].ToString());
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"表 {table.TableName} 第{i + 1}行第{j + 1}列数据写入失败: {ex.Message}");
                    }
                }
                validRowCount++;
            }

            if (validRowCount != rowCount)
            {
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(BitConverter.GetBytes(validRowCount), 0, 4);
                Debug.LogWarning($"表 {table.TableName} 行数修正: {rowCount} -> {validRowCount}");
            }
        }
    }

    private static void WriteFieldValue(FileStream fs, object value, string fieldType)
    {
        if (value == null) value = "";

        switch (fieldType.ToLower())
        {
            case "int":
            case "":
                int intValue;
                if (!int.TryParse(value.ToString(), out intValue))
                    intValue = 0;
                fs.Write(BitConverter.GetBytes(intValue), 0, 4);
                break;

            case "float":
                float floatValue;
                if (!float.TryParse(value.ToString(), out floatValue))
                    floatValue = 0f;
                fs.Write(BitConverter.GetBytes(floatValue), 0, 4);
                break;

            case "bool":
                bool boolValue = IsTrueValue(value.ToString());
                fs.Write(BitConverter.GetBytes(boolValue), 0, 1);
                break;

            case "string":
                byte[] strBytes = Encoding.UTF8.GetBytes(value.ToString());
                fs.Write(BitConverter.GetBytes(strBytes.Length), 0, 4);
                fs.Write(strBytes, 0, strBytes.Length);
                break;

            default:
                throw new ArgumentException($"不支持的类型: {fieldType}");
        }
    }

    private static bool IsTrueValue(string value)
    {
        value = value.Trim().ToLower();
        return value == "true" || value == "1" || value == "是" || value == "yes";
    }

    private static DataRow GetVariableNameRow(DataTable table)
    {
        return table.Rows[0];
    }

    private static DataRow GetVariableTypeRow(DataTable table)
    {
        return table.Rows[1];
    }

    private static int GetKeyIndex(DataTable table)
    {
        DataRow keyMarkRow = table.Rows[2];
        for (int i = 0; i < table.Columns.Count; i++)
        {
            if (keyMarkRow[i].ToString().Trim().ToLower() == "key")
                return i;
        }
        Debug.LogError($"表 {table.TableName} 未找到主键列，默认使用第一列");
        return 0;
    }
}