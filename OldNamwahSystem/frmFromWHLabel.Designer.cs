namespace OldNamwahSystem
{
    partial class frmFromWHLabel
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnChangeBoxQty = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSelectedBoxLabelFromWH = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintBoxLabelFromWH = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadWH = new DevExpress.XtraEditors.SimpleButton();
            this.gridWHList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWHInspectStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repInspectStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colWHRevision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBoxQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBox1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBox2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBox3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBox4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWHBox5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWHList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInspectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.txtTime);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnChangeBoxQty);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPrintSelectedBoxLabelFromWH);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPrintBoxLabelFromWH);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnLoadWH);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridWHList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(822, 406);
            this.splitContainerControl1.SplitterPosition = 71;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnChangeBoxQty
            // 
            this.btnChangeBoxQty.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeBoxQty.Appearance.Options.UseFont = true;
            this.btnChangeBoxQty.Enabled = false;
            this.btnChangeBoxQty.Location = new System.Drawing.Point(432, 12);
            this.btnChangeBoxQty.Name = "btnChangeBoxQty";
            this.btnChangeBoxQty.Size = new System.Drawing.Size(133, 40);
            this.btnChangeBoxQty.TabIndex = 7;
            this.btnChangeBoxQty.Text = "更改每箱数量";
            this.btnChangeBoxQty.Click += new System.EventHandler(this.btnChangeBoxQty_Click);
            // 
            // btnPrintSelectedBoxLabelFromWH
            // 
            this.btnPrintSelectedBoxLabelFromWH.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSelectedBoxLabelFromWH.Appearance.Options.UseFont = true;
            this.btnPrintSelectedBoxLabelFromWH.Enabled = false;
            this.btnPrintSelectedBoxLabelFromWH.Location = new System.Drawing.Point(292, 12);
            this.btnPrintSelectedBoxLabelFromWH.Name = "btnPrintSelectedBoxLabelFromWH";
            this.btnPrintSelectedBoxLabelFromWH.Size = new System.Drawing.Size(133, 40);
            this.btnPrintSelectedBoxLabelFromWH.TabIndex = 8;
            this.btnPrintSelectedBoxLabelFromWH.Text = "列印选取标签";
            this.btnPrintSelectedBoxLabelFromWH.Click += new System.EventHandler(this.btnPrintSelectedBoxLabelFromWH_Click);
            // 
            // btnPrintBoxLabelFromWH
            // 
            this.btnPrintBoxLabelFromWH.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBoxLabelFromWH.Appearance.Options.UseFont = true;
            this.btnPrintBoxLabelFromWH.Enabled = false;
            this.btnPrintBoxLabelFromWH.Location = new System.Drawing.Point(152, 12);
            this.btnPrintBoxLabelFromWH.Name = "btnPrintBoxLabelFromWH";
            this.btnPrintBoxLabelFromWH.Size = new System.Drawing.Size(133, 40);
            this.btnPrintBoxLabelFromWH.TabIndex = 5;
            this.btnPrintBoxLabelFromWH.Text = "列印所有标签";
            this.btnPrintBoxLabelFromWH.Click += new System.EventHandler(this.btnPrintBoxLabelFromWH_Click);
            // 
            // btnLoadWH
            // 
            this.btnLoadWH.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadWH.Appearance.Options.UseFont = true;
            this.btnLoadWH.Location = new System.Drawing.Point(12, 12);
            this.btnLoadWH.Name = "btnLoadWH";
            this.btnLoadWH.Size = new System.Drawing.Size(133, 40);
            this.btnLoadWH.TabIndex = 6;
            this.btnLoadWH.Text = "重新读取资料";
            this.btnLoadWH.Click += new System.EventHandler(this.btnLoadWH_Click);
            // 
            // gridWHList
            // 
            this.gridWHList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWHList.Location = new System.Drawing.Point(0, 0);
            this.gridWHList.MainView = this.gridView1;
            this.gridWHList.Name = "gridWHList";
            this.gridWHList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repInspectStatus});
            this.gridWHList.Size = new System.Drawing.Size(822, 330);
            this.gridWHList.TabIndex = 0;
            this.gridWHList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWHInspectStatus,
            this.colWHRevision,
            this.colWHPONo,
            this.colWHItemNo,
            this.colWHItemName,
            this.colWHItemType,
            this.colWHBoxQty,
            this.colWHBox1,
            this.colWHBox2,
            this.colWHBox3,
            this.colWHBox4,
            this.colWHBox5});
            this.gridView1.GridControl = this.gridWHList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWHItemType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWHItemNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colWHInspectStatus
            // 
            this.colWHInspectStatus.Caption = "给TSI";
            this.colWHInspectStatus.ColumnEdit = this.repInspectStatus;
            this.colWHInspectStatus.FieldName = "InspectStatus";
            this.colWHInspectStatus.Name = "colWHInspectStatus";
            this.colWHInspectStatus.Visible = true;
            this.colWHInspectStatus.VisibleIndex = 0;
            this.colWHInspectStatus.Width = 35;
            // 
            // repInspectStatus
            // 
            this.repInspectStatus.AutoHeight = false;
            this.repInspectStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repInspectStatus.Items.AddRange(new object[] {
            "NRI",
            "PRRI"});
            this.repInspectStatus.Name = "repInspectStatus";
            this.repInspectStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colWHRevision
            // 
            this.colWHRevision.Caption = "版本号";
            this.colWHRevision.FieldName = "Revision";
            this.colWHRevision.Name = "colWHRevision";
            this.colWHRevision.Visible = true;
            this.colWHRevision.VisibleIndex = 1;
            this.colWHRevision.Width = 50;
            // 
            // colWHPONo
            // 
            this.colWHPONo.Caption = "PO号";
            this.colWHPONo.FieldName = "Shipment.SalesOrderNo";
            this.colWHPONo.Name = "colWHPONo";
            this.colWHPONo.OptionsColumn.AllowEdit = false;
            this.colWHPONo.OptionsColumn.ReadOnly = true;
            this.colWHPONo.Visible = true;
            this.colWHPONo.VisibleIndex = 2;
            this.colWHPONo.Width = 79;
            // 
            // colWHItemNo
            // 
            this.colWHItemNo.Caption = "产品编码";
            this.colWHItemNo.FieldName = "Shipment.CustomerItemNo";
            this.colWHItemNo.Name = "colWHItemNo";
            this.colWHItemNo.OptionsColumn.AllowEdit = false;
            this.colWHItemNo.OptionsColumn.ReadOnly = true;
            this.colWHItemNo.Visible = true;
            this.colWHItemNo.VisibleIndex = 3;
            this.colWHItemNo.Width = 70;
            // 
            // colWHItemName
            // 
            this.colWHItemName.Caption = "名称";
            this.colWHItemName.FieldName = "Shipment.Item.ItemName";
            this.colWHItemName.Name = "colWHItemName";
            this.colWHItemName.OptionsColumn.AllowEdit = false;
            this.colWHItemName.OptionsColumn.ReadOnly = true;
            this.colWHItemName.Visible = true;
            this.colWHItemName.VisibleIndex = 4;
            this.colWHItemName.Width = 92;
            // 
            // colWHItemType
            // 
            this.colWHItemType.Caption = "种类";
            this.colWHItemType.FieldName = "Shipment.Item.ItemType";
            this.colWHItemType.Name = "colWHItemType";
            this.colWHItemType.OptionsColumn.AllowEdit = false;
            this.colWHItemType.OptionsColumn.ReadOnly = true;
            this.colWHItemType.Visible = true;
            this.colWHItemType.VisibleIndex = 5;
            // 
            // colWHBoxQty
            // 
            this.colWHBoxQty.Caption = "每箱数量";
            this.colWHBoxQty.FieldName = "BoxQty";
            this.colWHBoxQty.Name = "colWHBoxQty";
            this.colWHBoxQty.OptionsColumn.AllowEdit = false;
            this.colWHBoxQty.OptionsColumn.ReadOnly = true;
            this.colWHBoxQty.Visible = true;
            this.colWHBoxQty.VisibleIndex = 6;
            this.colWHBoxQty.Width = 62;
            // 
            // colWHBox1
            // 
            this.colWHBox1.Caption = "箱数1";
            this.colWHBox1.FieldName = "Box1";
            this.colWHBox1.Name = "colWHBox1";
            this.colWHBox1.OptionsColumn.AllowEdit = false;
            this.colWHBox1.OptionsColumn.ReadOnly = true;
            this.colWHBox1.Visible = true;
            this.colWHBox1.VisibleIndex = 7;
            this.colWHBox1.Width = 62;
            // 
            // colWHBox2
            // 
            this.colWHBox2.Caption = "箱数2";
            this.colWHBox2.FieldName = "Box2";
            this.colWHBox2.Name = "colWHBox2";
            this.colWHBox2.OptionsColumn.AllowEdit = false;
            this.colWHBox2.OptionsColumn.ReadOnly = true;
            this.colWHBox2.Visible = true;
            this.colWHBox2.VisibleIndex = 8;
            this.colWHBox2.Width = 62;
            // 
            // colWHBox3
            // 
            this.colWHBox3.Caption = "箱数3";
            this.colWHBox3.FieldName = "Box3";
            this.colWHBox3.Name = "colWHBox3";
            this.colWHBox3.OptionsColumn.AllowEdit = false;
            this.colWHBox3.OptionsColumn.ReadOnly = true;
            this.colWHBox3.Visible = true;
            this.colWHBox3.VisibleIndex = 9;
            this.colWHBox3.Width = 62;
            // 
            // colWHBox4
            // 
            this.colWHBox4.Caption = "箱数4";
            this.colWHBox4.FieldName = "Box4";
            this.colWHBox4.Name = "colWHBox4";
            this.colWHBox4.OptionsColumn.AllowEdit = false;
            this.colWHBox4.OptionsColumn.ReadOnly = true;
            this.colWHBox4.Visible = true;
            this.colWHBox4.VisibleIndex = 10;
            this.colWHBox4.Width = 62;
            // 
            // colWHBox5
            // 
            this.colWHBox5.Caption = "箱数5";
            this.colWHBox5.FieldName = "Box5";
            this.colWHBox5.Name = "colWHBox5";
            this.colWHBox5.OptionsColumn.AllowEdit = false;
            this.colWHBox5.OptionsColumn.ReadOnly = true;
            this.colWHBox5.Visible = true;
            this.colWHBox5.VisibleIndex = 11;
            this.colWHBox5.Width = 62;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(571, 32);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(237, 20);
            this.txtTime.TabIndex = 18;
            this.txtTime.TabStop = false;
            // 
            // frmFromWHLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 406);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmFromWHLabel";
            this.Text = "打印存仓标签";
            this.Load += new System.EventHandler(this.frmFromWHLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWHList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repInspectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnChangeBoxQty;
        private DevExpress.XtraEditors.SimpleButton btnPrintSelectedBoxLabelFromWH;
        private DevExpress.XtraEditors.SimpleButton btnPrintBoxLabelFromWH;
        private DevExpress.XtraEditors.SimpleButton btnLoadWH;
        private DevExpress.XtraGrid.GridControl gridWHList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colWHInspectStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWHRevision;
        private DevExpress.XtraGrid.Columns.GridColumn colWHPONo;
        private DevExpress.XtraGrid.Columns.GridColumn colWHItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWHItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBoxQty;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBox3;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBox4;
        private DevExpress.XtraGrid.Columns.GridColumn colWHBox5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repInspectStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWHItemType;
        private DevExpress.XtraEditors.TextEdit txtTime;
    }
}