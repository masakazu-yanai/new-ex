using System.Text.Json.Nodes;
using System.IO;

namespace App;

partial class MenuBuilder
{
    private static String PathNewDefault = @"..\data\new";

    //------------------------------------------------------------
    // 新規ファイル メニューの初期化
    public static void InitMenuNew(object parent, JsonNode? jsonNode,
        System.EventHandler MenuItemExec)
    {
        String pathNew = jsonNode?["menu_new"]?["dir"]?.ToString() ?? PathNewDefault;
        GenMenuNew(parent, Util.GetExeDir() + pathNew, MenuItemExec);
    }

    //------------------------------------------------------------
    // 新規ファイル メニューの再帰的作成
    public static void GenMenuNew(object parent, String dir, System.EventHandler MenuItemExec)
    {
        IEnumerable<string> files = Directory.EnumerateFiles(dir);
        foreach (var file in files)
        {
            String text = Path.GetFileName(file);
            String command = file;
            AddFile(text, command, parent, MenuItemExec);
        }

        IEnumerable<string> subFolders = Directory.EnumerateDirectories(dir);
        foreach (string subFolder in subFolders)
        {
            String text = Path.GetFileName(subFolder);
            ToolStripMenuItem item = AddSubMenu(text, parent);
            GenMenuNew(item, subFolder, MenuItemExec);
        }
    }

    //------------------------------------------------------------
    // 基本メニューの初期化
    public static void InitMenuBase(ContextMenuStrip contextMenuStrip, JsonNode? jsonNode,
        System.EventHandler MenuItemExec)
    {
        if (jsonNode is null) { return; }

        // セパレータの追加
        AddSeparator(contextMenuStrip);

        // 設定の追加
        JsonArray? jsonArray = jsonNode["menu_base"]?.AsArray();
        int i = 0;
        if (jsonArray is not null)
        {
            foreach (JsonNode? child in jsonArray)
            {
                if (child is null) { continue; }

                String text = child["text"]?.ToString() ?? "";
                String command = CmdExec + i++;
                AddConfig(text, command, contextMenuStrip, MenuItemExec);
            }
        }
    }
}
