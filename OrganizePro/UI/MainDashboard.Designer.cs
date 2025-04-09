namespace OrganizePro
{
    partial class MainDashboard
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
            tabControl1 = new TabControl();
            CustomerManager = new TabPage();
            DeleteCustomerBtn = new Button();
            UpdateCustomerBtn = new Button();
            AddCustomerBtn = new Button();
            CustomerDgv = new DataGridView();
            AppointmentManager = new TabPage();
            DeleteAppointmentBtn = new Button();
            UpdateAppointmentBtn = new Button();
            AddAppointmentBtn = new Button();
            AppointmentDgv = new DataGridView();
            Calendar = new TabPage();
            CalendarAppointmentDgv = new DataGridView();
            MonthCalendar = new MonthCalendar();
            ReportGenerator = new TabPage();
            YearInput = new TextBox();
            EnterYearLabel = new Label();
            ReportDgv = new DataGridView();
            label1 = new Label();
            GenerateReportBtn = new Button();
            ReportsDropdown = new ComboBox();
            ExitBtn = new Button();
            tabControl1.SuspendLayout();
            CustomerManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CustomerDgv).BeginInit();
            AppointmentManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AppointmentDgv).BeginInit();
            Calendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CalendarAppointmentDgv).BeginInit();
            ReportGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReportDgv).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(CustomerManager);
            tabControl1.Controls.Add(AppointmentManager);
            tabControl1.Controls.Add(Calendar);
            tabControl1.Controls.Add(ReportGenerator);
            tabControl1.Location = new Point(17, 20);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1401, 668);
            tabControl1.TabIndex = 0;
            // 
            // CustomerManager
            // 
            CustomerManager.Controls.Add(DeleteCustomerBtn);
            CustomerManager.Controls.Add(UpdateCustomerBtn);
            CustomerManager.Controls.Add(AddCustomerBtn);
            CustomerManager.Controls.Add(CustomerDgv);
            CustomerManager.Location = new Point(4, 34);
            CustomerManager.Margin = new Padding(4, 5, 4, 5);
            CustomerManager.Name = "CustomerManager";
            CustomerManager.Padding = new Padding(4, 5, 4, 5);
            CustomerManager.Size = new Size(1393, 630);
            CustomerManager.TabIndex = 0;
            CustomerManager.Text = "Customer Management";
            CustomerManager.UseVisualStyleBackColor = true;
            // 
            // DeleteCustomerBtn
            // 
            DeleteCustomerBtn.Location = new Point(1104, 533);
            DeleteCustomerBtn.Margin = new Padding(4, 5, 4, 5);
            DeleteCustomerBtn.Name = "DeleteCustomerBtn";
            DeleteCustomerBtn.Size = new Size(117, 38);
            DeleteCustomerBtn.TabIndex = 3;
            DeleteCustomerBtn.Text = "Delete";
            DeleteCustomerBtn.UseVisualStyleBackColor = true;
            DeleteCustomerBtn.Click += DeleteCustomer;
            // 
            // UpdateCustomerBtn
            // 
            UpdateCustomerBtn.Location = new Point(279, 533);
            UpdateCustomerBtn.Margin = new Padding(4, 5, 4, 5);
            UpdateCustomerBtn.Name = "UpdateCustomerBtn";
            UpdateCustomerBtn.Size = new Size(117, 38);
            UpdateCustomerBtn.TabIndex = 2;
            UpdateCustomerBtn.Text = "Update";
            UpdateCustomerBtn.UseVisualStyleBackColor = true;
            UpdateCustomerBtn.Click += ShowCustomerForm;
            // 
            // AddCustomerBtn
            // 
            AddCustomerBtn.Location = new Point(163, 533);
            AddCustomerBtn.Margin = new Padding(4, 5, 4, 5);
            AddCustomerBtn.Name = "AddCustomerBtn";
            AddCustomerBtn.Size = new Size(117, 38);
            AddCustomerBtn.TabIndex = 1;
            AddCustomerBtn.Text = "Add";
            AddCustomerBtn.UseVisualStyleBackColor = true;
            AddCustomerBtn.Click += ShowCustomerForm;
            // 
            // CustomerDgv
            // 
            CustomerDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            CustomerDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDgv.Location = new Point(164, 80);
            CustomerDgv.Margin = new Padding(4, 5, 4, 5);
            CustomerDgv.Name = "CustomerDgv";
            CustomerDgv.RowHeadersWidth = 62;
            CustomerDgv.Size = new Size(1057, 423);
            CustomerDgv.TabIndex = 0;
            CustomerDgv.CellClick += SetActiveCustomer;
            // 
            // AppointmentManager
            // 
            AppointmentManager.Controls.Add(DeleteAppointmentBtn);
            AppointmentManager.Controls.Add(UpdateAppointmentBtn);
            AppointmentManager.Controls.Add(AddAppointmentBtn);
            AppointmentManager.Controls.Add(AppointmentDgv);
            AppointmentManager.Location = new Point(4, 34);
            AppointmentManager.Margin = new Padding(4, 5, 4, 5);
            AppointmentManager.Name = "AppointmentManager";
            AppointmentManager.Padding = new Padding(4, 5, 4, 5);
            AppointmentManager.Size = new Size(1393, 630);
            AppointmentManager.TabIndex = 1;
            AppointmentManager.Text = "Appointment Management";
            AppointmentManager.UseVisualStyleBackColor = true;
            // 
            // DeleteAppointmentBtn
            // 
            DeleteAppointmentBtn.Location = new Point(1109, 457);
            DeleteAppointmentBtn.Margin = new Padding(4, 5, 4, 5);
            DeleteAppointmentBtn.Name = "DeleteAppointmentBtn";
            DeleteAppointmentBtn.Size = new Size(117, 38);
            DeleteAppointmentBtn.TabIndex = 7;
            DeleteAppointmentBtn.Text = "Delete";
            DeleteAppointmentBtn.UseVisualStyleBackColor = true;
            DeleteAppointmentBtn.Click += DeleteAppointment;
            // 
            // UpdateAppointmentBtn
            // 
            UpdateAppointmentBtn.Location = new Point(283, 457);
            UpdateAppointmentBtn.Margin = new Padding(4, 5, 4, 5);
            UpdateAppointmentBtn.Name = "UpdateAppointmentBtn";
            UpdateAppointmentBtn.Size = new Size(117, 38);
            UpdateAppointmentBtn.TabIndex = 6;
            UpdateAppointmentBtn.Text = "Update";
            UpdateAppointmentBtn.UseVisualStyleBackColor = true;
            UpdateAppointmentBtn.Click += ShowAppointmentForm;
            // 
            // AddAppointmentBtn
            // 
            AddAppointmentBtn.Location = new Point(167, 457);
            AddAppointmentBtn.Margin = new Padding(4, 5, 4, 5);
            AddAppointmentBtn.Name = "AddAppointmentBtn";
            AddAppointmentBtn.Size = new Size(117, 38);
            AddAppointmentBtn.TabIndex = 5;
            AddAppointmentBtn.Text = "Add";
            AddAppointmentBtn.UseVisualStyleBackColor = true;
            AddAppointmentBtn.Click += ShowAppointmentForm;
            // 
            // AppointmentDgv
            // 
            AppointmentDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            AppointmentDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AppointmentDgv.Location = new Point(169, 50);
            AppointmentDgv.Margin = new Padding(4, 5, 4, 5);
            AppointmentDgv.Name = "AppointmentDgv";
            AppointmentDgv.RowHeadersWidth = 62;
            AppointmentDgv.Size = new Size(1057, 377);
            AppointmentDgv.TabIndex = 4;
            AppointmentDgv.CellClick += SetActiveAppointment;
            // 
            // Calendar
            // 
            Calendar.Controls.Add(CalendarAppointmentDgv);
            Calendar.Controls.Add(MonthCalendar);
            Calendar.Location = new Point(4, 34);
            Calendar.Margin = new Padding(4, 5, 4, 5);
            Calendar.Name = "Calendar";
            Calendar.Padding = new Padding(4, 5, 4, 5);
            Calendar.Size = new Size(1393, 630);
            Calendar.TabIndex = 2;
            Calendar.Text = "Calendar";
            Calendar.UseVisualStyleBackColor = true;
            // 
            // CalendarAppointmentDgv
            // 
            CalendarAppointmentDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CalendarAppointmentDgv.Location = new Point(9, 295);
            CalendarAppointmentDgv.Margin = new Padding(4, 5, 4, 5);
            CalendarAppointmentDgv.Name = "CalendarAppointmentDgv";
            CalendarAppointmentDgv.RowHeadersWidth = 62;
            CalendarAppointmentDgv.Size = new Size(1373, 317);
            CalendarAppointmentDgv.TabIndex = 2;
            // 
            // MonthCalendar
            // 
            MonthCalendar.Location = new Point(480, 15);
            MonthCalendar.Margin = new Padding(13, 15, 13, 15);
            MonthCalendar.Name = "MonthCalendar";
            MonthCalendar.TabIndex = 1;
            MonthCalendar.DateSelected += SelectCalendarDate;
            // 
            // ReportGenerator
            // 
            ReportGenerator.Controls.Add(YearInput);
            ReportGenerator.Controls.Add(EnterYearLabel);
            ReportGenerator.Controls.Add(ReportDgv);
            ReportGenerator.Controls.Add(label1);
            ReportGenerator.Controls.Add(GenerateReportBtn);
            ReportGenerator.Controls.Add(ReportsDropdown);
            ReportGenerator.Location = new Point(4, 34);
            ReportGenerator.Margin = new Padding(4, 5, 4, 5);
            ReportGenerator.Name = "ReportGenerator";
            ReportGenerator.Padding = new Padding(4, 5, 4, 5);
            ReportGenerator.Size = new Size(1393, 630);
            ReportGenerator.TabIndex = 3;
            ReportGenerator.Text = "Reports";
            ReportGenerator.UseVisualStyleBackColor = true;
            // 
            // YearInput
            // 
            YearInput.Location = new Point(714, 147);
            YearInput.Name = "YearInput";
            YearInput.Size = new Size(150, 31);
            YearInput.TabIndex = 6;
            YearInput.TextChanged += YearInput_TextChanged;
            // 
            // EnterYearLabel
            // 
            EnterYearLabel.AutoSize = true;
            EnterYearLabel.Location = new Point(739, 92);
            EnterYearLabel.Name = "EnterYearLabel";
            EnterYearLabel.Size = new Size(89, 25);
            EnterYearLabel.TabIndex = 5;
            EnterYearLabel.Text = "Enter Year";
            // 
            // ReportDgv
            // 
            ReportDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportDgv.Location = new Point(209, 290);
            ReportDgv.Name = "ReportDgv";
            ReportDgv.RowHeadersWidth = 62;
            ReportDgv.Size = new Size(950, 310);
            ReportDgv.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(473, 92);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 2;
            label1.Text = "Select Report";
            // 
            // GenerateReportBtn
            // 
            GenerateReportBtn.Location = new Point(393, 223);
            GenerateReportBtn.Name = "GenerateReportBtn";
            GenerateReportBtn.Size = new Size(176, 33);
            GenerateReportBtn.TabIndex = 1;
            GenerateReportBtn.Text = "Generate Report";
            GenerateReportBtn.UseVisualStyleBackColor = true;
            GenerateReportBtn.Click += GenerateReport;
            // 
            // ReportsDropdown
            // 
            ReportsDropdown.FormattingEnabled = true;
            ReportsDropdown.Items.AddRange(new object[] { "Appointment Types by Month", "User Schedules", "Customer Appointment Summary" });
            ReportsDropdown.Location = new Point(393, 147);
            ReportsDropdown.Name = "ReportsDropdown";
            ReportsDropdown.Size = new Size(273, 33);
            ReportsDropdown.TabIndex = 0;
            ReportsDropdown.SelectedIndexChanged += SelectReportType;
            // 
            // ExitBtn
            // 
            ExitBtn.Location = new Point(1306, 698);
            ExitBtn.Margin = new Padding(4, 5, 4, 5);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(107, 38);
            ExitBtn.TabIndex = 4;
            ExitBtn.Text = "Exit";
            ExitBtn.UseVisualStyleBackColor = true;
            ExitBtn.Click += ExitApplication;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 750);
            Controls.Add(ExitBtn);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainDashboard";
            Text = "Main Dashboard";
            Load += MainDashboard_Load;
            tabControl1.ResumeLayout(false);
            CustomerManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CustomerDgv).EndInit();
            AppointmentManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AppointmentDgv).EndInit();
            Calendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CalendarAppointmentDgv).EndInit();
            ReportGenerator.ResumeLayout(false);
            ReportGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ReportDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage CustomerManager;
        private TabPage AppointmentManager;
        private TabPage Calendar;
        private TabPage ReportGenerator;
        private Button DeleteCustomerBtn;
        private Button UpdateCustomerBtn;
        private Button AddCustomerBtn;
        private DataGridView CustomerDgv;
        private Button ExitBtn;
        private Button DeleteAppointmentBtn;
        private Button UpdateAppointmentBtn;
        private Button AddAppointmentBtn;
        private DataGridView AppointmentDgv;
        private DataGridView CalendarAppointmentDgv;
        private MonthCalendar MonthCalendar;
        private ComboBox ReportsDropdown;
        private Label label1;
        private Button GenerateReportBtn;
        private DataGridView ReportDgv;
        private Label EnterYearLabel;
        private TextBox YearInput;
    }
}