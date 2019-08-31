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
      this.aEnemySpawnTimer = new System.Windows.Forms.Timer(this.components);
      this.aPlayerImage = new System.Windows.Forms.PictureBox();
      this.aScoreTimer = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize) (this.aPlayerImage)).BeginInit();
      this.SuspendLayout();
      // 
      // aScore
      // 
      this.aScore.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.aScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.aScore.Location = new System.Drawing.Point(102, 23);
      this.aScore.Name = "aScore";
      this.aScore.Size = new System.Drawing.Size(27, 35);
      this.aScore.TabIndex = 1;
      this.aScore.Text = "0";
      // 
      // aScoreLabel
      // 
      this.aScoreLabel.Location = new System.Drawing.Point(28, 23);
      this.aScoreLabel.Name = "aScoreLabel";
      this.aScoreLabel.Size = new System.Drawing.Size(67, 31);
      this.aScoreLabel.TabIndex = 2;
      this.aScoreLabel.Text = "Score:";
      // 
      // aEnemySpawnTimer
      // 
      this.aEnemySpawnTimer.Enabled = true;
      // 
      // aPlayerImage
      // 
      this.aPlayerImage.Image = ((System.Drawing.Image) (resources.GetObject("aPlayerImage.Image")));
      this.aPlayerImage.Location = new System.Drawing.Point(472, 500);
      this.aPlayerImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.aPlayerImage.Name = "aPlayerImage";
      this.aPlayerImage.Size = new System.Drawing.Size(68, 79);
      this.aPlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.aPlayerImage.TabIndex = 3;
      this.aPlayerImage.TabStop = false;
      // 
      // aScoreTimer
      // 
      this.aScoreTimer.Enabled = true;
      this.aScoreTimer.Interval = 1000;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(1080, 619);
      this.Controls.Add(this.aPlayerImage);
      this.Controls.Add(this.aScoreLabel);
      this.Controls.Add(this.aScore);
      this.Location = new System.Drawing.Point(22, 22);
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.Name = "MainForm";
      ((System.ComponentModel.ISupportInitialize) (this.aPlayerImage)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.PictureBox aPlayerImage;
    private System.Windows.Forms.Label aScore;
    private System.Windows.Forms.Label aScoreLabel;
    private System.Windows.Forms.Timer aScoreTimer;
    private System.Windows.Forms.Timer aEnemySpawnTimer;
  }
}

