namespace ProjectWorkTimeAccounting.Forms
{
    partial class FormWorkTimeAccounting
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
            menuStripMain = new MenuStrip();
            ToolStripMenuItemReferences = new ToolStripMenuItem();
            ToolStripMenuItemQualifications = new ToolStripMenuItem();
            ToolStripMenuItemEmployees = new ToolStripMenuItem();
            ToolStripMenuItemProjects = new ToolStripMenuItem();
            ToolStripMenuItemOperations = new ToolStripMenuItem();
            ToolStripMenuItemWorkTimeRecords = new ToolStripMenuItem();
            ToolStripMenuItemSalaryPayments = new ToolStripMenuItem();
            ToolStripMenuItemReports = new ToolStripMenuItem();
            menuStripMain.SuspendLayout();
            SuspendLayout();
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemReferences, ToolStripMenuItemOperations, ToolStripMenuItemReports });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(800, 28);
            menuStripMain.TabIndex = 0;
            ToolStripMenuItemReferences.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemQualifications, ToolStripMenuItemEmployees, ToolStripMenuItemProjects });
            ToolStripMenuItemReferences.Name = "ToolStripMenuItemReferences";
            ToolStripMenuItemReferences.Size = new Size(120, 24);
            ToolStripMenuItemReferences.Text = "Справочники";
            ToolStripMenuItemQualifications.Name = "ToolStripMenuItemQualifications";
            ToolStripMenuItemQualifications.Size = new Size(320, 26);
            ToolStripMenuItemQualifications.Text = "Квалификации";
            ToolStripMenuItemQualifications.Click += ToolStripMenuItemQualifications_Click;
            ToolStripMenuItemEmployees.Name = "ToolStripMenuItemEmployees";
            ToolStripMenuItemEmployees.Size = new Size(320, 26);
            ToolStripMenuItemEmployees.Text = "Специалисты";
            ToolStripMenuItemEmployees.Click += ToolStripMenuItemEmployees_Click;
            ToolStripMenuItemProjects.Name = "ToolStripMenuItemProjects";
            ToolStripMenuItemProjects.Size = new Size(320, 26);
            ToolStripMenuItemProjects.Text = "Проекты";
            ToolStripMenuItemProjects.Click += ToolStripMenuItemProjects_Click;
            ToolStripMenuItemOperations.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemWorkTimeRecords, ToolStripMenuItemSalaryPayments });
            ToolStripMenuItemOperations.Name = "ToolStripMenuItemOperations";
            ToolStripMenuItemOperations.Size = new Size(120, 24);
            ToolStripMenuItemOperations.Text = "Операции";
            ToolStripMenuItemWorkTimeRecords.Name = "ToolStripMenuItemWorkTimeRecords";
            ToolStripMenuItemWorkTimeRecords.Size = new Size(320, 26);
            ToolStripMenuItemWorkTimeRecords.Text = "Учет рабочего времени";
            ToolStripMenuItemWorkTimeRecords.Click += ToolStripMenuItemWorkTimeRecords_Click;
            ToolStripMenuItemSalaryPayments.Name = "ToolStripMenuItemSalaryPayments";
            ToolStripMenuItemSalaryPayments.Size = new Size(320, 26);
            ToolStripMenuItemSalaryPayments.Text = "Начисление заработной платы";
            ToolStripMenuItemSalaryPayments.Click += ToolStripMenuItemSalaryPayments_Click;
            ToolStripMenuItemReports.Name = "ToolStripMenuItemReports";
            ToolStripMenuItemReports.Size = new Size(120, 24);
            ToolStripMenuItemReports.Text = "Отчеты";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormWorkTimeAccounting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учет рабочего времени и зарплаты в IT-компании";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem ToolStripMenuItemReferences;
        private ToolStripMenuItem ToolStripMenuItemQualifications;
        private ToolStripMenuItem ToolStripMenuItemEmployees;
        private ToolStripMenuItem ToolStripMenuItemProjects;
        private ToolStripMenuItem ToolStripMenuItemOperations;
        private ToolStripMenuItem ToolStripMenuItemWorkTimeRecords;
        private ToolStripMenuItem ToolStripMenuItemSalaryPayments;
        private ToolStripMenuItem ToolStripMenuItemReports;
    }
}
