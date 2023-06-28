using System.Text.RegularExpressions;

namespace App;

partial class MenuBuilder
{
    //------------------------------------------------------------
    // コマンド種類を取得
    public static String GetCmndType(String command)
    {
        String cmndType = "";
        if (command.StartsWith(MenuBuilder.CmdNewFolder)) { cmndType = MenuBuilder.CmdNewFolder; }
        if (command.StartsWith(MenuBuilder.CmdNewFile))   { cmndType = MenuBuilder.CmdNewFile; }
        if (command.StartsWith(MenuBuilder.CmdExec))      { cmndType = MenuBuilder.CmdExec; }
        return cmndType;
    }

    //------------------------------------------------------------
    // コマンド部分を削除
    public static String GetEraseCmnd(String command, String cmndType)
    {
        String eraseCmnd = Regex.Replace(command, "^" + cmndType, "");
        return eraseCmnd;
    }
}
