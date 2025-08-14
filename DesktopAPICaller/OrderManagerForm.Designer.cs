namespace DesktopAPICaller
{
    partial class orderManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            getAllOrdersButton = new Button();
            getSpecificOrderButton = new Button();
            newOrderButton = new Button();
            greetLabel = new Label();
            SuspendLayout();
            // 
            // getAllOrdersButton
            // 
            getAllOrdersButton.Location = new Point(168, 153);
            getAllOrdersButton.Name = "getAllOrdersButton";
            getAllOrdersButton.Size = new Size(237, 50);
            getAllOrdersButton.TabIndex = 0;
            getAllOrdersButton.Text = "Get all orders";
            getAllOrdersButton.UseVisualStyleBackColor = true;
            getAllOrdersButton.Click += getAllOrdersButton_Click;
            // 
            // getSpecificOrderButton
            // 
            getSpecificOrderButton.Location = new Point(168, 209);
            getSpecificOrderButton.Name = "getSpecificOrderButton";
            getSpecificOrderButton.Size = new Size(237, 50);
            getSpecificOrderButton.TabIndex = 1;
            getSpecificOrderButton.Text = "Get a specific order";
            getSpecificOrderButton.UseVisualStyleBackColor = true;
            getSpecificOrderButton.Click += getSpecificOrderButton_Click;
            // 
            // newOrderButton
            // 
            newOrderButton.Location = new Point(168, 97);
            newOrderButton.Name = "newOrderButton";
            newOrderButton.Size = new Size(237, 50);
            newOrderButton.TabIndex = 4;
            newOrderButton.Text = "New order";
            newOrderButton.UseVisualStyleBackColor = true;
            newOrderButton.Click += newOrderButton_Click;
            // 
            // greetLabel
            // 
            greetLabel.BackColor = Color.Transparent;
            greetLabel.Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            greetLabel.ForeColor = Color.Blue;
            greetLabel.Location = new Point(12, 9);
            greetLabel.Name = "greetLabel";
            greetLabel.Size = new Size(551, 72);
            greetLabel.TabIndex = 5;
            greetLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // orderManager
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 334);
            Controls.Add(greetLabel);
            Controls.Add(newOrderButton);
            Controls.Add(getSpecificOrderButton);
            Controls.Add(getAllOrdersButton);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "orderManager";
            Text = "Order Manager";
            ResumeLayout(false);
        }

        #endregion

        private Button getAllOrdersButton;
        private Button getSpecificOrderButton;
        private Button newOrderButton;
        private Label greetLabel;
    }
}
