using System.Text.Json.Nodes;

namespace App;

public partial class FormMain : Form
{
    //------------------------------------------------------------
    // コンストラクター
    public FormMain()
    {
        InitializeComponent();
        // MessageBox.Show("デバッグ");

        // 設定の読み込み
        JsonConfigUser = Util.ReadJson(Util.GetExeDir() + PathConfigUser);
        JsonConfig = Util.ReadJson(Util.GetExeDir() + GetPathConfig());

        // コマンドライン引数取得
        String[] cmds = System.Environment.GetCommandLineArgs();
        if (cmds.Length >= 3){
            CmndLineType = cmds[1];
            CmndLinePath = cmds[2];
            //MessageBox.Show(CmndLineType + "\n" + CmndLinePath);

            // コマンド種類による分岐
            if (CmndLineType == CmndLineTypeDirIn)
            {
                InitMenu();     // メニューの初期化（ディレクトリ内実行）
            }
            if (CmndLineType == CmndLineTypeDirSel || CmndLineType == CmndLineTypeFile)
            {
                Rename();       // リネーム実行
                Util.WaitExit();    // 待機してアプリケーションを終了
            }
        }
    }

    //------------------------------------------------------------
    // PathConfigの取得
    private String GetPathConfig()
    {
        String lang = JsonConfigUser?["language"]?.ToString() ?? "default";
        if (! PathConfig.ContainsKey(lang)) { lang = "default"; }
        String path = PathConfig[lang];
        return path;
    }
}
