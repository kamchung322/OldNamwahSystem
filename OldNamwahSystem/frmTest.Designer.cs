namespace OldNamwahSystem
{
    partial class frmTest
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
            this.btnPriority = new DevExpress.XtraEditors.SimpleButton();
            this.btnShipment = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestStringSplit = new DevExpress.XtraEditors.SimpleButton();
            this.txtStringList = new DevExpress.XtraEditors.TextEdit();
            this.txtCartonNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSOLines = new DevExpress.XtraEditors.SimpleButton();
            this.btnStringTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnIsNullOrEmpty = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtStringList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPriority
            // 
            this.btnPriority.Location = new System.Drawing.Point(42, 29);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(134, 56);
            this.btnPriority.TabIndex = 0;
            this.btnPriority.Text = "Priority";
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.Location = new System.Drawing.Point(42, 92);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(134, 56);
            this.btnShipment.TabIndex = 1;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnTestStringSplit
            // 
            this.btnTestStringSplit.Location = new System.Drawing.Point(197, 92);
            this.btnTestStringSplit.Name = "btnTestStringSplit";
            this.btnTestStringSplit.Size = new System.Drawing.Size(134, 56);
            this.btnTestStringSplit.TabIndex = 2;
            this.btnTestStringSplit.Text = "Spring Split";
            this.btnTestStringSplit.Click += new System.EventHandler(this.btnTestStringSplit_Click);
            // 
            // txtStringList
            // 
            this.txtStringList.EditValue = "10,20,30,40";
            this.txtStringList.Location = new System.Drawing.Point(303, 38);
            this.txtStringList.Name = "txtStringList";
            this.txtStringList.Size = new System.Drawing.Size(117, 20);
            this.txtStringList.TabIndex = 3;
            // 
            // txtCartonNo
            // 
            this.txtCartonNo.Location = new System.Drawing.Point(303, 66);
            this.txtCartonNo.Name = "txtCartonNo";
            this.txtCartonNo.Size = new System.Drawing.Size(117, 20);
            this.txtCartonNo.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(225, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "StringList";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(225, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "CartonNo";
            // 
            // btnSOLines
            // 
            this.btnSOLines.Location = new System.Drawing.Point(42, 168);
            this.btnSOLines.Name = "btnSOLines";
            this.btnSOLines.Size = new System.Drawing.Size(134, 56);
            this.btnSOLines.TabIndex = 5;
            this.btnSOLines.Text = "SalesOrderLine";
            this.btnSOLines.Click += new System.EventHandler(this.btnSOLines_Click);
            // 
            // btnStringTest
            // 
            this.btnStringTest.Location = new System.Drawing.Point(197, 168);
            this.btnStringTest.Name = "btnStringTest";
            this.btnStringTest.Size = new System.Drawing.Size(134, 56);
            this.btnStringTest.TabIndex = 6;
            this.btnStringTest.Text = "String Test";
            this.btnStringTest.Click += new System.EventHandler(this.btnStringTest_Click);
            // 
            // btnIsNullOrEmpty
            // 
            this.btnIsNullOrEmpty.Location = new System.Drawing.Point(358, 93);
            this.btnIsNullOrEmpty.Name = "btnIsNullOrEmpty";
            this.btnIsNullOrEmpty.Size = new System.Drawing.Size(135, 55);
            this.btnIsNullOrEmpty.TabIndex = 7;
            this.btnIsNullOrEmpty.Text = "String.IsNullOrEmpty";
            this.btnIsNullOrEmpty.Click += new System.EventHandler(this.btnIsNullOrEmpty_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 322);
            this.Controls.Add(this.btnIsNullOrEmpty);
            this.Controls.Add(this.btnStringTest);
            this.Controls.Add(this.btnSOLines);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCartonNo);
            this.Controls.Add(this.txtStringList);
            this.Controls.Add(this.btnTestStringSplit);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.btnPriority);
            this.Name = "frmTest";
            this.Text = "frmTest";
            ((System.ComponentModel.ISupportInitialize)(this.txtStringList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPriority;
        private DevExpress.XtraEditors.SimpleButton btnShipment;
        private DevExpress.XtraEditors.SimpleButton btnTestStringSplit;
        private DevExpress.XtraEditors.TextEdit txtStringList;
        private DevExpress.XtraEditors.TextEdit txtCartonNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSOLines;
        private DevExpress.XtraEditors.SimpleButton btnStringTest;
        private DevExpress.XtraEditors.SimpleButton btnIsNullOrEmpty;
    }
}