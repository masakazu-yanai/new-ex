using System.Text.RegularExpressions;

namespace App;

public partial class FileNameCore
{
    //------------------------------------------------------------
    // ファイル名置換
    private static String RepFileName(String templateFnm, int i)
    {
        DateTime dt = DateTime.Now;
        String rYYYY = dt.Year.ToString();
        String rYY = rYYYY.Substring(rYYYY.Length - 2);
        String rM = dt.Month.ToString();
        String rMM = dt.Month.ToString("00");
        String rD = dt.Day.ToString();
        String rDD = dt.Day.ToString("00");
        String rh = dt.Hour.ToString();
        String rhh = dt.Hour.ToString("00");
        String rm = dt.Minute.ToString();
        String rmm = dt.Minute.ToString("00");
        String rs = dt.Second.ToString();
        String rss = dt.Second.ToString("00");
        String rchar = i == 1 ? "" : NumToChar(i);
        String rChar = NumToChar(i);
        String rcount = i == 1 ? "" : "" + i;
        String rCount = "" + i;

        String res = templateFnm;
        res = Regex.Replace(res, "%YYYY%", rYYYY);
        res = Regex.Replace(res, "%YY%", rYY);
        res = Regex.Replace(res, "%M%", rM);
        res = Regex.Replace(res, "%MM%", rMM);
        res = Regex.Replace(res, "%D%", rD);
        res = Regex.Replace(res, "%DD%", rDD);
        res = Regex.Replace(res, "%h%", rh);
        res = Regex.Replace(res, "%hh%", rhh);
        res = Regex.Replace(res, "%m%", rm);
        res = Regex.Replace(res, "%mm%", rmm);
        res = Regex.Replace(res, "%s%", rs);
        res = Regex.Replace(res, "%ss%", rss);
        res = Regex.Replace(res, "%#a%", rchar);
        res = Regex.Replace(res, @"%#([^%]*?)a([^%]*?)%", m => {
            if (rchar == "") { return ""; }
            String pre = m.Groups[1].Value;
            String pst = m.Groups[2].Value;
            return pre + rchar + pst;
        });

        res = Regex.Replace(res, "%#A%", rChar);

        res = Regex.Replace(res, "%#n%", rcount);
        res = Regex.Replace(res, @"%#([^%]*?)n([^%]*?)%", m => {
            if (rcount == "") { return ""; }
            String pre = m.Groups[1].Value;
            String pst = m.Groups[2].Value;
            return pre + rcount + pst;
        });

        res = Regex.Replace(res, "%#N%", rcount);
        res = Regex.Replace(res, @"%#N(\d+)%", m => {
            int n = Convert.ToInt32(m.Groups[1].Value);
            return i.ToString(new String('0', n));
        });

        return res;
    }

    //------------------------------------------------------------
    // 数値を文字列に変換
    private static String NumToChar(int i)
    {
        if (i <= 26) {
            return "abcdefghijklmnopqrstuvwxyz".Substring(i - 1, 1);
        }
        return "z" + NumToChar(i - 26 + 1);
    }
}
