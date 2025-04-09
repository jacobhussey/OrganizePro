namespace OrganizePro.UI
{
    partial class AppointmentForm
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
            SaveBtn = new Button();
            CancelBtn = new Button();
            EndLabel = new Label();
            StartLabel = new Label();
            TitleLabel = new Label();
            TypeLabel = new Label();
            LocationInput = new TextBox();
            TypeInput = new TextBox();
            LocationLabel = new Label();
            TitleInput = new TextBox();
            ContactInput = new TextBox();
            ContactLabel = new Label();
            CustomerDropdown = new ComboBox();
            SelectCustomerLabel = new Label();
            StartInput = new DateTimePicker();
            EndInput = new DateTimePicker();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(879, 675);
            SaveBtn.Margin = new Padding(4, 5, 4, 5);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(107, 38);
            SaveBtn.TabIndex = 22;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveClick;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(1009, 675);
            CancelBtn.Margin = new Padding(4, 5, 4, 5);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(107, 38);
            CancelBtn.TabIndex = 23;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += Cancel;
            // 
            // EndLabel
            // 
            EndLabel.AutoSize = true;
            EndLabel.Location = new Point(558, 307);
            EndLabel.Margin = new Padding(4, 0, 4, 0);
            EndLabel.Name = "EndLabel";
            EndLabel.Size = new Size(85, 25);
            EndLabel.TabIndex = 28;
            EndLabel.Text = "End Time";
            // 
            // StartLabel
            // 
            StartLabel.AutoSize = true;
            StartLabel.Location = new Point(149, 307);
            StartLabel.Margin = new Padding(4, 0, 4, 0);
            StartLabel.Name = "StartLabel";
            StartLabel.Size = new Size(91, 25);
            StartLabel.TabIndex = 27;
            StartLabel.Text = "Start Time";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(227, 171);
            TitleLabel.Margin = new Padding(4, 0, 4, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(44, 25);
            TitleLabel.TabIndex = 26;
            TitleLabel.Text = "Title";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(613, 171);
            TypeLabel.Margin = new Padding(4, 0, 4, 0);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(49, 25);
            TypeLabel.TabIndex = 25;
            TypeLabel.Text = "Type";
            // 
            // LocationInput
            // 
            LocationInput.Location = new Point(279, 233);
            LocationInput.Margin = new Padding(4, 5, 4, 5);
            LocationInput.Name = "LocationInput";
            LocationInput.Size = new Size(223, 31);
            LocationInput.TabIndex = 19;
            // 
            // TypeInput
            // 
            TypeInput.Location = new Point(666, 166);
            TypeInput.Margin = new Padding(4, 5, 4, 5);
            TypeInput.Name = "TypeInput";
            TypeInput.Size = new Size(223, 31);
            TypeInput.TabIndex = 16;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(192, 233);
            LocationLabel.Margin = new Padding(4, 0, 4, 0);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(79, 25);
            LocationLabel.TabIndex = 17;
            LocationLabel.Text = "Location";
            // 
            // TitleInput
            // 
            TitleInput.Location = new Point(280, 166);
            TitleInput.Margin = new Padding(4, 5, 4, 5);
            TitleInput.Name = "TitleInput";
            TitleInput.Size = new Size(223, 31);
            TitleInput.TabIndex = 14;
            // 
            // ContactInput
            // 
            ContactInput.Location = new Point(665, 233);
            ContactInput.Margin = new Padding(4, 5, 4, 5);
            ContactInput.Name = "ContactInput";
            ContactInput.Size = new Size(223, 31);
            ContactInput.TabIndex = 20;
            // 
            // ContactLabel
            // 
            ContactLabel.AutoSize = true;
            ContactLabel.Location = new Point(584, 236);
            ContactLabel.Margin = new Padding(4, 0, 4, 0);
            ContactLabel.Name = "ContactLabel";
            ContactLabel.Size = new Size(73, 25);
            ContactLabel.TabIndex = 29;
            ContactLabel.Text = "Contact";
            // 
            // CustomerDropdown
            // 
            CustomerDropdown.FormattingEnabled = true;
            CustomerDropdown.Location = new Point(441, 392);
            CustomerDropdown.Margin = new Padding(4, 5, 4, 5);
            CustomerDropdown.Name = "CustomerDropdown";
            CustomerDropdown.Size = new Size(171, 33);
            CustomerDropdown.TabIndex = 33;
            // 
            // SelectCustomerLabel
            // 
            SelectCustomerLabel.AutoSize = true;
            SelectCustomerLabel.Location = new Point(300, 397);
            SelectCustomerLabel.Margin = new Padding(4, 0, 4, 0);
            SelectCustomerLabel.Name = "SelectCustomerLabel";
            SelectCustomerLabel.Size = new Size(140, 25);
            SelectCustomerLabel.TabIndex = 34;
            SelectCustomerLabel.Text = "Select Customer";
            // 
            // StartInput
            // 
            StartInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            StartInput.Format = DateTimePickerFormat.Custom;
            StartInput.Location = new Point(249, 307);
            StartInput.Margin = new Padding(4, 5, 4, 5);
            StartInput.Name = "StartInput";
            StartInput.Size = new Size(284, 31);
            StartInput.TabIndex = 35;
            // 
            // EndInput
            // 
            EndInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            EndInput.Format = DateTimePickerFormat.Custom;
            EndInput.Location = new Point(652, 307);
            EndInput.Margin = new Padding(4, 5, 4, 5);
            EndInput.Name = "EndInput";
            EndInput.Size = new Size(284, 31);
            EndInput.TabIndex = 36;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(EndInput);
            Controls.Add(StartInput);
            Controls.Add(SelectCustomerLabel);
            Controls.Add(CustomerDropdown);
            Controls.Add(ContactInput);
            Controls.Add(ContactLabel);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(EndLabel);
            Controls.Add(StartLabel);
            Controls.Add(TitleLabel);
            Controls.Add(TypeLabel);
            Controls.Add(LocationInput);
            Controls.Add(TypeInput);
            Controls.Add(LocationLabel);
            Controls.Add(TitleInput);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AppointmentForm";
            Text = "AppointmentForm";
            Load += AppointmentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveBtn;
        private Button CancelBtn;
        private Label EndLabel;
        private Label StartLabel;
        private Label TitleLabel;
        private Label TypeLabel;
        private TextBox LocationInput;
        private TextBox TypeInput;
        private Label LocationLabel;
        private TextBox TitleInput;
        private TextBox ContactInput;
        private Label ContactLabel;
        private ComboBox CustomerDropdown;
        private Label SelectCustomerLabel;
        private DateTimePicker StartInput;
        private DateTimePicker EndInput;
    }
}