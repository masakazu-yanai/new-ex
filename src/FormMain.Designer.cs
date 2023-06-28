namespace App;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //this.ClientSize = new System.Drawing.Size(800, 450);
        //this.Text = "Form1";

        // サイズ0, 0にして画面外に出す
        int h = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        int w = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        this.ClientSize = new System.Drawing.Size(0, 0);
        this.Left = 0;
        this.Top = - h;
        this.StartPosition = FormStartPosition.Manual;

        // アプリ名
        this.Text = "new-ex";
    }

    #endregion
}
