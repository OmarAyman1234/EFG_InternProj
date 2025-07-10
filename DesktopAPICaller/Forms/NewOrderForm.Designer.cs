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
            SuspendLayout();
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Location = new Point(247, 105);
            productLabel.Name = "productLabel";
            productLabel.Size = new Size(78, 25);
            productLabel.TabIndex = 0;
            productLabel.Text = "Product:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(247, 142);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(53, 25);
            priceLabel.TabIndex = 1;
            priceLabel.Text = "Price:";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(247, 179);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(84, 25);
            quantityLabel.TabIndex = 2;
            quantityLabel.Text = "Quantity:";
            // 
            // directionLabel
            // 
            directionLabel.AutoSize = true;
            directionLabel.Location = new Point(247, 216);
            directionLabel.Name = "directionLabel";
            directionLabel.Size = new Size(87, 25);
            directionLabel.TabIndex = 3;
            directionLabel.Text = "Direction:";
            // 
            // productTextBox
            // 
            productTextBox.Location = new Point(362, 102);
            productTextBox.Name = "productTextBox";
            productTextBox.Size = new Size(199, 31);
            productTextBox.TabIndex = 5;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(362, 139);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(199, 31);
            priceTextBox.TabIndex = 6;
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(362, 176);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(199, 31);
            quantityTextBox.TabIndex = 7;
            // 
            // directionComboBox
            // 
            directionComboBox.FormattingEnabled = true;
            directionComboBox.Items.AddRange(new object[] { "Buy", "Sell" });
            directionComboBox.Location = new Point(362, 213);
            directionComboBox.Name = "directionComboBox";
            directionComboBox.Size = new Size(199, 33);
            directionComboBox.TabIndex = 8;
            directionComboBox.Text = "Choose direction";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(295, 9);
            label1.Name = "label1";
            label1.Size = new Size(217, 54);
            label1.TabIndex = 9;
            label1.Text = "New Order";
            // 
            // addOrderButton
            // 
            addOrderButton.Location = new Point(353, 275);
            addOrderButton.Name = "addOrderButton";
            addOrderButton.Size = new Size(112, 34);
            addOrderButton.TabIndex = 10;
            addOrderButton.Text = "Add";
            addOrderButton.UseVisualStyleBackColor = true;
            addOrderButton.Click += addOrderButton_Click;
            // 
            // NewOrderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 321);
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
            Name = "NewOrderForm";
            Text = "NewOrderForm";
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
    }
}