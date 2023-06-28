namespace App;

public partial class FormMain
{
    //------------------------------------------------------------
    // メニューの初期化（ディレクトリ内実行）
    private void InitMenu()
    {
        // イベントの追加
        this.Shown += this.FormShown;

        // コンテキスト メニューの作成
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        this.ContextMenuStrip = contextMenuStrip;
        contextMenuStrip.Closed += this.MenuClose;  // 閉じた時の処理
        ApplyFontSize(contextMenuStrip);    // フォントサイズの設定

        // メニューの追加
        System.EventHandler e = (sender, eargs) => {
            IsMenuSel = true;       // メニュー選択フラグをオンに
            MenuItemExec(sender, eargs);
            Application.Exit();     // アプリケーションの終了
        };
        MenuBuilder.InitMenuNew(contextMenuStrip, JsonConfig, e);   // 新規ファイル メニュー
        MenuBuilder.InitMenuBase(contextMenuStrip, JsonConfig, e);  // 基本メニュー
    }

    //------------------------------------------------------------
    // 表示イベント
    // Shownでコンテキスト メニューを表示できる。Loadでは表示できない。
    private void FormShown(Object? sender, EventArgs e)
    {
        // コンテキスト メニューを表示
        System.Drawing.Point p = System.Windows.Forms.Cursor.Position;  // 現在の座標
        this.ContextMenuStrip?.Show(p);
    }

    //------------------------------------------------------------
    // コンテキスト メニューを閉じた時の処理
    private async void MenuClose(Object? sender, EventArgs e)
    {
        await Task.Delay(1000);
        if (! IsMenuSel) { Application.Exit(); }
    }

    //------------------------------------------------------------
    // フォント サイズの設定
    private void ApplyFontSize(ContextMenuStrip contextMenuStrip)
    {
        int fSize = Convert.ToInt32(JsonConfig?["menu"]?["font_siz"]?.ToString() ?? "12");
        var font = contextMenuStrip.Font;
        font = new System.Drawing.Font(font.FontFamily, fSize);
        contextMenuStrip.Font = font;
    }
}
