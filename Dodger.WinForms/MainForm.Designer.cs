namespace Dodger.WinForms
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
      this.scoreValueLabel = new System.Windows.Forms.Label();
      this.scoreLabel = new System.Windows.Forms.Label();
      this.enemySpawnTimer = new System.Windows.Forms.Timer(this.components);
      this.scoreTimer = new System.Windows.Forms.Timer(this.components);
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.healthValueLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // scoreValueLabel
      // 
      this.scoreValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.scoreValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.scoreValueLabel.Location = new System.Drawing.Point(102, 21);
      this.scoreValueLabel.Name = "scoreValueLabel";
      this.scoreValueLabel.Size = new System.Drawing.Size(57, 35);
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
      this.label1.Size = new System.Drawing.Size(67, 27);
      this.label1.TabIndex = 4;
      this.label1.Text = "Health:";
      // 
      // healthValueLabel
      // 
      this.healthValueLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.healthValueLabel.Location = new System.Drawing.Point(102, 52);
      this.healthValueLabel.Name = "healthValueLabel";
      this.healthValueLabel.Size = new System.Drawing.Size(27, 27);
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
      this.Controls.Add(this.scoreLabel);
      this.Controls.Add(this.scoreValueLabel);
      this.Location = new System.Drawing.Point(22, 22);
      this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
      this.MaximumSize = new System.Drawing.Size(1102, 675);
      this.MinimumSize = new System.Drawing.Size(1102, 675);
      this.Name = "MainForm";
      this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Timer enemySpawnTimer;
    private System.Windows.Forms.Timer scoreTimer;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Label scoreLabel;
    private System.Windows.Forms.Label scoreValueLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label healthValueLabel;
  }
}

