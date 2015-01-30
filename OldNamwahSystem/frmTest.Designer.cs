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
            this.btnEnum = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestFunction = new DevExpress.XtraEditors.SimpleButton();
            this.btnWHHistory = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestEF = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCustomerItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNeedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPromisedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColNeedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColShippedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPendingShipQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColIgnorePlanningReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoadSalesOrder = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtItemNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStringList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPriority
            // 
            this.btnPriority.Location = new System.Drawing.Point(23, 15);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(134, 56);
            this.btnPriority.TabIndex = 0;
            this.btnPriority.Text = "Priority";
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.Location = new System.Drawing.Point(23, 78);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(134, 56);
            this.btnShipment.TabIndex = 1;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnTestStringSplit
            // 
            this.btnTestStringSplit.Location = new System.Drawing.Point(178, 79);
            this.btnTestStringSplit.Name = "btnTestStringSplit";
            this.btnTestStringSplit.Size = new System.Drawing.Size(134, 56);
            this.btnTestStringSplit.TabIndex = 2;
            this.btnTestStringSplit.Text = "Spring Split";
            this.btnTestStringSplit.Click += new System.EventHandler(this.btnTestStringSplit_Click);
            // 
            // txtStringList
            // 
            this.txtStringList.EditValue = "10,20,30,40";
            this.txtStringList.Location = new System.Drawing.Point(284, 24);
            this.txtStringList.Name = "txtStringList";
            this.txtStringList.Size = new System.Drawing.Size(117, 20);
            this.txtStringList.TabIndex = 3;
            // 
            // txtCartonNo
            // 
            this.txtCartonNo.Location = new System.Drawing.Point(284, 52);
            this.txtCartonNo.Name = "txtCartonNo";
            this.txtCartonNo.Size = new System.Drawing.Size(117, 20);
            this.txtCartonNo.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(206, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "StringList";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(206, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "CartonNo";
            // 
            // btnSOLines
            // 
            this.btnSOLines.Location = new System.Drawing.Point(23, 154);
            this.btnSOLines.Name = "btnSOLines";
            this.btnSOLines.Size = new System.Drawing.Size(134, 56);
            this.btnSOLines.TabIndex = 5;
            this.btnSOLines.Text = "SalesOrderLine";
            this.btnSOLines.Click += new System.EventHandler(this.btnSOLines_Click);
            // 
            // btnStringTest
            // 
            this.btnStringTest.Location = new System.Drawing.Point(178, 154);
            this.btnStringTest.Name = "btnStringTest";
            this.btnStringTest.Size = new System.Drawing.Size(134, 56);
            this.btnStringTest.TabIndex = 6;
            this.btnStringTest.Text = "String Test";
            this.btnStringTest.Click += new System.EventHandler(this.btnStringTest_Click);
            // 
            // btnIsNullOrEmpty
            // 
            this.btnIsNullOrEmpty.Location = new System.Drawing.Point(339, 79);
            this.btnIsNullOrEmpty.Name = "btnIsNullOrEmpty";
            this.btnIsNullOrEmpty.Size = new System.Drawing.Size(135, 55);
            this.btnIsNullOrEmpty.TabIndex = 7;
            this.btnIsNullOrEmpty.Text = "String.IsNullOrEmpty";
            this.btnIsNullOrEmpty.Click += new System.EventHandler(this.btnIsNullOrEmpty_Click);
            // 
            // btnEnum
            // 
            this.btnEnum.Location = new System.Drawing.Point(339, 154);
            this.btnEnum.Name = "btnEnum";
            this.btnEnum.Size = new System.Drawing.Size(118, 56);
            this.btnEnum.TabIndex = 8;
            this.btnEnum.Text = "Enum";
            this.btnEnum.Click += new System.EventHandler(this.btnEnum_Click);
            // 
            // btnTestFunction
            // 
            this.btnTestFunction.Location = new System.Drawing.Point(23, 216);
            this.btnTestFunction.Name = "btnTestFunction";
            this.btnTestFunction.Size = new System.Drawing.Size(134, 56);
            this.btnTestFunction.TabIndex = 8;
            this.btnTestFunction.Text = "Test Function";
            this.btnTestFunction.Click += new System.EventHandler(this.btnTestFunction_Click);
            // 
            // btnWHHistory
            // 
            this.btnWHHistory.Location = new System.Drawing.Point(178, 216);
            this.btnWHHistory.Name = "btnWHHistory";
            this.btnWHHistory.Size = new System.Drawing.Size(134, 56);
            this.btnWHHistory.TabIndex = 8;
            this.btnWHHistory.Text = "WHHistory ";
            this.btnWHHistory.Click += new System.EventHandler(this.btnWHHistory_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(340, 216);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(134, 56);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "simpleButton1";
            // 
            // btnTestEF
            // 
            this.btnTestEF.Location = new System.Drawing.Point(510, 114);
            this.btnTestEF.Name = "btnTestEF";
            this.btnTestEF.Size = new System.Drawing.Size(124, 55);
            this.btnTestEF.TabIndex = 8;
            this.btnTestEF.Text = "Test EF";
            this.btnTestEF.Click += new System.EventHandler(this.btnTestEF_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(781, 360);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColOrderNo,
            this.ColCustomer,
            this.ColOrderIndex,
            this.ColOrderDate,
            this.ColCustomerItemNo,
            this.ColItemNo,
            this.ColItemName,
            this.ColItemType,
            this.ColMaterial,
            this.ColNeedDate,
            this.ColPromisedDate,
            this.ColPriority,
            this.ColNeedQty,
            this.ColPendingShipQty,
            this.ColShippedQty,
            this.ColBalQty,
            this.ColIgnorePlanningReport});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColOrderNo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColOrderIndex, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColOrderNo
            // 
            this.ColOrderNo.Caption = "销售单号";
            this.ColOrderNo.FieldName = "OrderNo";
            this.ColOrderNo.Name = "ColOrderNo";
            this.ColOrderNo.Visible = true;
            this.ColOrderNo.VisibleIndex = 0;
            // 
            // ColCustomer
            // 
            this.ColCustomer.Caption = "人客";
            this.ColCustomer.FieldName = "Customer";
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.Visible = true;
            this.ColCustomer.VisibleIndex = 0;
            this.ColCustomer.Width = 49;
            // 
            // ColOrderIndex
            // 
            this.ColOrderIndex.Caption = "Index";
            this.ColOrderIndex.FieldName = "OrderIndex";
            this.ColOrderIndex.Name = "ColOrderIndex";
            this.ColOrderIndex.Visible = true;
            this.ColOrderIndex.VisibleIndex = 1;
            this.ColOrderIndex.Width = 31;
            // 
            // ColOrderDate
            // 
            this.ColOrderDate.Caption = "销售单日期";
            this.ColOrderDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColOrderDate.FieldName = "OrderDate";
            this.ColOrderDate.Name = "ColOrderDate";
            this.ColOrderDate.Visible = true;
            this.ColOrderDate.VisibleIndex = 2;
            this.ColOrderDate.Width = 50;
            // 
            // ColCustomerItemNo
            // 
            this.ColCustomerItemNo.Caption = "人客编码";
            this.ColCustomerItemNo.FieldName = "CustomerItemNo";
            this.ColCustomerItemNo.Name = "ColCustomerItemNo";
            this.ColCustomerItemNo.Visible = true;
            this.ColCustomerItemNo.VisibleIndex = 3;
            this.ColCustomerItemNo.Width = 50;
            // 
            // ColItemNo
            // 
            this.ColItemNo.Caption = "本厂编码";
            this.ColItemNo.FieldName = "ItemNo";
            this.ColItemNo.Name = "ColItemNo";
            this.ColItemNo.Visible = true;
            this.ColItemNo.VisibleIndex = 4;
            this.ColItemNo.Width = 50;
            // 
            // ColItemName
            // 
            this.ColItemName.Caption = "产品名称";
            this.ColItemName.FieldName = "ItemName";
            this.ColItemName.Name = "ColItemName";
            this.ColItemName.Visible = true;
            this.ColItemName.VisibleIndex = 5;
            this.ColItemName.Width = 73;
            // 
            // ColItemType
            // 
            this.ColItemType.Caption = "产品种类";
            this.ColItemType.FieldName = "ItemType";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.Visible = true;
            this.ColItemType.VisibleIndex = 6;
            this.ColItemType.Width = 46;
            // 
            // ColMaterial
            // 
            this.ColMaterial.Caption = "材料";
            this.ColMaterial.FieldName = "Material";
            this.ColMaterial.Name = "ColMaterial";
            this.ColMaterial.Visible = true;
            this.ColMaterial.VisibleIndex = 7;
            this.ColMaterial.Width = 36;
            // 
            // ColNeedDate
            // 
            this.ColNeedDate.Caption = "要求交期";
            this.ColNeedDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColNeedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColNeedDate.FieldName = "NeedDate";
            this.ColNeedDate.Name = "ColNeedDate";
            this.ColNeedDate.Visible = true;
            this.ColNeedDate.VisibleIndex = 8;
            this.ColNeedDate.Width = 62;
            // 
            // ColPromisedDate
            // 
            this.ColPromisedDate.Caption = "回覆交期";
            this.ColPromisedDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColPromisedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColPromisedDate.FieldName = "PromisedDate";
            this.ColPromisedDate.Name = "ColPromisedDate";
            this.ColPromisedDate.Visible = true;
            this.ColPromisedDate.VisibleIndex = 9;
            this.ColPromisedDate.Width = 55;
            // 
            // ColPriority
            // 
            this.ColPriority.Caption = "优先";
            this.ColPriority.FieldName = "Priority";
            this.ColPriority.Name = "ColPriority";
            this.ColPriority.Visible = true;
            this.ColPriority.VisibleIndex = 10;
            this.ColPriority.Width = 27;
            // 
            // ColNeedQty
            // 
            this.ColNeedQty.Caption = "要求数量";
            this.ColNeedQty.DisplayFormat.FormatString = "#,##0";
            this.ColNeedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColNeedQty.FieldName = "NeedQty";
            this.ColNeedQty.Name = "ColNeedQty";
            this.ColNeedQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColNeedQty.Visible = true;
            this.ColNeedQty.VisibleIndex = 11;
            this.ColNeedQty.Width = 62;
            // 
            // ColShippedQty
            // 
            this.ColShippedQty.Caption = "已交数量";
            this.ColShippedQty.DisplayFormat.FormatString = "#,##0";
            this.ColShippedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColShippedQty.FieldName = "ShippedQty";
            this.ColShippedQty.Name = "ColShippedQty";
            this.ColShippedQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColShippedQty.Visible = true;
            this.ColShippedQty.VisibleIndex = 12;
            this.ColShippedQty.Width = 64;
            // 
            // ColBalQty
            // 
            this.ColBalQty.Caption = "尚欠数量";
            this.ColBalQty.DisplayFormat.FormatString = "#,##0";
            this.ColBalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBalQty.FieldName = "BalQty";
            this.ColBalQty.Name = "ColBalQty";
            this.ColBalQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColBalQty.Visible = true;
            this.ColBalQty.VisibleIndex = 13;
            this.ColBalQty.Width = 65;
            // 
            // ColPendingShipQty
            // 
            this.ColPendingShipQty.Caption = "預備寄貨數";
            this.ColPendingShipQty.DisplayFormat.FormatString = "#,##0";
            this.ColPendingShipQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColPendingShipQty.FieldName = "PendingShipQty";
            this.ColPendingShipQty.Name = "ColPendingShipQty";
            this.ColPendingShipQty.Visible = true;
            this.ColPendingShipQty.VisibleIndex = 14;
            this.ColPendingShipQty.Width = 49;
            // 
            // ColIgnorePlanningReport
            // 
            this.ColIgnorePlanningReport.Caption = "Ignore";
            this.ColIgnorePlanningReport.FieldName = "IgnorePlanning";
            this.ColIgnorePlanningReport.Name = "ColIgnorePlanningReport";
            // 
            // btnLoadSalesOrder
            // 
            this.btnLoadSalesOrder.Location = new System.Drawing.Point(3, 8);
            this.btnLoadSalesOrder.Name = "btnLoadSalesOrder";
            this.btnLoadSalesOrder.Size = new System.Drawing.Size(134, 56);
            this.btnLoadSalesOrder.TabIndex = 8;
            this.btnLoadSalesOrder.Text = "Display Sales Order";
            this.btnLoadSalesOrder.Click += new System.EventHandler(this.btnLoadSalesOrder_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(793, 462);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnPriority);
            this.xtraTabPage1.Controls.Add(this.btnTestEF);
            this.xtraTabPage1.Controls.Add(this.btnShipment);
            this.xtraTabPage1.Controls.Add(this.btnTestStringSplit);
            this.xtraTabPage1.Controls.Add(this.txtStringList);
            this.xtraTabPage1.Controls.Add(this.simpleButton2);
            this.xtraTabPage1.Controls.Add(this.txtCartonNo);
            this.xtraTabPage1.Controls.Add(this.btnWHHistory);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.btnTestFunction);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.btnEnum);
            this.xtraTabPage1.Controls.Add(this.btnSOLines);
            this.xtraTabPage1.Controls.Add(this.btnIsNullOrEmpty);
            this.xtraTabPage1.Controls.Add(this.btnStringTest);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(787, 433);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtItemNo);
            this.xtraTabPage2.Controls.Add(this.btnLoadSalesOrder);
            this.xtraTabPage2.Controls.Add(this.gridControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(787, 433);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(188, 21);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(100, 20);
            this.txtItemNo.TabIndex = 10;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            ((System.ComponentModel.ISupportInitialize)(this.txtStringList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.SimpleButton btnEnum;
        private DevExpress.XtraEditors.SimpleButton btnTestFunction;
        private DevExpress.XtraEditors.SimpleButton btnWHHistory;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnTestEF;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderIndex;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColCustomerItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemName;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemType;
        private DevExpress.XtraGrid.Columns.GridColumn ColMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn ColNeedDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColPromisedDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColPriority;
        private DevExpress.XtraGrid.Columns.GridColumn ColNeedQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColShippedQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColBalQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColPendingShipQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColIgnorePlanningReport;
        private DevExpress.XtraEditors.SimpleButton btnLoadSalesOrder;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit txtItemNo;
    }
}