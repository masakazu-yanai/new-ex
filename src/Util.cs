using System.Runtime.InteropServices; //DllImport属性を使用するために必要

namespace App;

public partial class Util
{
    //------------------------------------------------------------
    [DllImport("kernel32.dll")]
    public static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();

    //------------------------------------------------------------
    // コンソール出力
    public static bool Console(string msg) {
        if (! AttachConsole(System.UInt32.MaxValue)) {
            return false;
        }

        // stdoutのストリームを取得
        System.IO.Stream stream = System.Console.OpenStandardOutput();
        System.IO.StreamWriter stdout = new System.IO.StreamWriter(stream);

        // 指定された文字列を出力
        stdout.WriteLine(msg);
        stdout.Flush();

        FreeConsole();
        return true;
    }

    //------------------------------------------------------------
    // メッセージを出力して終了
    public static void MesExit(String mes)
    {
        MessageBox.Show(mes);
        Application.Exit();     // アプリケーションの終了
    }

    //------------------------------------------------------------
    // 待機してアプリケーションを終了
    // FormMain()の中で直接終了しようとすると終了できなかったので起動プロセスを避けて終了する
    public static async void WaitExit()
    {
        await Task.Delay(1000);
        Application.Exit();     // アプリケーションの終了
    }
}
