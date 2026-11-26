namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormProject
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
            labelProjectType = new Label();
            comboBoxProjectType = new ComboBox();
            labelManager = new Label();
            comboBoxManager = new ComboBox();
            labelDeveloper = new Label();
            comboBoxDeveloper = new ComboBox();
            labelStartDate = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            buttonSave = new Button();
            buttonCancel = new Button();
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
            labelProjectType.AutoSize = true;
            labelProjectType.Location = new Point(12, 56);
            labelProjectType.Name = "labelProjectType";
            labelProjectType.Size = new Size(150, 20);
            labelProjectType.TabIndex = 2;
            labelProjectType.Text = "Тип проекта:";
            comboBoxProjectType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProjectType.FormattingEnabled = true;
            comboBoxProjectType.Location = new Point(190, 53);
            comboBoxProjectType.Name = "comboBoxProjectType";
            comboBoxProjectType.Size = new Size(300, 28);
            comboBoxProjectType.TabIndex = 3;
            labelManager.AutoSize = true;
            labelManager.Location = new Point(12, 98);
            labelManager.Name = "labelManager";
            labelManager.Size = new Size(150, 20);
            labelManager.TabIndex = 4;
            labelManager.Text = "Менеджер:";
            comboBoxManager.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxManager.FormattingEnabled = true;
            comboBoxManager.Location = new Point(190, 95);
            comboBoxManager.Name = "comboBoxManager";
            comboBoxManager.Size = new Size(300, 28);
            comboBoxManager.TabIndex = 5;
            labelDeveloper.AutoSize = true;
            labelDeveloper.Location = new Point(12, 140);
            labelDeveloper.Name = "labelDeveloper";
            labelDeveloper.Size = new Size(150, 20);
            labelDeveloper.TabIndex = 6;
            labelDeveloper.Text = "Разработчик:";
            comboBoxDeveloper.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDeveloper.FormattingEnabled = true;
            comboBoxDeveloper.Location = new Point(190, 137);
            comboBoxDeveloper.Name = "comboBoxDeveloper";
            comboBoxDeveloper.Size = new Size(300, 28);
            comboBoxDeveloper.TabIndex = 7;
            labelStartDate.AutoSize = true;
            labelStartDate.Location = new Point(12, 182);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(150, 20);
            labelStartDate.TabIndex = 8;
            labelStartDate.Text = "Дата начала:";
            dateTimePickerStartDate.Location = new Point(190, 179);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(300, 27);
            dateTimePickerStartDate.TabIndex = 9;
            buttonSave.Location = new Point(190, 226);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(140, 34);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Location = new Point(350, 226);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 34);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 278);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelStartDate);
            Controls.Add(dateTimePickerStartDate);
            Controls.Add(labelDeveloper);
            Controls.Add(comboBoxDeveloper);
            Controls.Add(labelManager);
            Controls.Add(comboBoxManager);
            Controls.Add(labelProjectType);
            Controls.Add(comboBoxProjectType);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormProject";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Проект";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox textBoxName;
        private Label labelProjectType;
        private ComboBox comboBoxProjectType;
        private Label labelManager;
        private ComboBox comboBoxManager;
        private Label labelDeveloper;
        private ComboBox comboBoxDeveloper;
        private Label labelStartDate;
        private DateTimePicker dateTimePickerStartDate;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
