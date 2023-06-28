using System.Text.RegularExpressions;

namespace App;

partial class MenuBuilder
{
    //------------------------------------------------------------
    // 区切り線
    public static void AddSeparator(ContextMenuStrip contextMenuStrip)
    {
        contextMenuStrip.Items.Add("-");
    }

    //------------------------------------------------------------
    // ファイルの追加
    public static void AddFile(String text, String command, object parent,
        System.EventHandler MenuItemExec)
    {
        Image? image = null;
        String reFolder = "\\.folder$";
        if (Regex.IsMatch(command, reFolder))
        {
            // フォルダ追加の場合
            text = Regex.Replace(text, reFolder, "");
            command = CmdNewFolder + Regex.Replace(command, reFolder, "");
            image = Image.FromFile(Util.GetExeDir() + PathIconFolderPlus);
        }
        else
        {
            // ファイル追加の場合
            command = CmdNewFile + command;
            image = Image.FromFile(Util.GetExeDir() + PathIconFile);
        }
        AddMenu(text, command, image, parent, false, MenuItemExec);
    }

    //------------------------------------------------------------
    // 設定の追加
    public static void AddConfig(String text, String command, object parent,
        System.EventHandler MenuItemExec)
    {
        Image image = Image.FromFile(Util.GetExeDir() + PathIconConfig);
        AddMenu(text, command, image, parent, false, MenuItemExec);
    }

    //------------------------------------------------------------
    // サブ メニューの追加
    public static ToolStripMenuItem AddSubMenu(String text, object parent)
    {
        Image image = Image.FromFile(Util.GetExeDir() + PathIconFolder);
        return AddMenu(text, "", image, parent, true, null);
    }

    //------------------------------------------------------------
    // メニューの追加（ContextMenuStrip or ToolStripMenuItem）
    private static ToolStripMenuItem AddMenu(String text, String command, Image? image,
        object parent, bool isSub, System.EventHandler? MenuItemExec)
    {
        ToolStripMenuItem item = new ToolStripMenuItem();
        item.Text = text;
        item.Name = command;
        item.Image = image;
        if (! isSub) { item.Click += MenuItemExec; }

        if (parent is ContextMenuStrip)  { ((ContextMenuStrip)parent).Items.Add(item); }
        if (parent is ToolStripMenuItem) { ((ToolStripMenuItem)parent).DropDownItems.Add(item); }
        return item;
    }
}
