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
      this.scoreValueLabel = new System.Windows.Forms.Label();
      this.scoreLabel = new System.Windows.Forms.Label();
      this.enemySpawnTimer = new System.Windows.Forms.Timer(this.components);
      this.playerPictureBox = new System.Windows.Forms.PictureBox();
      this.scoreTimer = new System.Windows.Forms.Timer(this.components);
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.healthValueLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize) (this.playerPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // scoreValueLabel
      // 
      this.scoreValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.scoreValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.scoreValueLabel.Location = new System.Drawing.Point(102, 21);
      this.scoreValueLabel.Name = "scoreValueLabel";
      this.scoreValueLabel.Size = new System.Drawing.Size(27, 35);
      this.scoreValueLabel.TabIndex = 1;
      this.scoreValueLabel.Text = "0";
      // 
      // scoreLabel
      // 
      this.scoreLabel.Location = new System.Drawing.Point(28, 21);
      this.scoreLabel.Name = "scoreLabel";
      this.scoreLabel.Size = new System.Drawing.Size(67, 31);
      this.scoreLabel.TabIndex = 2;
      this.scoreLabel.Text = "Score:";
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
      this.playerPictureBox.Size = new System.Drawing.Size(28, 29);
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
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(28, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 26);
      this.label1.TabIndex = 4;
      this.label1.Text = "Health:";
      // 
      // healthValueLabel
      // 
      this.healthValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.healthValueLabel.Location = new System.Drawing.Point(101, 52);
      this.healthValueLabel.Name = "healthValueLabel";
      this.healthValueLabel.Size = new System.Drawing.Size(27, 26);
      this.healthValueLabel.TabIndex = 5;
      this.healthValueLabel.Text = "5";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(1080, 619);
      this.Controls.Add(this.healthValueLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.playerPictureBox);
      this.Controls.Add(this.scoreLabel);
      this.Controls.Add(this.scoreValueLabel);
      this.Location = new System.Drawing.Point(22, 22);
      this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
      this.MaximumSize = new System.Drawing.Size(1102, 675);
      this.MinimumSize = new System.Drawing.Size(1102, 675);
      this.Name = "MainForm";
      ((System.ComponentModel.ISupportInitialize) (this.playerPictureBox)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Timer enemySpawnTimer;
    private System.Windows.Forms.Timer scoreTimer;
    private System.Windows.Forms.PictureBox playerPictureBox;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Label scoreLabel;
    private System.Windows.Forms.Label scoreValueLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label healthValueLabel;
  }
}

