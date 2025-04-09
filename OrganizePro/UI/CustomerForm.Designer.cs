namespace OrganizePro.UI
{
    partial class CustomerForm
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
            NameInput = new TextBox();
            Address2Input = new TextBox();
            AddressInput = new TextBox();
            PhoneLabel = new Label();
            Address2Label = new Label();
            NameLabel = new Label();
            PostalCodeInput = new TextBox();
            CityInput = new TextBox();
            PhoneInput = new TextBox();
            CityLabel = new Label();
            AddressLabel = new Label();
            PostalCodeLabel = new Label();
            CountryInput = new TextBox();
            CountryLabel = new Label();
            CancelBtn = new Button();
            SaveBtn = new Button();
            SuspendLayout();
            // 
            // NameInput
            // 
            NameInput.Location = new Point(419, 113);
            NameInput.Margin = new Padding(4, 5, 4, 5);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(223, 31);
            NameInput.TabIndex = 0;
            // 
            // Address2Input
            // 
            Address2Input.Location = new Point(419, 283);
            Address2Input.Margin = new Padding(4, 5, 4, 5);
            Address2Input.Name = "Address2Input";
            Address2Input.Size = new Size(223, 31);
            Address2Input.TabIndex = 2;
            // 
            // AddressInput
            // 
            AddressInput.Location = new Point(419, 198);
            AddressInput.Margin = new Padding(4, 5, 4, 5);
            AddressInput.Name = "AddressInput";
            AddressInput.Size = new Size(223, 31);
            AddressInput.TabIndex = 1;
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Location = new Point(284, 613);
            PhoneLabel.Margin = new Padding(4, 0, 4, 0);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(132, 25);
            PhoneLabel.TabIndex = 3;
            PhoneLabel.Text = "Phone Number";
            // 
            // Address2Label
            // 
            Address2Label.AutoSize = true;
            Address2Label.Location = new Point(284, 288);
            Address2Label.Margin = new Padding(4, 0, 4, 0);
            Address2Label.Name = "Address2Label";
            Address2Label.Size = new Size(128, 25);
            Address2Label.TabIndex = 4;
            Address2Label.Text = "Address Line 2";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(354, 118);
            NameLabel.Margin = new Padding(4, 0, 4, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(59, 25);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Name";
            // 
            // PostalCodeInput
            // 
            PostalCodeInput.Location = new Point(419, 453);
            PostalCodeInput.Margin = new Padding(4, 5, 4, 5);
            PostalCodeInput.Name = "PostalCodeInput";
            PostalCodeInput.Size = new Size(223, 31);
            PostalCodeInput.TabIndex = 4;
            // 
            // CityInput
            // 
            CityInput.Location = new Point(419, 367);
            CityInput.Margin = new Padding(4, 5, 4, 5);
            CityInput.Name = "CityInput";
            CityInput.Size = new Size(223, 31);
            CityInput.TabIndex = 3;
            // 
            // PhoneInput
            // 
            PhoneInput.Location = new Point(419, 608);
            PhoneInput.Margin = new Padding(4, 5, 4, 5);
            PhoneInput.Name = "PhoneInput";
            PhoneInput.Size = new Size(223, 31);
            PhoneInput.TabIndex = 6;
            PhoneInput.KeyPress += FormatPhoneInput;
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Location = new Point(340, 372);
            CityLabel.Margin = new Padding(4, 0, 4, 0);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(42, 25);
            CityLabel.TabIndex = 9;
            CityLabel.Text = "City";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(333, 203);
            AddressLabel.Margin = new Padding(4, 0, 4, 0);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(77, 25);
            AddressLabel.TabIndex = 10;
            AddressLabel.Text = "Address";
            // 
            // PostalCodeLabel
            // 
            PostalCodeLabel.AutoSize = true;
            PostalCodeLabel.Location = new Point(303, 458);
            PostalCodeLabel.Margin = new Padding(4, 0, 4, 0);
            PostalCodeLabel.Name = "PostalCodeLabel";
            PostalCodeLabel.Size = new Size(106, 25);
            PostalCodeLabel.TabIndex = 11;
            PostalCodeLabel.Text = "Postal Code";
            // 
            // CountryInput
            // 
            CountryInput.Location = new Point(419, 535);
            CountryInput.Margin = new Padding(4, 5, 4, 5);
            CountryInput.Name = "CountryInput";
            CountryInput.Size = new Size(223, 31);
            CountryInput.TabIndex = 5;
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(331, 540);
            CountryLabel.Margin = new Padding(4, 0, 4, 0);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(75, 25);
            CountryLabel.TabIndex = 12;
            CountryLabel.Text = "Country";
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(1006, 673);
            CancelBtn.Margin = new Padding(4, 5, 4, 5);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(107, 38);
            CancelBtn.TabIndex = 8;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelClick;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(876, 673);
            SaveBtn.Margin = new Padding(4, 5, 4, 5);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(107, 38);
            SaveBtn.TabIndex = 7;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveClick;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(CountryInput);
            Controls.Add(CountryLabel);
            Controls.Add(PostalCodeLabel);
            Controls.Add(AddressLabel);
            Controls.Add(CityLabel);
            Controls.Add(PhoneInput);
            Controls.Add(CityInput);
            Controls.Add(PostalCodeInput);
            Controls.Add(NameLabel);
            Controls.Add(Address2Label);
            Controls.Add(PhoneLabel);
            Controls.Add(AddressInput);
            Controls.Add(Address2Input);
            Controls.Add(NameInput);
            Margin = new Padding(4, 5, 4, 5);
            Name = "CustomerForm";
            Text = "Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameInput;
        private TextBox Address2Input;
        private TextBox AddressInput;
        private Label PhoneLabel;
        private Label Address2Label;
        private Label NameLabel;
        private TextBox PostalCodeInput;
        private TextBox CityInput;
        private TextBox PhoneInput;
        private Label CityLabel;
        private Label AddressLabel;
        private Label PostalCodeLabel;
        private TextBox CountryInput;
        private Label CountryLabel;
        private Button CancelBtn;
        private Button SaveBtn;
    }
}