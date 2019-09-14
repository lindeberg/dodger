namespace Dodger
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources =
        new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.aScore = new System.Windows.Forms.Label();
      this.aScoreLabel = new System.Windows.Forms.Label();
      this.enemySpawnTimer = new System.Windows.Forms.Timer(this.components);
      this.playerPictureBox = new System.Windows.Forms.PictureBox();
      this.scoreTimer = new System.Windows.Forms.Timer(this.components);
      this.timer = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize) (this.playerPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // aScore
      // 
      this.aScore.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.aScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.aScore.Location = new System.Drawing.Point(102, 22);
      this.aScore.Name = "aScore";
      this.aScore.Size = new System.Drawing.Size(27, 35);
      this.aScore.TabIndex = 1;
      this.aScore.Text = "0";
      // 
      // aScoreLabel
      // 
      this.aScoreLabel.Location = new System.Drawing.Point(28, 22);
      this.aScoreLabel.Name = "aScoreLabel";
      this.aScoreLabel.Size = new System.Drawing.Size(67, 31);
      this.aScoreLabel.TabIndex = 2;
      this.aScoreLabel.Text = "Score:";
      // 
      // enemySpawnTimer
      // 
      this.enemySpawnTimer.Enabled = true;
      // 
      // playerPictureBox
      // 
      this.playerPictureBox.Image = ((System.Drawing.Image) (resources.GetObject("playerPictureBox.Image")));
      this.playerPictureBox.Location = new System.Drawing.Point(342, 412);
      this.playerPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.playerPictureBox.Name = "playerPictureBox";
      this.playerPictureBox.Size = new System.Drawing.Size(28, 28);
      this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.playerPictureBox.TabIndex = 3;
      this.playerPictureBox.TabStop = false;
      // 
      // scoreTimer
      // 
      this.scoreTimer.Enabled = true;
      this.scoreTimer.Interval = 1000;
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 1;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(1080, 619);
      this.Controls.Add(this.playerPictureBox);
      this.Controls.Add(this.aScoreLabel);
      this.Controls.Add(this.aScore);
      this.Location = new System.Drawing.Point(22, 22);
      this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
      this.Name = "MainForm";
      ((System.ComponentModel.ISupportInitialize) (this.playerPictureBox)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label aScore;
    private System.Windows.Forms.Label aScoreLabel;
    private System.Windows.Forms.Timer enemySpawnTimer;
    private System.Windows.Forms.Timer scoreTimer;
    private System.Windows.Forms.PictureBox playerPictureBox;
    private System.Windows.Forms.Timer timer;
  }
}

