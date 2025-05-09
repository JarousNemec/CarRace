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
        _btnToggleRun = new System.Windows.Forms.Button();
        splitter1 = new System.Windows.Forms.Splitter();
        _tbSpeedControl = new System.Windows.Forms.TrackBar();
        _lblSpeed = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)_tbSpeedControl).BeginInit();
        SuspendLayout();
        // 
        // mainloop
        // 
        mainloop.Interval = 200;
        mainloop.Tick += mainloop_Tick;
        // 
        // _lblAngle
        // 
        _lblAngle.Location = new System.Drawing.Point(12, 60);
        _lblAngle.Name = "_lblAngle";
        _lblAngle.Size = new System.Drawing.Size(574, 23);
        _lblAngle.TabIndex = 0;
        _lblAngle.Text = "label1";
        // 
        // _btnToggleRun
        // 
        _btnToggleRun.Location = new System.Drawing.Point(12, 12);
        _btnToggleRun.Name = "_btnToggleRun";
        _btnToggleRun.Size = new System.Drawing.Size(75, 23);
        _btnToggleRun.TabIndex = 1;
        _btnToggleRun.Text = "Start";
        _btnToggleRun.UseVisualStyleBackColor = true;
        _btnToggleRun.MouseDown += _btnToggleRun_MouseDown;
        // 
        // splitter1
        // 
        splitter1.Location = new System.Drawing.Point(0, 0);
        splitter1.Name = "splitter1";
        splitter1.Size = new System.Drawing.Size(3, 450);
        splitter1.TabIndex = 2;
        splitter1.TabStop = false;
        // 
        // _tbSpeedControl
        // 
        _tbSpeedControl.Location = new System.Drawing.Point(104, 12);
        _tbSpeedControl.Minimum = 1;
        _tbSpeedControl.Name = "_tbSpeedControl";
        _tbSpeedControl.Size = new System.Drawing.Size(595, 45);
        _tbSpeedControl.TabIndex = 3;
        _tbSpeedControl.Value = 1;
        // 
        // _lblSpeed
        // 
        _lblSpeed.Location = new System.Drawing.Point(705, 16);
        _lblSpeed.Name = "_lblSpeed";
        _lblSpeed.Size = new System.Drawing.Size(83, 23);
        _lblSpeed.TabIndex = 4;
        _lblSpeed.Text = "label1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(_lblSpeed);
        Controls.Add(_tbSpeedControl);
        Controls.Add(splitter1);
        Controls.Add(_btnToggleRun);
        Controls.Add(_lblAngle);
        Text = "Oval";
        Load += Oval_Load;
        Paint += Oval_Paint;
        ((System.ComponentModel.ISupportInitialize)_tbSpeedControl).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label _lblSpeed;

    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.TrackBar _tbSpeedControl;

    private System.Windows.Forms.Button _btnToggleRun;

    private System.Windows.Forms.Label _lblAngle;

    private System.Windows.Forms.Timer mainloop;

    #endregion
}