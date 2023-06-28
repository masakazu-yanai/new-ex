namespace App;

public partial class Util
{
    //------------------------------------------------------------
    // ファイル/フォルダの時間を今に設定
    public static void SetFileTimeNow(String path)
    {
        bool isDirectory = File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        if (isDirectory) {
            // フォルダ
            Directory.SetCreationTime(path, DateTime.Now);      // 作成日時の設定
            Directory.SetLastWriteTime(path, DateTime.Now);     // 更新日時の設定
            Directory.SetLastAccessTime(path, DateTime.Now);    // アクセス日時の設定
        }
        else
        {
            // ファイル
            File.SetCreationTime(path, DateTime.Now);      // 作成日時の設定
            File.SetLastWriteTime(path, DateTime.Now);     // 更新日時の設定
            File.SetLastAccessTime(path, DateTime.Now);    // アクセス日時の設定
        }
    }
}
