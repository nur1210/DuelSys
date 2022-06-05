namespace DuelSys_inc
{
	partial class AddResult
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
            this.cbxPlayerOne = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxPlayerTwo = new MaterialSkin.Controls.MaterialComboBox();
            this.tbxResultPlayerOne = new MaterialSkin.Controls.MaterialTextBox();
            this.tbxResultPlayerTwo = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSubmit = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // cbxPlayerOne
            // 
            this.cbxPlayerOne.AutoResize = false;
            this.cbxPlayerOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbxPlayerOne.Depth = 0;
            this.cbxPlayerOne.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxPlayerOne.DropDownHeight = 174;
            this.cbxPlayerOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlayerOne.DropDownWidth = 121;
            this.cbxPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxPlayerOne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxPlayerOne.FormattingEnabled = true;
            this.cbxPlayerOne.Hint = "Player One";
            this.cbxPlayerOne.IntegralHeight = false;
            this.cbxPlayerOne.ItemHeight = 43;
            this.cbxPlayerOne.Location = new System.Drawing.Point(64, 98);
            this.cbxPlayerOne.MaxDropDownItems = 4;
            this.cbxPlayerOne.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxPlayerOne.Name = "cbxPlayerOne";
            this.cbxPlayerOne.Size = new System.Drawing.Size(151, 49);
            this.cbxPlayerOne.StartIndex = 0;
            this.cbxPlayerOne.TabIndex = 0;
            this.cbxPlayerOne.SelectedIndexChanged += new System.EventHandler(this.cbxPlayerOne_SelectedIndexChanged);
            // 
            // cbxPlayerTwo
            // 
            this.cbxPlayerTwo.AutoResize = false;
            this.cbxPlayerTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbxPlayerTwo.Depth = 0;
            this.cbxPlayerTwo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxPlayerTwo.DropDownHeight = 174;
            this.cbxPlayerTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlayerTwo.DropDownWidth = 121;
            this.cbxPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxPlayerTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxPlayerTwo.FormattingEnabled = true;
            this.cbxPlayerTwo.Hint = "Player Two";
            this.cbxPlayerTwo.IntegralHeight = false;
            this.cbxPlayerTwo.ItemHeight = 43;
            this.cbxPlayerTwo.Location = new System.Drawing.Point(64, 207);
            this.cbxPlayerTwo.MaxDropDownItems = 4;
            this.cbxPlayerTwo.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxPlayerTwo.Name = "cbxPlayerTwo";
            this.cbxPlayerTwo.Size = new System.Drawing.Size(151, 49);
            this.cbxPlayerTwo.StartIndex = 0;
            this.cbxPlayerTwo.TabIndex = 1;
            // 
            // tbxResultPlayerOne
            // 
            this.tbxResultPlayerOne.AnimateReadOnly = false;
            this.tbxResultPlayerOne.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxResultPlayerOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxResultPlayerOne.Depth = 0;
            this.tbxResultPlayerOne.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxResultPlayerOne.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxResultPlayerOne.Hint = "Player one result";
            this.tbxResultPlayerOne.LeadingIcon = null;
            this.tbxResultPlayerOne.Location = new System.Drawing.Point(300, 99);
            this.tbxResultPlayerOne.MaxLength = 50;
            this.tbxResultPlayerOne.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxResultPlayerOne.Multiline = false;
            this.tbxResultPlayerOne.Name = "tbxResultPlayerOne";
            this.tbxResultPlayerOne.Size = new System.Drawing.Size(148, 50);
            this.tbxResultPlayerOne.TabIndex = 2;
            this.tbxResultPlayerOne.Text = "";
            this.tbxResultPlayerOne.TrailingIcon = null;
            // 
            // tbxResultPlayerTwo
            // 
            this.tbxResultPlayerTwo.AnimateReadOnly = false;
            this.tbxResultPlayerTwo.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxResultPlayerTwo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxResultPlayerTwo.Depth = 0;
            this.tbxResultPlayerTwo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxResultPlayerTwo.Hint = "Player two result";
            this.tbxResultPlayerTwo.LeadingIcon = null;
            this.tbxResultPlayerTwo.Location = new System.Drawing.Point(300, 206);
            this.tbxResultPlayerTwo.MaxLength = 50;
            this.tbxResultPlayerTwo.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxResultPlayerTwo.Multiline = false;
            this.tbxResultPlayerTwo.Name = "tbxResultPlayerTwo";
            this.tbxResultPlayerTwo.Size = new System.Drawing.Size(148, 50);
            this.tbxResultPlayerTwo.TabIndex = 3;
            this.tbxResultPlayerTwo.Text = "";
            this.tbxResultPlayerTwo.TrailingIcon = null;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSubmit.Depth = 0;
            this.btnSubmit.HighEmphasis = true;
            this.btnSubmit.Icon = null;
            this.btnSubmit.Location = new System.Drawing.Point(176, 354);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSubmit.Size = new System.Drawing.Size(140, 36);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit results";
            this.btnSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSubmit.UseAccentColor = false;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // AddResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbxResultPlayerTwo);
            this.Controls.Add(this.tbxResultPlayerOne);
            this.Controls.Add(this.cbxPlayerTwo);
            this.Controls.Add(this.cbxPlayerOne);
            this.Name = "AddResult";
            this.Padding = new System.Windows.Forms.Padding(1, 31, 1, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddResult";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialComboBox cbxPlayerOne;
		private MaterialSkin.Controls.MaterialComboBox cbxPlayerTwo;
		private MaterialSkin.Controls.MaterialTextBox tbxResultPlayerOne;
		private MaterialSkin.Controls.MaterialTextBox tbxResultPlayerTwo;
		private MaterialSkin.Controls.MaterialButton btnSubmit;
    }
}