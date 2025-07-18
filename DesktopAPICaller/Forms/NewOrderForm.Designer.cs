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
            quantityTextBox = new TextBox();
            directionComboBox = new ComboBox();
            label1 = new Label();
            addOrderButton = new Button();
            productsComboBox = new ComboBox();
            priceLabelValue = new Label();
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
            quantityLabel.Location = new Point(247, 178);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(84, 25);
            quantityLabel.TabIndex = 2;
            quantityLabel.Text = "Quantity:";
            // 
            // directionLabel
            // 
            directionLabel.AutoSize = true;
            directionLabel.Location = new Point(247, 217);
            directionLabel.Name = "directionLabel";
            directionLabel.Size = new Size(87, 25);
            directionLabel.TabIndex = 3;
            directionLabel.Text = "Direction:";
            // 
            // quantityTextBox
            // 
            quantityTextBox.Location = new Point(361, 177);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(198, 31);
            quantityTextBox.TabIndex = 7;
            // 
            // directionComboBox
            // 
            directionComboBox.FormattingEnabled = true;
            directionComboBox.Items.AddRange(new object[] { "Buy", "Sell" });
            directionComboBox.Location = new Point(361, 213);
            directionComboBox.Name = "directionComboBox";
            directionComboBox.Size = new Size(198, 33);
            directionComboBox.TabIndex = 8;
            directionComboBox.Text = "Choose direction";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(294, 8);
            label1.Name = "label1";
            label1.Size = new Size(217, 54);
            label1.TabIndex = 9;
            label1.Text = "New Order";
            // 
            // addOrderButton
            // 
            addOrderButton.Location = new Point(353, 275);
            addOrderButton.Name = "addOrderButton";
            addOrderButton.Size = new Size(111, 33);
            addOrderButton.TabIndex = 10;
            addOrderButton.Text = "Add";
            addOrderButton.UseVisualStyleBackColor = true;
            addOrderButton.Click += addOrderButton_Click;
            // 
            // productsComboBox
            // 
            productsComboBox.FormattingEnabled = true;
            productsComboBox.Location = new Point(361, 102);
            productsComboBox.Margin = new Padding(4, 5, 4, 5);
            productsComboBox.Name = "productsComboBox";
            productsComboBox.Size = new Size(171, 33);
            productsComboBox.TabIndex = 11;
            productsComboBox.Text = "Choose a product";
            productsComboBox.SelectedIndexChanged += productsComboBox_SelectedIndexChanged;
            // 
            // priceLabelValue
            // 
            priceLabelValue.AutoSize = true;
            priceLabelValue.Location = new Point(364, 149);
            priceLabelValue.Name = "priceLabelValue";
            priceLabelValue.Size = new Size(24, 25);
            priceLabelValue.TabIndex = 13;
            priceLabelValue.Text = "...";
            // 
            // NewOrderForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 322);
            Controls.Add(priceLabelValue);
            Controls.Add(productsComboBox);
            Controls.Add(addOrderButton);
            Controls.Add(label1);
            Controls.Add(directionComboBox);
            Controls.Add(quantityTextBox);
            Controls.Add(directionLabel);
            Controls.Add(quantityLabel);
            Controls.Add(priceLabel);
            Controls.Add(productLabel);
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
        private TextBox quantityTextBox;
        private ComboBox directionComboBox;
        private Label label1;
        private Button addOrderButton;
        private ComboBox productsComboBox;
        private Label priceLabelValue;
    }
}