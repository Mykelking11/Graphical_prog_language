namespace Graphical_prog_language
{
    partial class Canvas
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            runBtn = new Button();
            LoadScript = new Button();
            runScriptBtn = new Button();
            saveScriptBtn = new Button();
            ClearBtn = new Button();
            ResetBtn = new Button();
            commandBox = new TextBox();
            richCommandBox = new RichTextBox();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // runBtn
            // 
            runBtn.BackColor = Color.SpringGreen;
            runBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            runBtn.ForeColor = SystemColors.ActiveCaptionText;
            runBtn.Location = new Point(269, 22);
            runBtn.Margin = new Padding(4, 5, 4, 5);
            runBtn.Name = "runBtn";
            runBtn.Size = new Size(87, 38);
            runBtn.TabIndex = 0;
            runBtn.Text = "Run";
            runBtn.UseVisualStyleBackColor = false;
            runBtn.Click += runBtn_Click;
            // 
            // LoadScript
            // 
            LoadScript.BackColor = Color.Lime;
            LoadScript.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LoadScript.ForeColor = SystemColors.ControlLightLight;
            LoadScript.Location = new Point(17, 650);
            LoadScript.Margin = new Padding(4, 5, 4, 5);
            LoadScript.Name = "LoadScript";
            LoadScript.Size = new Size(147, 50);
            LoadScript.TabIndex = 1;
            LoadScript.Text = "Load Script";
            LoadScript.UseVisualStyleBackColor = false;
            LoadScript.Click += LoadScript_Click;
            // 
            // runScriptBtn
            // 
            runScriptBtn.BackColor = SystemColors.HotTrack;
            runScriptBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            runScriptBtn.Location = new Point(173, 650);
            runScriptBtn.Margin = new Padding(4, 5, 4, 5);
            runScriptBtn.Name = "runScriptBtn";
            runScriptBtn.Size = new Size(157, 50);
            runScriptBtn.TabIndex = 2;
            runScriptBtn.Text = "Run Script";
            runScriptBtn.UseVisualStyleBackColor = false;
            runScriptBtn.Click += runScriptBtn_Click;
            // 
            // saveScriptBtn
            // 
            saveScriptBtn.BackColor = Color.DarkOrange;
            saveScriptBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            saveScriptBtn.Location = new Point(17, 728);
            saveScriptBtn.Margin = new Padding(4, 5, 4, 5);
            saveScriptBtn.Name = "saveScriptBtn";
            saveScriptBtn.Size = new Size(147, 50);
            saveScriptBtn.TabIndex = 3;
            saveScriptBtn.Text = "Save Script";
            saveScriptBtn.UseVisualStyleBackColor = false;
            saveScriptBtn.Click += saveScriptBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.BackColor = Color.Red;
            ClearBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ClearBtn.Location = new Point(173, 728);
            ClearBtn.Margin = new Padding(4, 5, 4, 5);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(157, 50);
            ClearBtn.TabIndex = 4;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = false;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = Color.Purple;
            ResetBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ResetBtn.Location = new Point(17, 803);
            ResetBtn.Margin = new Padding(4, 5, 4, 5);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(147, 48);
            ResetBtn.TabIndex = 5;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // commandBox
            // 
            commandBox.Location = new Point(17, 22);
            commandBox.Margin = new Padding(4, 5, 4, 5);
            commandBox.Name = "commandBox";
            commandBox.PlaceholderText = "Enter single line command";
            commandBox.Size = new Size(241, 31);
            commandBox.TabIndex = 6;
            // 
            // richCommandBox
            // 
            richCommandBox.BackColor = SystemColors.ControlLight;
            richCommandBox.Location = new Point(17, 97);
            richCommandBox.Margin = new Padding(4, 5, 4, 5);
            richCommandBox.Name = "richCommandBox";
            richCommandBox.Size = new Size(338, 527);
            richCommandBox.TabIndex = 7;
            richCommandBox.Text = "";
            richCommandBox.TextChanged += richCommandBox_TextChanged;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.ActiveCaption;
            pictureBox.Location = new Point(377, 20);
            pictureBox.Margin = new Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(910, 833);
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseMove += pictureBox_MouseMove_1;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 872);
            Controls.Add(pictureBox);
            Controls.Add(richCommandBox);
            Controls.Add(commandBox);
            Controls.Add(ResetBtn);
            Controls.Add(ClearBtn);
            Controls.Add(saveScriptBtn);
            Controls.Add(runScriptBtn);
            Controls.Add(LoadScript);
            Controls.Add(runBtn);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Canvas";
            Text = "Graphical Programming";
            Load += Canvas_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button runBtn;
        private Button LoadScript;
        private Button runScriptBtn;
        private Button saveScriptBtn;
        private Button ClearBtn;
        private Button ResetBtn;
        private TextBox commandBox;
        private RichTextBox richCommandBox;
        private PictureBox pictureBox;
    }
}
