namespace DesktopAPICaller.Forms
{
    partial class OrdersTrackerForm
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
            label1 = new Label();
            trackerDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)trackerDataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(298, 16);
            label1.Name = "label1";
            label1.Size = new Size(198, 38);
            label1.TabIndex = 0;
            label1.Text = "Orders Tracker";
            // 
            // trackerDataGrid
            // 
            trackerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trackerDataGrid.Location = new Point(-2, 82);
            trackerDataGrid.Name = "trackerDataGrid";
            trackerDataGrid.RowHeadersWidth = 62;
            trackerDataGrid.Size = new Size(803, 367);
            trackerDataGrid.TabIndex = 1;
            // 
            // OrdersTrackerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackerDataGrid);
            Controls.Add(label1);
            Name = "OrdersTrackerForm";
            Text = "OrdersTrackerForm";
            Load += OrdersTrackerForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackerDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView trackerDataGrid;
    }
}