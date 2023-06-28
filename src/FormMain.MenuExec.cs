using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;   // Process
using System.Text.Json.Nodes;

namespace App;

public partial class FormMain
{
    //------------------------------------------------------------
    // メニュー実行
    private void MenuItemExec(object? sender, EventArgs e)
    {
        if (sender == null) { return; }

        // 選択処理
        ToolStripMenuItem? menuItem = (ToolStripMenuItem)sender;
        String command = menuItem.Name;

        // コマンドの分解
        String cmndType = MenuBuilder.GetCmndType(command);
        if (cmndType == "") { Util.MesExit("Received unexpected command."); }
        String templatePath = MenuBuilder.GetEraseCmnd(command, cmndType);

        // 実行コマンド
        if (cmndType == MenuBuilder.CmdExec)
        {
            int index = Convert.ToInt32(templatePath);
            ExecMenuBase(index);
            return;
        }

        // 新規ファイル名の作成
        String dir = CmndLinePath;
        String templateFnm = Path.GetFileName(templatePath);
        String fnmNew = FileNameCore.GenNewFileName(dir, templateFnm);
        String pathNew = Path.Combine(dir, fnmNew);

        // 処理の分岐（ファイル/ディレクトリの作成）
        if (cmndType == MenuBuilder.CmdNewFolder) { Directory.CreateDirectory(pathNew); }
        if (cmndType == MenuBuilder.CmdNewFile)   { File.Copy(templatePath, pathNew); }
        Util.SetFileTimeNow(pathNew);   // ファイル/フォルダの時間を今に設定
    }

    //------------------------------------------------------------
    // 基本メニュー コマンド実行
    private void ExecMenuBase(int index)
    {
        String app = "";
        String args = "";

        // 設定の読み取り
        if (JsonConfig is not null)
        {
            JsonArray? jsonArray = JsonConfig["menu_base"]?.AsArray();
            if (jsonArray is not null)
            {
                app  = jsonArray[index]?["app"]?.ToString() ?? "";
                args = jsonArray[index]?["args"]?.ToString() ?? "";
                args = Regex.Replace(args, "%app_dir%", Directory.GetCurrentDirectory());
                args = Environment.ExpandEnvironmentVariables(args);
            }
        }
        if (app == "") { Util.MesExit("The application name is empty."); }

        // 実行
        //Util.Console("app: " + app);
        //Util.Console("args: " + args);
        Process.Start(app, args);
    }
}
