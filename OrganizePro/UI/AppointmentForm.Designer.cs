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
            DescriptionInput = new TextBox();
            UrlInput = new TextBox();
            DescriptionLabel = new Label();
            UrlLabel = new Label();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(615, 405);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(75, 23);
            SaveBtn.TabIndex = 26;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveClick;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(706, 405);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 27;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += Cancel;
            // 
            // EndLabel
            // 
            EndLabel.AutoSize = true;
            EndLabel.Location = new Point(386, 217);
            EndLabel.Name = "EndLabel";
            EndLabel.Size = new Size(56, 15);
            EndLabel.TabIndex = 28;
            EndLabel.Text = "End Time";
            // 
            // StartLabel
            // 
            StartLabel.AutoSize = true;
            StartLabel.Location = new Point(99, 217);
            StartLabel.Name = "StartLabel";
            StartLabel.Size = new Size(60, 15);
            StartLabel.TabIndex = 27;
            StartLabel.Text = "Start Time";
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(159, 103);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(29, 15);
            TitleLabel.TabIndex = 26;
            TitleLabel.Text = "Title";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(429, 103);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(31, 15);
            TypeLabel.TabIndex = 25;
            TypeLabel.Text = "Type";
            // 
            // LocationInput
            // 
            LocationInput.Location = new Point(195, 140);
            LocationInput.Name = "LocationInput";
            LocationInput.Size = new Size(157, 23);
            LocationInput.TabIndex = 19;
            // 
            // TypeInput
            // 
            TypeInput.Location = new Point(466, 100);
            TypeInput.Name = "TypeInput";
            TypeInput.Size = new Size(157, 23);
            TypeInput.TabIndex = 16;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(134, 140);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(53, 15);
            LocationLabel.TabIndex = 17;
            LocationLabel.Text = "Location";
            // 
            // TitleInput
            // 
            TitleInput.Location = new Point(196, 100);
            TitleInput.Name = "TitleInput";
            TitleInput.Size = new Size(157, 23);
            TitleInput.TabIndex = 14;
            // 
            // ContactInput
            // 
            ContactInput.Location = new Point(466, 140);
            ContactInput.Name = "ContactInput";
            ContactInput.Size = new Size(157, 23);
            ContactInput.TabIndex = 20;
            // 
            // ContactLabel
            // 
            ContactLabel.AutoSize = true;
            ContactLabel.Location = new Point(409, 142);
            ContactLabel.Name = "ContactLabel";
            ContactLabel.Size = new Size(49, 15);
            ContactLabel.TabIndex = 29;
            ContactLabel.Text = "Contact";
            // 
            // CustomerDropdown
            // 
            CustomerDropdown.FormattingEnabled = true;
            CustomerDropdown.Location = new Point(365, 269);
            CustomerDropdown.Name = "CustomerDropdown";
            CustomerDropdown.Size = new Size(121, 23);
            CustomerDropdown.TabIndex = 25;
            // 
            // SelectCustomerLabel
            // 
            SelectCustomerLabel.AutoSize = true;
            SelectCustomerLabel.Location = new Point(266, 272);
            SelectCustomerLabel.Name = "SelectCustomerLabel";
            SelectCustomerLabel.Size = new Size(93, 15);
            SelectCustomerLabel.TabIndex = 34;
            SelectCustomerLabel.Text = "Select Customer";
            // 
            // StartInput
            // 
            StartInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            StartInput.Format = DateTimePickerFormat.Custom;
            StartInput.Location = new Point(169, 217);
            StartInput.Name = "StartInput";
            StartInput.Size = new Size(200, 23);
            StartInput.TabIndex = 23;
            // 
            // EndInput
            // 
            EndInput.CustomFormat = "MM/dd/yyyy hh:mm tt";
            EndInput.Format = DateTimePickerFormat.Custom;
            EndInput.Location = new Point(452, 217);
            EndInput.Name = "EndInput";
            EndInput.Size = new Size(200, 23);
            EndInput.TabIndex = 24;
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(196, 177);
            DescriptionInput.Margin = new Padding(2);
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.Size = new Size(157, 23);
            DescriptionInput.TabIndex = 21;
            // 
            // UrlInput
            // 
            UrlInput.Location = new Point(466, 179);
            UrlInput.Margin = new Padding(2);
            UrlInput.Name = "UrlInput";
            UrlInput.Size = new Size(157, 23);
            UrlInput.TabIndex = 22;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(118, 177);
            DescriptionLabel.Margin = new Padding(2, 0, 2, 0);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(67, 15);
            DescriptionLabel.TabIndex = 39;
            DescriptionLabel.Text = "Description";
            // 
            // UrlLabel
            // 
            UrlLabel.AutoSize = true;
            UrlLabel.Location = new Point(436, 181);
            UrlLabel.Margin = new Padding(2, 0, 2, 0);
            UrlLabel.Name = "UrlLabel";
            UrlLabel.Size = new Size(28, 15);
            UrlLabel.TabIndex = 40;
            UrlLabel.Text = "URL";
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UrlLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(UrlInput);
            Controls.Add(DescriptionInput);
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
        private TextBox DescriptionInput;
        private TextBox UrlInput;
        private Label DescriptionLabel;
        private Label UrlLabel;
    }
}