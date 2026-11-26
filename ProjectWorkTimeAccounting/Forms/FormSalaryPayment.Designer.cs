namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormSalaryPayment
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
            labelPaymentMonth = new Label();
            dateTimePickerPaymentMonth = new DateTimePicker();
            labelHoursWorked = new Label();
            numericUpDownHoursWorked = new NumericUpDown();
            labelAmount = new Label();
            numericUpDownAmount = new NumericUpDown();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHoursWorked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
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
            labelPaymentMonth.AutoSize = true;
            labelPaymentMonth.Location = new Point(12, 57);
            labelPaymentMonth.Name = "labelPaymentMonth";
            labelPaymentMonth.Size = new Size(150, 20);
            labelPaymentMonth.TabIndex = 2;
            labelPaymentMonth.Text = "Расчетный месяц:";
            dateTimePickerPaymentMonth.CustomFormat = "MMMM yyyy";
            dateTimePickerPaymentMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerPaymentMonth.ShowUpDown = true;
            dateTimePickerPaymentMonth.Location = new Point(190, 54);
            dateTimePickerPaymentMonth.Name = "dateTimePickerPaymentMonth";
            dateTimePickerPaymentMonth.Size = new Size(300, 27);
            dateTimePickerPaymentMonth.TabIndex = 3;
            labelHoursWorked.AutoSize = true;
            labelHoursWorked.Location = new Point(12, 98);
            labelHoursWorked.Name = "labelHoursWorked";
            labelHoursWorked.Size = new Size(150, 20);
            labelHoursWorked.TabIndex = 4;
            labelHoursWorked.Text = "Отработано часов:";
            numericUpDownHoursWorked.DecimalPlaces = 2;
            numericUpDownHoursWorked.Location = new Point(190, 95);
            numericUpDownHoursWorked.Maximum = new decimal(new int[] { 744, 0, 0, 0 });
            numericUpDownHoursWorked.Name = "numericUpDownHoursWorked";
            numericUpDownHoursWorked.Size = new Size(300, 27);
            numericUpDownHoursWorked.TabIndex = 5;
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(12, 139);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(150, 20);
            labelAmount.TabIndex = 6;
            labelAmount.Text = "Сумма:";
            numericUpDownAmount.DecimalPlaces = 2;
            numericUpDownAmount.Location = new Point(190, 136);
            numericUpDownAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(300, 27);
            numericUpDownAmount.TabIndex = 7;
            buttonSave.Location = new Point(190, 183);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(140, 34);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Location = new Point(350, 183);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 34);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 235);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelAmount);
            Controls.Add(numericUpDownAmount);
            Controls.Add(labelHoursWorked);
            Controls.Add(numericUpDownHoursWorked);
            Controls.Add(labelPaymentMonth);
            Controls.Add(dateTimePickerPaymentMonth);
            Controls.Add(labelEmployee);
            Controls.Add(comboBoxEmployee);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSalaryPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Начисление заработной платы";
            ((System.ComponentModel.ISupportInitialize)numericUpDownHoursWorked).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmployee;
        private ComboBox comboBoxEmployee;
        private Label labelPaymentMonth;
        private DateTimePicker dateTimePickerPaymentMonth;
        private Label labelHoursWorked;
        private NumericUpDown numericUpDownHoursWorked;
        private Label labelAmount;
        private NumericUpDown numericUpDownAmount;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
