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
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Location = new Point(20, 24);
            labelFullName.Margin = new Padding(5, 0, 5, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(72, 32);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "ФИО:";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(309, 19);
            textBoxFullName.Margin = new Padding(5, 5, 5, 5);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(485, 39);
            textBoxFullName.TabIndex = 1;
            textBoxFullName.TextChanged += textBoxFullName_TextChanged;
            // 
            // labelPost
            // 
            labelPost.AutoSize = true;
            labelPost.Location = new Point(20, 90);
            labelPost.Margin = new Padding(5, 0, 5, 0);
            labelPost.Name = "labelPost";
            labelPost.Size = new Size(142, 32);
            labelPost.TabIndex = 2;
            labelPost.Text = "Должность:";
            // 
            // comboBoxPost
            // 
            comboBoxPost.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPost.FormattingEnabled = true;
            comboBoxPost.Location = new Point(309, 85);
            comboBoxPost.Margin = new Padding(5, 5, 5, 5);
            comboBoxPost.Name = "comboBoxPost";
            comboBoxPost.Size = new Size(485, 40);
            comboBoxPost.TabIndex = 3;
            // 
            // labelQualification
            // 
            labelQualification.AutoSize = true;
            labelQualification.Location = new Point(20, 157);
            labelQualification.Margin = new Padding(5, 0, 5, 0);
            labelQualification.Name = "labelQualification";
            labelQualification.Size = new Size(179, 32);
            labelQualification.TabIndex = 4;
            labelQualification.Text = "Квалификация:";
            // 
            // comboBoxQualification
            // 
            comboBoxQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQualification.FormattingEnabled = true;
            comboBoxQualification.Location = new Point(309, 152);
            comboBoxQualification.Margin = new Padding(5, 5, 5, 5);
            comboBoxQualification.Name = "comboBoxQualification";
            comboBoxQualification.Size = new Size(485, 40);
            comboBoxQualification.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(309, 229);
            buttonSave.Margin = new Padding(5, 5, 5, 5);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(228, 54);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(569, 229);
            buttonCancel.Margin = new Padding(5, 5, 5, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(228, 54);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 312);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelQualification);
            Controls.Add(comboBoxQualification);
            Controls.Add(labelPost);
            Controls.Add(comboBoxPost);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 5, 5, 5);
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
