﻿namespace DotNETGalaxyView
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlanetName = new System.Windows.Forms.Label();
            this.tbxPlanetName = new System.Windows.Forms.TextBox();
            this.btnAddPlanet = new System.Windows.Forms.Button();
            this.lblPlanetId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Planet Info";
            // 
            // lblPlanetName
            // 
            this.lblPlanetName.AutoSize = true;
            this.lblPlanetName.Location = new System.Drawing.Point(47, 57);
            this.lblPlanetName.Name = "lblPlanetName";
            this.lblPlanetName.Size = new System.Drawing.Size(99, 13);
            this.lblPlanetName.TabIndex = 1;
            this.lblPlanetName.Text = "New Planet Name: ";
            // 
            // tbxPlanetName
            // 
            this.tbxPlanetName.Location = new System.Drawing.Point(152, 54);
            this.tbxPlanetName.Name = "tbxPlanetName";
            this.tbxPlanetName.Size = new System.Drawing.Size(100, 20);
            this.tbxPlanetName.TabIndex = 2;
            // 
            // btnAddPlanet
            // 
            this.btnAddPlanet.Location = new System.Drawing.Point(152, 95);
            this.btnAddPlanet.Name = "btnAddPlanet";
            this.btnAddPlanet.Size = new System.Drawing.Size(100, 23);
            this.btnAddPlanet.TabIndex = 3;
            this.btnAddPlanet.Text = "Add New Planet";
            this.btnAddPlanet.UseVisualStyleBackColor = true;
            this.btnAddPlanet.Click += new System.EventHandler(this.btnAddPlanet_Click);
            // 
            // lblPlanetId
            // 
            this.lblPlanetId.AutoSize = true;
            this.lblPlanetId.Location = new System.Drawing.Point(28, 25);
            this.lblPlanetId.Name = "lblPlanetId";
            this.lblPlanetId.Size = new System.Drawing.Size(0, 13);
            this.lblPlanetId.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 165);
            this.Controls.Add(this.lblPlanetId);
            this.Controls.Add(this.btnAddPlanet);
            this.Controls.Add(this.tbxPlanetName);
            this.Controls.Add(this.lblPlanetName);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Add New Planet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlanetName;
        private System.Windows.Forms.TextBox tbxPlanetName;
        private System.Windows.Forms.Button btnAddPlanet;
        private System.Windows.Forms.Label lblPlanetId;
    }
}