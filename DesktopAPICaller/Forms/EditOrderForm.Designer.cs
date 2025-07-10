namespace DesktopAPICaller.Forms
{
    partial class EditOrderForm
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
            idLabel = new Label();
            idTextBox = new TextBox();
            clientIdTextBox = new TextBox();
            clientIdLabel = new Label();
            productTextBox = new TextBox();
            productLabel = new Label();
            priceTextBox = new TextBox();
            priceLabel = new Label();
            quantityTextBox = new TextBox();
            quantityLabel = new Label();
            directionLabel = new Label();
            directionComboBox = new ComboBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(232, 37);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(32, 25);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(344, 34);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(150, 31);
            idTextBox.TabIndex = 1;
            // 
            // clientIdTextBox
            // 
            clientIdTextBox.Location = new Point(344, 71);
            clientIdTextBox.Name = "clientIdTextBox";
            clientIdTextBox.ReadOnly = true;
            clientIdTextBox.Size = new Size(150, 31);
            clientIdTextBox.TabIndex = 3;
            // 
            // clientIdLabel
            // 
            clientIdLabel.AutoSize = true;
            clientIdLabel.Location = new Point(232, 74);
            clientIdLabel.Name = "clientIdLabel";
            clientIdLabel.Size = new Size(81, 25);
            clientIdLabel.TabIndex = 2;
            clientIdLabel.Text = "Client Id:";
            // 
            // productTextBox
            // 
            productTextBox.Location = new Point(344, 108);
            productTextBox.Name = "productTextBox";
            productTextBox.Size = new Size(150, 31);
            productTextBox.TabIndex = 5;
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Location = new Point(232, 111);
            productLabel.Name = "productLabel";
            productLabel.Size = new Size(78, 25);
            productLabel.TabIndex = 4;
            productLabel.Text = "Product:";
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(344, 145);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(150, 31);
            priceTextBox.TabIndex = 11;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(232, 148);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(53, 25);
            priceLabel.TabIndex = 10;
            priceLabel.Text = "Price:";
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(344, 182);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(150, 31);
            quantityTextBox.TabIndex = 13;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(232, 185);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(84, 25);
            quantityLabel.TabIndex = 12;
            quantityLabel.Text = "Quantity:";
            // 
            // directionLabel
            // 
            directionLabel.AutoSize = true;
            directionLabel.Location = new Point(232, 227);
            directionLabel.Name = "directionLabel";
            directionLabel.Size = new Size(87, 25);
            directionLabel.TabIndex = 14;
            directionLabel.Text = "Direction:";
            // 
            // directionComboBox
            // 
            directionComboBox.FormattingEnabled = true;
            directionComboBox.Items.AddRange(new object[] { "Buy", "Sell" });
            directionComboBox.Location = new Point(345, 224);
            directionComboBox.Name = "directionComboBox";
            directionComboBox.Size = new Size(149, 33);
            directionComboBox.TabIndex = 15;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.Cyan;
            saveButton.Location = new Point(316, 279);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 16;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // EditOrderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(saveButton);
            Controls.Add(directionComboBox);
            Controls.Add(directionLabel);
            Controls.Add(quantityTextBox);
            Controls.Add(quantityLabel);
            Controls.Add(priceTextBox);
            Controls.Add(priceLabel);
            Controls.Add(productTextBox);
            Controls.Add(productLabel);
            Controls.Add(clientIdTextBox);
            Controls.Add(clientIdLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Name = "EditOrderForm";
            Text = "EditOrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private TextBox clientIdTextBox;
        private Label clientIdLabel;
        private TextBox productTextBox;
        private Label productLabel;
        private TextBox priceTextBox;
        private Label priceLabel;
        private TextBox quantityTextBox;
        private Label quantityLabel;
        private Label directionLabel;
        private ComboBox directionComboBox;
        private Button saveButton;
    }
}