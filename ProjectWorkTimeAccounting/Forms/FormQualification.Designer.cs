namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormQualification
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            labelName = new Label();
            textBoxName = new TextBox();
            labelHourlyRate = new Label();
            numericUpDownHourlyRate = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHourlyRate).BeginInit();
            SuspendLayout();
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(150, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            textBoxName.Location = new Point(190, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(300, 27);
            textBoxName.TabIndex = 1;
            labelHourlyRate.AutoSize = true;
            labelHourlyRate.Location = new Point(12, 56);
            labelHourlyRate.Name = "labelHourlyRate";
            labelHourlyRate.Size = new Size(150, 20);
            labelHourlyRate.TabIndex = 2;
            labelHourlyRate.Text = "Почасовая ставка:";
            numericUpDownHourlyRate.DecimalPlaces = 2;
            numericUpDownHourlyRate.Location = new Point(190, 53);
            numericUpDownHourlyRate.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownHourlyRate.Name = "numericUpDownHourlyRate";
            numericUpDownHourlyRate.Size = new Size(300, 27);
            numericUpDownHourlyRate.TabIndex = 3;
            buttonSave.Location = new Point(190, 100);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(140, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Location = new Point(350, 100);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 34);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 152);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelHourlyRate);
            Controls.Add(numericUpDownHourlyRate);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormQualification";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Квалификация";
            ((System.ComponentModel.ISupportInitialize)numericUpDownHourlyRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox textBoxName;
        private Label labelHourlyRate;
        private NumericUpDown numericUpDownHourlyRate;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
