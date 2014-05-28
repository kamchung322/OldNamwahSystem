namespace OldNamwahSystem
{
    partial class frmSalesOrder
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkSplitOrder = new DevExpress.XtraEditors.CheckEdit();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomer = new DevExpress.XtraEditors.TextEdit();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.txtItemType = new DevExpress.XtraEditors.TextEdit();
            this.txtSalesOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.txtItemNo = new DevExpress.XtraEditors.TextEdit();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridSOLine = new DevExpress.XtraGrid.GridControl();
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
            this.ColPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSplitOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridSOLine);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(918, 358);
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkSplitOrder);
            this.layoutControl1.Controls.Add(this.txtTime);
            this.layoutControl1.Controls.Add(this.txtCustomer);
            this.layoutControl1.Controls.Add(this.cboStatus);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Controls.Add(this.txtItemType);
            this.layoutControl1.Controls.Add(this.txtSalesOrderNo);
            this.layoutControl1.Controls.Add(this.txtItemNo);
            this.layoutControl1.Controls.Add(this.btnReload);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(918, 100);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkSplitOrder
            // 
            this.chkSplitOrder.Location = new System.Drawing.Point(493, 60);
            this.chkSplitOrder.Name = "chkSplitOrder";
            this.chkSplitOrder.Properties.Caption = "要分单";
            this.chkSplitOrder.Size = new System.Drawing.Size(199, 19);
            this.chkSplitOrder.StyleController = this.layoutControl1;
            this.chkSplitOrder.TabIndex = 9;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(696, 62);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(210, 20);
            this.txtTime.StyleController = this.layoutControl1;
            this.txtTime.TabIndex = 8;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(63, 36);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(183, 20);
            this.txtCustomer.StyleController = this.layoutControl1;
            this.txtCustomer.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(544, 36);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboStatus.Size = new System.Drawing.Size(148, 20);
            this.cboStatus.StyleController = this.layoutControl1;
            this.cboStatus.TabIndex = 6;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(544, 12);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(148, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 3;
            // 
            // txtItemType
            // 
            this.txtItemType.Location = new System.Drawing.Point(747, 12);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(159, 20);
            this.txtItemType.StyleController = this.layoutControl1;
            this.txtItemType.TabIndex = 4;
            // 
            // txtSalesOrderNo
            // 
            this.txtSalesOrderNo.Location = new System.Drawing.Point(63, 12);
            this.txtSalesOrderNo.Name = "txtSalesOrderNo";
            this.txtSalesOrderNo.Size = new System.Drawing.Size(183, 20);
            this.txtSalesOrderNo.StyleController = this.layoutControl1;
            this.txtSalesOrderNo.TabIndex = 1;
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(301, 12);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(188, 20);
            this.txtItemNo.StyleController = this.layoutControl1;
            this.txtItemNo.TabIndex = 2;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(696, 36);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(210, 22);
            this.btnReload.StyleController = this.layoutControl1;
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "重新读取资料";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(918, 100);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSalesOrderNo;
            this.layoutControlItem1.CustomizationFormText = "销售单号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(238, 24);
            this.layoutControlItem1.Text = "销售单号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtItemNo;
            this.layoutControlItem2.CustomizationFormText = "本厂编码";
            this.layoutControlItem2.Location = new System.Drawing.Point(238, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(243, 80);
            this.layoutControlItem2.Text = "本厂编码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtItemType;
            this.layoutControlItem3.CustomizationFormText = "产品种类";
            this.layoutControlItem3.Location = new System.Drawing.Point(684, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(214, 24);
            this.layoutControlItem3.Text = "产品种类";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnReload;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(684, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(214, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtItemName;
            this.layoutControlItem5.CustomizationFormText = "产品名称";
            this.layoutControlItem5.Location = new System.Drawing.Point(481, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(203, 24);
            this.layoutControlItem5.Text = "产品名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cboStatus;
            this.layoutControlItem6.CustomizationFormText = "状态";
            this.layoutControlItem6.Location = new System.Drawing.Point(481, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(203, 24);
            this.layoutControlItem6.Text = "状态";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtCustomer;
            this.layoutControlItem7.CustomizationFormText = "人客";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(238, 56);
            this.layoutControlItem7.Text = "人客";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtTime;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(684, 50);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(214, 30);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.chkSplitOrder;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(481, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(203, 32);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // gridSOLine
            // 
            this.gridSOLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSOLine.Location = new System.Drawing.Point(0, 0);
            this.gridSOLine.MainView = this.gridView1;
            this.gridSOLine.Name = "gridSOLine";
            this.gridSOLine.Size = new System.Drawing.Size(918, 253);
            this.gridSOLine.TabIndex = 0;
            this.gridSOLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.ColShippedQty,
            this.ColBalQty,
            this.ColPrice});
            this.gridView1.GridControl = this.gridSOLine;
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
            // ColPrice
            // 
            this.ColPrice.Caption = "单价";
            this.ColPrice.DisplayFormat.FormatString = "#,##0.000";
            this.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColPrice.FieldName = "OurPrice";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.Visible = true;
            this.ColPrice.VisibleIndex = 14;
            this.ColPrice.Width = 49;
            // 
            // frmSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 358);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmSalesOrder";
            this.Text = "销售单资料";
            this.Load += new System.EventHandler(this.frmSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSplitOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridSOLine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.TextEdit txtItemType;
        private DevExpress.XtraEditors.TextEdit txtSalesOrderNo;
        private DevExpress.XtraEditors.TextEdit txtItemNo;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtCustomer;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
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
        private DevExpress.XtraEditors.TextEdit txtTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckEdit chkSplitOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn ColPrice;
    }
}