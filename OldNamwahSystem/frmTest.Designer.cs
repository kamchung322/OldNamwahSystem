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
            ((System.ComponentModel.ISupportInitialize)(this.txtStringList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPriority
            // 
            this.btnPriority.Location = new System.Drawing.Point(36, 27);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(115, 52);
            this.btnPriority.TabIndex = 0;
            this.btnPriority.Text = "Priority";
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.Location = new System.Drawing.Point(36, 85);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(115, 52);
            this.btnShipment.TabIndex = 1;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnTestStringSplit
            // 
            this.btnTestStringSplit.Location = new System.Drawing.Point(169, 85);
            this.btnTestStringSplit.Name = "btnTestStringSplit";
            this.btnTestStringSplit.Size = new System.Drawing.Size(115, 52);
            this.btnTestStringSplit.TabIndex = 2;
            this.btnTestStringSplit.Text = "Spring Split";
            this.btnTestStringSplit.Click += new System.EventHandler(this.btnTestStringSplit_Click);
            // 
            // txtStringList
            // 
            this.txtStringList.EditValue = "10,20,30,40";
            this.txtStringList.Location = new System.Drawing.Point(260, 35);
            this.txtStringList.Name = "txtStringList";
            this.txtStringList.Size = new System.Drawing.Size(100, 20);
            this.txtStringList.TabIndex = 3;
            // 
            // txtCartonNo
            // 
            this.txtCartonNo.Location = new System.Drawing.Point(260, 61);
            this.txtCartonNo.Name = "txtCartonNo";
            this.txtCartonNo.Size = new System.Drawing.Size(100, 20);
            this.txtCartonNo.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(193, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "StringList";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(193, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "CartonNo";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 280);
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
    }
}