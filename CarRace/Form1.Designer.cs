namespace CarRace;

sealed partial class Form1
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        mainloop = new System.Windows.Forms.Timer(components);
        _lblAngle = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // mainloop
        // 
        mainloop.Interval = 200;
        mainloop.Tick += mainloop_Tick;
        // 
        // _lblAngle
        // 
        _lblAngle.Location = new System.Drawing.Point(5, 5);
        _lblAngle.Name = "_lblAngle";
        _lblAngle.Size = new System.Drawing.Size(574, 23);
        _lblAngle.TabIndex = 0;
        _lblAngle.Text = "label1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(_lblAngle);
        Text = "Oval";
        Load += Oval_Load;
        Paint += Oval_Paint;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label _lblAngle;

    private System.Windows.Forms.Timer mainloop;

    #endregion
}