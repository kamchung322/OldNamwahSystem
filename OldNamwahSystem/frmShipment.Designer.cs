namespace OldNamwahSystem
{
    partial class frmShipment
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
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
            this.ColPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCarton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.btnLoadWH = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cboStatus);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtTime);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnLoadWH);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridShipment);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(840, 418);
            this.splitContainerControl1.SplitterPosition = 67;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridShipment
            // 
            this.gridShipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridShipment.Location = new System.Drawing.Point(0, 0);
            this.gridShipment.MainView = this.gridView1;
            this.gridShipment.Name = "gridShipment";
            this.gridShipment.Size = new System.Drawing.Size(840, 346);
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
            this.ColPrice,
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColOrderDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // ColShipOrderNo
            // 
            this.ColShipOrderNo.Caption = "寄货单号";
            this.ColShipOrderNo.FieldName = "OrderNo";
            this.ColShipOrderNo.Name = "ColShipOrderNo";
            this.ColShipOrderNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.ColShipOrderNo.Visible = true;
            this.ColShipOrderNo.VisibleIndex = 0;
            this.ColShipOrderNo.Width = 74;
            // 
            // ColItemNo
            // 
            this.ColItemNo.Caption = "本厂编码";
            this.ColItemNo.FieldName = "ItemNo";
            this.ColItemNo.Name = "ColItemNo";
            this.ColItemNo.Visible = true;
            this.ColItemNo.VisibleIndex = 1;
            // 
            // ColCustomerItemNo
            // 
            this.ColCustomerItemNo.Caption = "人客编码";
            this.ColCustomerItemNo.FieldName = "CustomerItemNo";
            this.ColCustomerItemNo.Name = "ColCustomerItemNo";
            this.ColCustomerItemNo.Visible = true;
            this.ColCustomerItemNo.VisibleIndex = 2;
            this.ColCustomerItemNo.Width = 64;
            // 
            // ColItemName
            // 
            this.ColItemName.Caption = "产品名称";
            this.ColItemName.FieldName = "ItemName";
            this.ColItemName.Name = "ColItemName";
            this.ColItemName.Visible = true;
            this.ColItemName.VisibleIndex = 3;
            this.ColItemName.Width = 90;
            // 
            // ColItemType
            // 
            this.ColItemType.Caption = "产品种类";
            this.ColItemType.FieldName = "ItemType";
            this.ColItemType.Name = "ColItemType";
            this.ColItemType.Visible = true;
            this.ColItemType.VisibleIndex = 4;
            this.ColItemType.Width = 45;
            // 
            // ColMaterial
            // 
            this.ColMaterial.Caption = "材料";
            this.ColMaterial.FieldName = "Material";
            this.ColMaterial.Name = "ColMaterial";
            this.ColMaterial.Visible = true;
            this.ColMaterial.VisibleIndex = 5;
            this.ColMaterial.Width = 45;
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
            this.ColMoveQty.VisibleIndex = 6;
            this.ColMoveQty.Width = 37;
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
            this.ColArrivedQty.VisibleIndex = 7;
            this.ColArrivedQty.Width = 37;
            // 
            // ColMoveDate
            // 
            this.ColMoveDate.Caption = "寄货日期";
            this.ColMoveDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColMoveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColMoveDate.FieldName = "MoveDate";
            this.ColMoveDate.Name = "ColMoveDate";
            this.ColMoveDate.Visible = true;
            this.ColMoveDate.VisibleIndex = 8;
            this.ColMoveDate.Width = 46;
            // 
            // ColShipMethod
            // 
            this.ColShipMethod.Caption = "寄货方式";
            this.ColShipMethod.FieldName = "ShipMethod";
            this.ColShipMethod.Name = "ColShipMethod";
            this.ColShipMethod.Visible = true;
            this.ColShipMethod.VisibleIndex = 9;
            this.ColShipMethod.Width = 36;
            // 
            // ColSalesOrderNo
            // 
            this.ColSalesOrderNo.Caption = "销售单号";
            this.ColSalesOrderNo.FieldName = "SalesOrderNo";
            this.ColSalesOrderNo.Name = "ColSalesOrderNo";
            this.ColSalesOrderNo.Visible = true;
            this.ColSalesOrderNo.VisibleIndex = 10;
            this.ColSalesOrderNo.Width = 25;
            // 
            // ColSalesOrderIndex
            // 
            this.ColSalesOrderIndex.Caption = "Index";
            this.ColSalesOrderIndex.FieldName = "SalesOrderIndex";
            this.ColSalesOrderIndex.MinWidth = 10;
            this.ColSalesOrderIndex.Name = "ColSalesOrderIndex";
            this.ColSalesOrderIndex.Visible = true;
            this.ColSalesOrderIndex.VisibleIndex = 11;
            this.ColSalesOrderIndex.Width = 11;
            // 
            // ColPrice
            // 
            this.ColPrice.Caption = "单价";
            this.ColPrice.DisplayFormat.FormatString = "#,##0";
            this.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColPrice.FieldName = "OurPrice";
            this.ColPrice.Name = "ColPrice";
            // 
            // ColCustomer
            // 
            this.ColCustomer.Caption = "人客";
            this.ColCustomer.FieldName = "Customer";
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.Visible = true;
            this.ColCustomer.VisibleIndex = 12;
            this.ColCustomer.Width = 35;
            // 
            // ColCarton
            // 
            this.ColCarton.Caption = "箱号";
            this.ColCarton.FieldName = "Carton";
            this.ColCarton.Name = "ColCarton";
            this.ColCarton.Visible = true;
            this.ColCarton.VisibleIndex = 13;
            this.ColCarton.Width = 69;
            // 
            // ColOrderDate
            // 
            this.ColOrderDate.Caption = "建立日期";
            this.ColOrderDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColOrderDate.FieldName = "OrderDate";
            this.ColOrderDate.Name = "ColOrderDate";
            this.ColOrderDate.Visible = true;
            this.ColOrderDate.VisibleIndex = 15;
            this.ColOrderDate.Width = 66;
            // 
            // ColOrderStatus
            // 
            this.ColOrderStatus.Caption = "状态";
            this.ColOrderStatus.FieldName = "OrderStatus";
            this.ColOrderStatus.Name = "ColOrderStatus";
            this.ColOrderStatus.Visible = true;
            this.ColOrderStatus.VisibleIndex = 14;
            this.ColOrderStatus.Width = 67;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(333, 37);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(237, 20);
            this.txtTime.TabIndex = 20;
            this.txtTime.TabStop = false;
            // 
            // btnLoadWH
            // 
            this.btnLoadWH.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadWH.Appearance.Options.UseFont = true;
            this.btnLoadWH.Location = new System.Drawing.Point(22, 17);
            this.btnLoadWH.Name = "btnLoadWH";
            this.btnLoadWH.Size = new System.Drawing.Size(133, 40);
            this.btnLoadWH.TabIndex = 19;
            this.btnLoadWH.Text = "重新读取资料";
            this.btnLoadWH.Click += new System.EventHandler(this.btnLoadWH_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(181, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "狀态";
            // 
            // cboStatus
            // 
            this.cboStatus.EditValue = "未寄货";
            this.cboStatus.Location = new System.Drawing.Point(227, 37);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.Items.AddRange(new object[] {
            "所有",
            "未寄货"});
            this.cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboStatus.Size = new System.Drawing.Size(100, 20);
            this.cboStatus.TabIndex = 22;
            // 
            // frmShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 418);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmShipment";
            this.Text = "寄货单资料";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
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
        private DevExpress.XtraGrid.Columns.GridColumn ColPrice;
        private DevExpress.XtraGrid.Columns.GridColumn ColCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn ColCarton;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColOrderStatus;
        private DevExpress.XtraEditors.TextEdit txtTime;
        private DevExpress.XtraEditors.SimpleButton btnLoadWH;
        private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}