namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormEmployee
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
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            labelPost = new Label();
            comboBoxPost = new ComboBox();
            labelQualification = new Label();
            comboBoxQualification = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(12, 15);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(150, 20);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "ФИО:";
            textBoxFullName.Location = new Point(190, 12);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(300, 27);
            textBoxFullName.TabIndex = 1;
            labelPost.AutoSize = true;
            labelPost.Location = new Point(12, 56);
            labelPost.Name = "labelPost";
            labelPost.Size = new Size(150, 20);
            labelPost.TabIndex = 2;
            labelPost.Text = "Должность:";
            comboBoxPost.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPost.FormattingEnabled = true;
            comboBoxPost.Location = new Point(190, 53);
            comboBoxPost.Name = "comboBoxPost";
            comboBoxPost.Size = new Size(300, 28);
            comboBoxPost.TabIndex = 3;
            labelQualification.AutoSize = true;
            labelQualification.Location = new Point(12, 98);
            labelQualification.Name = "labelQualification";
            labelQualification.Size = new Size(150, 20);
            labelQualification.TabIndex = 4;
            labelQualification.Text = "Квалификация:";
            comboBoxQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQualification.FormattingEnabled = true;
            comboBoxQualification.Location = new Point(190, 95);
            comboBoxQualification.Name = "comboBoxQualification";
            comboBoxQualification.Size = new Size(300, 28);
            comboBoxQualification.TabIndex = 5;
            buttonSave.Location = new Point(190, 143);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(140, 34);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Location = new Point(350, 143);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 34);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 195);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelQualification);
            Controls.Add(comboBoxQualification);
            Controls.Add(labelPost);
            Controls.Add(comboBoxPost);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Специалист";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelPost;
        private ComboBox comboBoxPost;
        private Label labelQualification;
        private ComboBox comboBoxQualification;
        private Button buttonSave;
        private Button buttonCancel;
    }
}
