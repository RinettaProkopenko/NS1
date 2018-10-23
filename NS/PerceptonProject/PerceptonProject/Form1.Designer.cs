namespace PerceptonProject
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrowPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.Load = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.drawingField = new System.Windows.Forms.PictureBox();
            this.DrowPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingField)).BeginInit();
            this.SuspendLayout();
            // 
            // DrowPanel
            // 
            this.DrowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DrowPanel.Controls.Add(this.drawingField);
            this.DrowPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DrowPanel.Location = new System.Drawing.Point(0, 0);
            this.DrowPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrowPanel.Name = "DrowPanel";
            this.DrowPanel.Size = new System.Drawing.Size(787, 555);
            this.DrowPanel.TabIndex = 0;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonPanel.Controls.Add(this.Load);
            this.ButtonPanel.Controls.Add(this.Save);
            this.ButtonPanel.Controls.Add(this.Check);
            this.ButtonPanel.Controls.Add(this.Train);
            this.ButtonPanel.Controls.Add(this.Clear);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonPanel.Location = new System.Drawing.Point(793, 0);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(176, 555);
            this.ButtonPanel.TabIndex = 1;
            // 
            // Load
            // 
            this.Load.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Load.Location = new System.Drawing.Point(10, 450);
            this.Load.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(156, 53);
            this.Load.TabIndex = 4;
            this.Load.Text = "Загрузить веса";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(10, 378);
            this.Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(156, 53);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранить веса";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Check.Location = new System.Drawing.Point(10, 180);
            this.Check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(156, 53);
            this.Check.TabIndex = 2;
            this.Check.Text = "Проверить";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Train
            // 
            this.Train.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Train.Location = new System.Drawing.Point(10, 102);
            this.Train.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(156, 53);
            this.Train.TabIndex = 1;
            this.Train.Text = "Обучить";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.Location = new System.Drawing.Point(10, 25);
            this.Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(156, 53);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // drawingField
            // 
            this.drawingField.BackColor = System.Drawing.Color.White;
            this.drawingField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingField.Location = new System.Drawing.Point(0, 0);
            this.drawingField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawingField.Name = "drawingField";
            this.drawingField.Size = new System.Drawing.Size(787, 555);
            this.drawingField.TabIndex = 5;
            this.drawingField.TabStop = false;
            this.drawingField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingField_MouseDown);
            this.drawingField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingField_MouseMove);
            this.drawingField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingField_MouseUp);
            this.drawingField.Resize += new System.EventHandler(this.MainForm_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 555);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.DrowPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "First lab";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.DrowPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrowPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.PictureBox drawingField;
    }
}

