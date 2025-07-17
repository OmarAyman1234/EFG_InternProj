namespace DesktopAPICaller.Forms
{
    partial class NewOrderForm
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
            productLabel = new Label();
            priceLabel = new Label();
            quantityLabel = new Label();
            directionLabel = new Label();
            productTextBox = new TextBox();
            priceTextBox = new TextBox();
            quantityTextBox = new TextBox();
            directionComboBox = new ComboBox();
            label1 = new Label();
            addOrderButton = new Button();
            productsComboBox = new ComboBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Location = new Point(173, 63);
            productLabel.Margin = new Padding(2, 0, 2, 0);
            productLabel.Name = "productLabel";
            productLabel.Size = new Size(52, 15);
            productLabel.TabIndex = 0;
            productLabel.Text = "Product:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(173, 85);
            priceLabel.Margin = new Padding(2, 0, 2, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(36, 15);
            priceLabel.TabIndex = 1;
            priceLabel.Text = "Price:";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(173, 107);
            quantityLabel.Margin = new Padding(2, 0, 2, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(56, 15);
            quantityLabel.TabIndex = 2;
            quantityLabel.Text = "Quantity:";
            // 
            // directionLabel
            // 
            directionLabel.AutoSize = true;
            directionLabel.Location = new Point(173, 130);
            directionLabel.Margin = new Padding(2, 0, 2, 0);
            directionLabel.Name = "directionLabel";
            directionLabel.Size = new Size(58, 15);
            directionLabel.TabIndex = 3;
            directionLabel.Text = "Direction:";
            // 
            // productTextBox
            // 
            productTextBox.Location = new Point(253, 61);
            productTextBox.Margin = new Padding(2, 2, 2, 2);
            productTextBox.Name = "productTextBox";
            productTextBox.Size = new Size(140, 23);
            productTextBox.TabIndex = 5;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(253, 83);
            priceTextBox.Margin = new Padding(2, 2, 2, 2);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(140, 23);
            priceTextBox.TabIndex = 6;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(253, 106);
            quantityTextBox.Margin = new Padding(2, 2, 2, 2);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(140, 23);
            quantityTextBox.TabIndex = 7;
            // 
            // directionComboBox
            // 
            directionComboBox.FormattingEnabled = true;
            directionComboBox.Items.AddRange(new object[] { "Buy", "Sell" });
            directionComboBox.Location = new Point(253, 128);
            directionComboBox.Margin = new Padding(2, 2, 2, 2);
            directionComboBox.Name = "directionComboBox";
            directionComboBox.Size = new Size(140, 23);
            directionComboBox.TabIndex = 8;
            directionComboBox.Text = "Choose direction";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(206, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 37);
            label1.TabIndex = 9;
            label1.Text = "New Order";
            // 
            // addOrderButton
            // 
            addOrderButton.Location = new Point(247, 165);
            addOrderButton.Margin = new Padding(2, 2, 2, 2);
            addOrderButton.Name = "addOrderButton";
            addOrderButton.Size = new Size(78, 20);
            addOrderButton.TabIndex = 10;
            addOrderButton.Text = "Add";
            addOrderButton.UseVisualStyleBackColor = true;
            addOrderButton.Click += addOrderButton_Click;
            // 
            // productsComboBox
            // 
            productsComboBox.FormattingEnabled = true;
            productsComboBox.Location = new Point(417, 61);
            productsComboBox.Name = "productsComboBox";
            productsComboBox.Size = new Size(121, 23);
            productsComboBox.TabIndex = 11;
            productsComboBox.Text = "Choose a product";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(417, 89);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 12;
            // 
            // NewOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 193);
            Controls.Add(textBox1);
            Controls.Add(productsComboBox);
            Controls.Add(addOrderButton);
            Controls.Add(label1);
            Controls.Add(directionComboBox);
            Controls.Add(quantityTextBox);
            Controls.Add(priceTextBox);
            Controls.Add(productTextBox);
            Controls.Add(directionLabel);
            Controls.Add(quantityLabel);
            Controls.Add(priceLabel);
            Controls.Add(productLabel);
            Margin = new Padding(2, 2, 2, 2);
            Name = "NewOrderForm";
            Text = "NewOrderForm";
            Load += NewOrderForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label productLabel;
        private Label priceLabel;
        private Label quantityLabel;
        private Label directionLabel;
        private TextBox productTextBox;
        private TextBox priceTextBox;
        private TextBox quantityTextBox;
        private ComboBox directionComboBox;
        private Label label1;
        private Button addOrderButton;
        private ComboBox productsComboBox;
        private TextBox textBox1;
    }
}