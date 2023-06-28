using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace App;

public partial class Util
{
    //------------------------------------------------------------
    // 実行ファイルのディレクトリを取得
    public static String GetExeDir()
    {
        String path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location)?.ToString().TrimEnd('\\') + "\\" ?? "";
        //Console("path1: " + path);

        // 開発時のEXEのパスを正規化する
        path = Regex.Replace(path, @"\\src\\bin\\Debug.+$", "\\src\\");

        //Console("path2: " + path);
        return path;
    }

    //------------------------------------------------------------
    // ファイル読み込み（UTF-8）
    public static String ReadText(String path)
    {
        var text = "";
        try
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                text = sr.ReadToEnd();  // ファイルをオープンして終末まで読む
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return text;
    }

    //------------------------------------------------------------
    // JSON読み込み
    public static JsonNode? ReadJson(String path)
    {
        var jsonString = ReadText(path);
        var jsonNode = JsonNode.Parse(jsonString);
        return jsonNode;
    }

    //------------------------------------------------------------
    // ファイルとディレクトリの存在確認
    public static bool IOExists(String path)
    {
        bool isExist = false;
        if (Directory.Exists(path)) { isExist = true; }
        if (File.Exists(path))      { isExist = true; }
        return isExist;
    }

    //------------------------------------------------------------
    // ファイルとディレクトリの名前変更
    public static void IORename(String pathOld, String pathNew)
    {
        var fileInfo = new FileInfo(pathOld);
        if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
        {
            Directory.Move(pathOld, pathNew);   // ディレクトリの場合
        }
        else
        {
            File.Move(pathOld, pathNew);        // ファイルの場合
        }
    }
}
