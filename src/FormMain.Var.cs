using System.Text.Json.Nodes;

namespace App;

public partial class FormMain
{
    // メニュー
    private bool IsMenuSel = false; // メニュー選択フラグ（メニューを閉じた時の排他処理用）

    // コマンドライン種類
    private String CmndLineTypeDirIn  = "dirIn";
    private String CmndLineTypeDirSel = "dirSel";
    private String CmndLineTypeFile   = "file";

    // コマンドライン引数分解
    private String CmndLineType = "";
    private String CmndLinePath = "";

    // 設定JSON
    private String PathConfigUser = @"..\data\config.user.json";
    private Dictionary<String, String> PathConfig = new Dictionary<String, String>(){
        {"default", @"..\data\config.json"},
        {"ja", @"..\data\config.json"},
        {"en", @"..\data\config_en.json"}
    };
    private JsonNode? JsonConfig;
    private JsonNode? JsonConfigUser;
}
