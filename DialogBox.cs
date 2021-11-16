using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace codebar
{
  public class DialogBox : Form
  {
    //private IContainer components;
    private Button button1;
    private Button button2;
    private Button button3;
    public TextBox textBox1;
    public Label label1;
    private Button button4;
    private Label label2;

    public DialogBox()
    {
      this.InitializeComponent();
    }

    /*protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }*/

    private void InitializeComponent()
    {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(7, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Печатать все";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button2.Location = new System.Drawing.Point(237, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Следующие штрих-коды уже распечатывались.  ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(335, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Подробнее >>";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 94);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(308, 89);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Продолжить печать?";
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button4.Location = new System.Drawing.Point(105, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Только уникальные";
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 94);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBox";
            this.Text = "Повторная печать";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (this.Height == 226)
      {
        this.Height = (int) sbyte.MaxValue;
        this.button3.Text = "Подробнее >>";
      }
      else
      {
        this.Height = 226;
        this.button3.Text = "<< Скрыть";
      }
    }
  }
}
