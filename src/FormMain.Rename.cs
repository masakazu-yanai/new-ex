using System.Text.Json.Nodes;

namespace App;

public partial class FormMain
{
    private void Rename()
    {
        // リネームのテンプレートを取得
        String templateFnm = GetRenameTemplateFnm();
        if (templateFnm == "") { return; }
        //Util.Console("templateRename : " + templateFnm);

        // 旧ファイル名とディレクトリの取得
        String pathOld = CmndLinePath;
        String dir = Path.GetDirectoryName(pathOld) ?? "";
        if (dir == "") { return; }

        // 新規ファイル名の作成
        String fnmNew = FileNameCore.GenNewFileName(dir, templateFnm, pathOld);
        String pathNew = Path.Combine(dir, fnmNew);
        //Util.Console("old : " + pathOld);
        //Util.Console("new : " + pathNew);

        // 元ファイルの存在確認
        if (! Util.IOExists(pathOld)) { Util.MesExit("Not Exist.\n" + pathOld); }
        if (Util.IOExists(pathNew))   { Util.MesExit("Exist.\n" + pathNew); }

        // リネーム
        Util.IORename(pathOld, pathNew);
    }

    //------------------------------------------------------------
    private String GetRenameTemplateFnm()
    {
        // リネームのテンプレートを取得
        if (JsonConfig is null) { return ""; }
        JsonNode? jsonRename = JsonConfig["rename"];
        if (jsonRename is null) { return ""; }

        String templateFnm = "";
        if (CmndLineType == CmndLineTypeDirSel)
        {
            templateFnm = jsonRename["dir"]?.ToString() ?? "";
        }
        if (CmndLineType == CmndLineTypeFile)
        {
            templateFnm = jsonRename["file"]?.ToString() ?? "";
        }
        return templateFnm;
    }
}
