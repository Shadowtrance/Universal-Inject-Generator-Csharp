using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace Universal_Inject_Generator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.buttonAdv2 = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(223, 61);
            this.buttonAdv1.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Outset;
            this.buttonAdv1.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAdv1.FlatAppearance.BorderSize = 2;
            this.buttonAdv1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.buttonAdv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(12, 2);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(223, 61);
            this.buttonAdv1.TabIndex = 5;
            this.buttonAdv1.Text = "GO!";
            this.buttonAdv1.Click += new System.EventHandler(this.buttonAdv1_Click);
            // 
            // textBoxExt1
            // 
            this.textBoxExt1.BackColor = System.Drawing.Color.White;
            this.textBoxExt1.BeforeTouchSize = new System.Drawing.Size(323, 139);
            this.textBoxExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExt1.CornerRadius = 10;
            this.textBoxExt1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxExt1.Location = new System.Drawing.Point(12, 69);
            this.textBoxExt1.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textBoxExt1.MinimumSize = new System.Drawing.Size(24, 20);
            this.textBoxExt1.Multiline = true;
            this.textBoxExt1.Name = "textBoxExt1";
            this.textBoxExt1.Size = new System.Drawing.Size(323, 139);
            this.textBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.textBoxExt1.TabIndex = 6;
            this.textBoxExt1.WordWrap = false;
            this.textBoxExt1.TextChanged += new System.EventHandler(this.textBoxExt1_TextChanged);
            // 
            // buttonAdv2
            // 
            this.buttonAdv2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAdv2.BeforeTouchSize = new System.Drawing.Size(94, 61);
            this.buttonAdv2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Outset;
            this.buttonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAdv2.FlatAppearance.BorderSize = 2;
            this.buttonAdv2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.buttonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv2.IsBackStageButton = false;
            this.buttonAdv2.Location = new System.Drawing.Point(241, 2);
            this.buttonAdv2.Name = "buttonAdv2";
            this.buttonAdv2.Size = new System.Drawing.Size(94, 61);
            this.buttonAdv2.TabIndex = 7;
            this.buttonAdv2.Text = "Exit";
            this.buttonAdv2.Click += new System.EventHandler(this.buttonAdv2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.BorderThickness = 5;
            this.CaptionBarColor = System.Drawing.Color.SteelBlue;
            this.CaptionButtonColor = System.Drawing.Color.DeepSkyBlue;
            this.CaptionButtonHoverColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(349, 215);
            this.Controls.Add(this.buttonAdv2);
            this.Controls.Add(this.textBoxExt1);
            this.Controls.Add(this.buttonAdv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.SteelBlue;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universal Inject Generator";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ButtonAdv buttonAdv1;
        public TextBoxExt textBoxExt1;
        public ButtonAdv buttonAdv2;
    }
}

