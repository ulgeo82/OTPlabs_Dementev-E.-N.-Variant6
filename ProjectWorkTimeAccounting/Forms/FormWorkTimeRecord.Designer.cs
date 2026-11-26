namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormWorkTimeRecord
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
            labelEmployee = new Label();
            comboBoxEmployee = new ComboBox();
            labelWorkDate = new Label();
            dateTimePickerWorkDate = new DateTimePicker();
            labelWorkKinds = new Label();
            checkedListBoxWorkKinds = new CheckedListBox();
            labelProjects = new Label();
            dataGridViewProjects = new DataGridView();
            ColumnProject = new DataGridViewComboBoxColumn();
            ColumnHours = new DataGridViewTextBoxColumn();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).BeginInit();
            SuspendLayout();
            labelEmployee.AutoSize = true;
            labelEmployee.Location = new Point(12, 15);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new Size(150, 20);
            labelEmployee.TabIndex = 0;
            labelEmployee.Text = "Специалист:";
            comboBoxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployee.FormattingEnabled = true;
            comboBoxEmployee.Location = new Point(190, 12);
            comboBoxEmployee.Name = "comboBoxEmployee";
            comboBoxEmployee.Size = new Size(300, 28);
            comboBoxEmployee.TabIndex = 1;
            labelWorkDate.AutoSize = true;
            labelWorkDate.Location = new Point(12, 57);
            labelWorkDate.Name = "labelWorkDate";
            labelWorkDate.Size = new Size(150, 20);
            labelWorkDate.TabIndex = 2;
            labelWorkDate.Text = "Дата:";
            dateTimePickerWorkDate.Location = new Point(190, 54);
            dateTimePickerWorkDate.Name = "dateTimePickerWorkDate";
            dateTimePickerWorkDate.Size = new Size(300, 27);
            dateTimePickerWorkDate.TabIndex = 3;
            labelWorkKinds.AutoSize = true;
            labelWorkKinds.Location = new Point(12, 98);
            labelWorkKinds.Name = "labelWorkKinds";
            labelWorkKinds.Size = new Size(150, 20);
            labelWorkKinds.TabIndex = 4;
            labelWorkKinds.Text = "Виды работ:";
            checkedListBoxWorkKinds.CheckOnClick = true;
            checkedListBoxWorkKinds.FormattingEnabled = true;
            checkedListBoxWorkKinds.Location = new Point(190, 95);
            checkedListBoxWorkKinds.Name = "checkedListBoxWorkKinds";
            checkedListBoxWorkKinds.Size = new Size(300, 114);
            checkedListBoxWorkKinds.TabIndex = 5;
            labelProjects.AutoSize = true;
            labelProjects.Location = new Point(12, 226);
            labelProjects.Name = "labelProjects";
            labelProjects.Size = new Size(150, 20);
            labelProjects.TabIndex = 6;
            labelProjects.Text = "Проекты и часы:";
            dataGridViewProjects.AllowUserToResizeColumns = false;
            dataGridViewProjects.AllowUserToResizeRows = false;
            dataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProjects.Columns.AddRange(new DataGridViewColumn[] { ColumnProject, ColumnHours });
            dataGridViewProjects.Location = new Point(190, 223);
            dataGridViewProjects.MultiSelect = false;
            dataGridViewProjects.Name = "dataGridViewProjects";
            dataGridViewProjects.RowHeadersVisible = false;
            dataGridViewProjects.RowHeadersWidth = 51;
            dataGridViewProjects.Size = new Size(300, 190);
            dataGridViewProjects.TabIndex = 7;
            ColumnProject.HeaderText = "Проект";
            ColumnProject.MinimumWidth = 6;
            ColumnProject.Name = "ColumnProject";
            ColumnHours.HeaderText = "Часы";
            ColumnHours.MinimumWidth = 6;
            ColumnHours.Name = "ColumnHours";
            buttonSave.Location = new Point(190, 433);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(140, 34);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Location = new Point(350, 433);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 34);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 485);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelProjects);
            Controls.Add(dataGridViewProjects);
            Controls.Add(labelWorkKinds);
            Controls.Add(checkedListBoxWorkKinds);
            Controls.Add(labelWorkDate);
            Controls.Add(dateTimePickerWorkDate);
            Controls.Add(labelEmployee);
            Controls.Add(comboBoxEmployee);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormWorkTimeRecord";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Запись учета рабочего времени";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmployee;
        private ComboBox comboBoxEmployee;
        private Label labelWorkDate;
        private DateTimePicker dateTimePickerWorkDate;
        private Label labelWorkKinds;
        private CheckedListBox checkedListBoxWorkKinds;
        private Label labelProjects;
        private DataGridView dataGridViewProjects;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridViewComboBoxColumn ColumnProject;
        private DataGridViewTextBoxColumn ColumnHours;
    }
}
