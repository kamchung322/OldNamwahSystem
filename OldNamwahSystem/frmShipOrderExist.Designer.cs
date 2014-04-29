namespace OldNamwahSystem
{
    partial class frmShipOrderExist
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
        ///

        private DevExpress.XtraGrid.GridControl gridShipment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ColShipOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColCustomerItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemName;
        private DevExpress.XtraGrid.Columns.GridColumn ColItemType;
        private DevExpress.XtraGrid.Columns.GridColumn ColMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn ColMoveQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColArrivedQty;
        private DevExpress.XtraGrid.Columns.GridColumn ColMoveDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColShipMethod;
        private DevExpress.XtraGrid.Columns.GridColumn ColSalesOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColSalesOrderIndex;
        private DevExpress.XtraGrid.Columns.GridColumn ColCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn ColCarton;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderStatus;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridShipment = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColShipOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCustomerItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMoveQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColArrivedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMoveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColShipMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColSalesOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColSalesOrderIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCarton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gridShipment);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(842, 428);
            this.splitContainerControl1.SplitterPosition = 150;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.btnReload);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(842, 150);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(12, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(818, 22);
            this.btnReload.StyleController = this.layoutControl1;
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "重新读取";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 150);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnReload;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(822, 130);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridShipment
            // 
            this.gridShipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridShipment.Location = new System.Drawing.Point(0, 0);
            this.gridShipment.MainView = this.gridView1;
            this.gridShipment.Name = "gridShipment";
            this.gridShipment.Size = new System.Drawing.Size(842, 273);
            this.gridShipment.TabIndex = 0;
            this.gridShipment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColShipOrderNo,
            this.ColItemNo,
            this.ColCustomerItemNo,
            this.ColItemName,
            this.ColItemType,
            this.ColMaterial,
            this.ColMoveQty,
            this.ColArrivedQty,
            this.ColMoveDate,
            this.ColShipMethod,
            this.ColSalesOrderNo,
            this.ColSalesOrderIndex,
            this.ColCustomer,
            this.ColCarton,
            this.ColOrderDate,
            this.ColOrderStatus});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.ColShipMethod;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "Sea";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridShipment;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColOrderStatus, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColShipOrderNo
            // 
            this.ColShipOrderNo.Caption = "寄货单号";
            this.ColShipOrderNo.FieldName = "OrderNo";
            this.ColShipOrderNo.Name = "ColShipOrderNo";
            this.ColShipOrderNo.Visible = true;
            this.ColShipOrderNo.VisibleIndex = 0;
            this.ColShipOrderNo.Width = 86;
            // 
            // ColItemNo
            // 
            this.ColItemNo.Caption = "本厂编码";
            this.ColItemNo.FieldName = "ItemNo";
            this.ColItemNo.Name = "ColItemNo";
            this.ColItemNo.Width = 50;
            // 
            // ColCustomerItemNo
            // 
            this.ColCustomerItemNo.Caption = "人客编码";
            this.ColCustomerItemNo.FieldName = "CustomerItemNo";
            this.ColCustomerItemNo.Name = "ColCustomerItemNo";
            this.ColCustomerItemNo.Visible = true;
            this.ColCustomerItemNo.VisibleIndex = 1;
            this.ColCustomerItemNo.Width = 79;
            // 
            // ColItemName
            // 
            this.ColItemName.Caption = "产品名称";
            this.ColItemName.FieldName = "ItemName";
            this.ColItemName.Name = "ColItemName";
            this.ColItemName.Visible = true;
            this.ColItemName.VisibleIndex = 2;
            this.ColItemName.Width = 110;
            // 
            // ColItemType
            // 
            this.ColItemType.Caption = "产品种类";
            this.ColItemType.FieldName = "ItemType";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.Visible = true;
            this.ColItemType.VisibleIndex = 3;
            this.ColItemType.Width = 56;
            // 
            // ColMaterial
            // 
            this.ColMaterial.Caption = "材料";
            this.ColMaterial.FieldName = "Material";
            this.ColMaterial.Name = "ColMaterial";
            this.ColMaterial.Visible = true;
            this.ColMaterial.VisibleIndex = 4;
            this.ColMaterial.Width = 56;
            // 
            // ColMoveQty
            // 
            this.ColMoveQty.Caption = "寄货数";
            this.ColMoveQty.DisplayFormat.FormatString = "#,###";
            this.ColMoveQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColMoveQty.FieldName = "MoveQty";
            this.ColMoveQty.Name = "ColMoveQty";
            this.ColMoveQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColMoveQty.Visible = true;
            this.ColMoveQty.VisibleIndex = 5;
            this.ColMoveQty.Width = 46;
            // 
            // ColArrivedQty
            // 
            this.ColArrivedQty.Caption = "已装箱数";
            this.ColArrivedQty.DisplayFormat.FormatString = "#,###";
            this.ColArrivedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColArrivedQty.FieldName = "ArrivedQty";
            this.ColArrivedQty.Name = "ColArrivedQty";
            this.ColArrivedQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColArrivedQty.Visible = true;
            this.ColArrivedQty.VisibleIndex = 6;
            this.ColArrivedQty.Width = 46;
            // 
            // ColMoveDate
            // 
            this.ColMoveDate.Caption = "寄货日期";
            this.ColMoveDate.FieldName = "MoveDate";
            this.ColMoveDate.Name = "ColMoveDate";
            this.ColMoveDate.Visible = true;
            this.ColMoveDate.VisibleIndex = 7;
            this.ColMoveDate.Width = 57;
            // 
            // ColShipMethod
            // 
            this.ColShipMethod.Caption = "寄货方式";
            this.ColShipMethod.FieldName = "ShipMethod";
            this.ColShipMethod.Name = "ColShipMethod";
            this.ColShipMethod.Visible = true;
            this.ColShipMethod.VisibleIndex = 8;
            this.ColShipMethod.Width = 35;
            // 
            // ColSalesOrderNo
            // 
            this.ColSalesOrderNo.Caption = "销售单号";
            this.ColSalesOrderNo.FieldName = "SalesOrderNo";
            this.ColSalesOrderNo.Name = "ColSalesOrderNo";
            this.ColSalesOrderNo.Visible = true;
            this.ColSalesOrderNo.VisibleIndex = 9;
            this.ColSalesOrderNo.Width = 46;
            // 
            // ColSalesOrderIndex
            // 
            this.ColSalesOrderIndex.Caption = "Index";
            this.ColSalesOrderIndex.FieldName = "SalesOrderIndex";
            this.ColSalesOrderIndex.MinWidth = 10;
            this.ColSalesOrderIndex.Name = "ColSalesOrderIndex";
            this.ColSalesOrderIndex.Visible = true;
            this.ColSalesOrderIndex.VisibleIndex = 10;
            this.ColSalesOrderIndex.Width = 10;
            // 
            // ColCustomer
            // 
            this.ColCustomer.Caption = "人客";
            this.ColCustomer.FieldName = "Customer";
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.Visible = true;
            this.ColCustomer.VisibleIndex = 11;
            this.ColCustomer.Width = 46;
            // 
            // ColCarton
            // 
            this.ColCarton.Caption = "箱号";
            this.ColCarton.FieldName = "Carton";
            this.ColCarton.Name = "ColCarton";
            this.ColCarton.Visible = true;
            this.ColCarton.VisibleIndex = 12;
            this.ColCarton.Width = 65;
            // 
            // ColOrderDate
            // 
            this.ColOrderDate.Caption = "建立日期";
            this.ColOrderDate.DisplayFormat.FormatString = "d";
            this.ColOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColOrderDate.FieldName = "OrderDate";
            this.ColOrderDate.Name = "ColOrderDate";
            this.ColOrderDate.Visible = true;
            this.ColOrderDate.VisibleIndex = 13;
            this.ColOrderDate.Width = 86;
            // 
            // ColOrderStatus
            // 
            this.ColOrderStatus.Caption = "状态";
            this.ColOrderStatus.FieldName = "OrderStatus";
            this.ColOrderStatus.Name = "ColOrderStatus";
            this.ColOrderStatus.Visible = true;
            this.ColOrderStatus.VisibleIndex = 15;
            // 
            // frmShipOrderExist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 428);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmShipOrderExist";
            this.Text = "寄货单出货";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}