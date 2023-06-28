using System.Text.RegularExpressions;

namespace App;

public partial class FileNameCore
{
    //------------------------------------------------------------
    // 新規ファイル名の作成（%bs%、%ext% つき）
    public static String GenNewFileName(String dir, String templateFnm, String pathOld)
    {
        String bnm = Path.GetFileNameWithoutExtension(pathOld);
        String ext = Path.GetExtension(pathOld);
        String fnmNew = GenNewFileName(dir, templateFnm);
        fnmNew = Regex.Replace(fnmNew, "%bs%", bnm);
        fnmNew = Regex.Replace(fnmNew, "%ext%", ext);
        return fnmNew;
    }

    //------------------------------------------------------------
    // 新規ファイル名の作成
    public static String GenNewFileName(String dir, String templateFnm)
    {
        //Util.Console(dir + "\n" + templateFnm);

        // ファイル名、フォルダ名一覧
        IEnumerable<string> subFolders = Directory.EnumerateDirectories(dir);
        IEnumerable<string> files = Directory.EnumerateFiles(dir);
        String[] nameArray = new String[subFolders.Count() + files.Count()];
        int nameCount = 0;

        foreach (string subFolder in subFolders)
        {
            nameArray[nameCount++] = Path.GetFileName(subFolder);
        }
        foreach (var file in files)
        {
            nameArray[nameCount++] = Path.GetFileName(file);
        }

        //Util.Console(nameArray.Length + " " + nameArray[0]);

        // 繰り返し確認
        String fnm = "";
        for (int i = 1; i <= 1024; i ++)
        {
            fnm = RepFileName(templateFnm, i);

            // 部分一致の確認
            //Util.Console(i + " 部分一致の確認 " + fnm);
            Match match = Regex.Match(fnm, @"\{(.+?)\}");
            if (match.Success == true)
            {
                String textMatch = match.Groups[1].Value;
                //Util.Console("textMatch: " + textMatch);
                if (nameArray.Any(item => item.Contains(textMatch)))
                {
                    //Util.Console("continue");
                    fnm = "";
                    continue;
                }

                fnm = Regex.Replace(fnm, @"\{(.+?)\}", "$1");
            }

            // 存在確認
            //Util.Console(i + " 存在確認 " + fnm);
            if (nameArray.Any(item => item.Contains(fnm)))
            {
                //Util.Console("continue");
                fnm = "";
                continue;
            }

            // かぶる名前がなければfor文を抜ける
            break;
        }

        // 生成失敗の確認
        if (fnm == "")
        {
            MessageBox.Show("新しい名前の生成に失敗しました。");
            Application.Exit();     // アプリケーションの終了
        }

        // 成功時
        return fnm;
    }
}
