namespace DesktopAPICaller.Forms
{
    partial class GetSpecificOrderForm
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
            enterIdLabel = new Label();
            enterIdTextBox = new TextBox();
            orderDataGridView = new DataGridView();
            getOrderButton = new Button();
            editOrderButton = new Button();
            deleteOrderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)orderDataGridView).BeginInit();
            SuspendLayout();
            // 
            // enterIdLabel
            // 
            enterIdLabel.AutoSize = true;
            enterIdLabel.Location = new Point(303, 40);
            enterIdLabel.Name = "enterIdLabel";
            enterIdLabel.Size = new Size(104, 32);
            enterIdLabel.TabIndex = 0;
            enterIdLabel.Text = "Enter ID:";
            // 
            // enterIdTextBox
            // 
            enterIdTextBox.Location = new Point(427, 37);
            enterIdTextBox.Name = "enterIdTextBox";
            enterIdTextBox.Size = new Size(157, 39);
            enterIdTextBox.TabIndex = 1;
            // 
            // orderDataGridView
            // 
            orderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGridView.Location = new Point(0, 113);
            orderDataGridView.Name = "orderDataGridView";
            orderDataGridView.RowHeadersWidth = 62;
            orderDataGridView.Size = new Size(1020, 78);
            orderDataGridView.TabIndex = 2;
            // 
            // getOrderButton
            // 
            getOrderButton.BackColor = Color.Black;
            getOrderButton.ForeColor = Color.WhiteSmoke;
            getOrderButton.Location = new Point(616, 32);
            getOrderButton.Name = "getOrderButton";
            getOrderButton.Size = new Size(135, 49);
            getOrderButton.TabIndex = 3;
            getOrderButton.Text = "Get order";
            getOrderButton.UseVisualStyleBackColor = false;
            getOrderButton.Click += getOrderButton_Click;
            // 
            // editOrderButton
            // 
            editOrderButton.BackColor = Color.DodgerBlue;
            editOrderButton.ForeColor = SystemColors.Control;
            editOrderButton.Location = new Point(303, 217);
            editOrderButton.Name = "editOrderButton";
            editOrderButton.Size = new Size(149, 48);
            editOrderButton.TabIndex = 4;
            editOrderButton.Text = "Edit order";
            editOrderButton.UseVisualStyleBackColor = false;
            editOrderButton.Click += editOrderButton_Click;
            // 
            // deleteOrderButton
            // 
            deleteOrderButton.BackColor = Color.Red;
            deleteOrderButton.ForeColor = Color.White;
            deleteOrderButton.Location = new Point(550, 217);
            deleteOrderButton.Name = "deleteOrderButton";
            deleteOrderButton.Size = new Size(163, 48);
            deleteOrderButton.TabIndex = 6;
            deleteOrderButton.Text = "Delete order";
            deleteOrderButton.UseVisualStyleBackColor = false;
            deleteOrderButton.Click += deleteOrderButton_Click;
            // 
            // GetSpecificOrderForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 290);
            Controls.Add(deleteOrderButton);
            Controls.Add(editOrderButton);
            Controls.Add(getOrderButton);
            Controls.Add(orderDataGridView);
            Controls.Add(enterIdTextBox);
            Controls.Add(enterIdLabel);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "GetSpecificOrderForm";
            Text = "GetSpecificOrderForm";
            ((System.ComponentModel.ISupportInitialize)orderDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label enterIdLabel;
        private TextBox enterIdTextBox;
        private DataGridView orderDataGridView;
        private Button getOrderButton;
        private Button editOrderButton;
        private Button deleteOrderButton;
    }
}