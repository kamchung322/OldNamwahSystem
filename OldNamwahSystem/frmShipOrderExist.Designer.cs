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
        private DevExpress.XtraLayout.LayoutControlItem layoutReload;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.ColShipMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.txtResult = new DevExpress.XtraEditors.TextEdit();
            this.txtCartonNo = new DevExpress.XtraEditors.TextEdit();
            this.btnChangeToSea = new DevExpress.XtraEditors.SimpleButton();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtSalesOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.btnShipmentReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnTSIOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangeQty = new DevExpress.XtraEditors.SimpleButton();
            this.txtItemNo = new DevExpress.XtraEditors.TextEdit();
            this.txtBarcode = new DevExpress.XtraEditors.TextEdit();
            this.btnOtherCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangeToAir = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChangeQty = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSalesOrderNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutCartonNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutQty = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutShipmentReport = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutTSIOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutOtherCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChangeToAir = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutChangeToSea = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutReload = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutResult = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCartonNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutShipmentReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTSIOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutOtherCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeToAir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeToSea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutReload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ColShipMethod
            // 
            this.ColShipMethod.Caption = "寄货方式";
            this.ColShipMethod.FieldName = "ShipMethod";
            this.ColShipMethod.Name = "ColShipMethod";
            this.ColShipMethod.Visible = true;
            this.ColShipMethod.VisibleIndex = 8;
            this.ColShipMethod.Width = 45;
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
            this.splitContainerControl1.Size = new System.Drawing.Size(982, 461);
            this.splitContainerControl1.SplitterPosition = 156;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.txtTime);
            this.layoutControl1.Controls.Add(this.txtResult);
            this.layoutControl1.Controls.Add(this.txtCartonNo);
            this.layoutControl1.Controls.Add(this.btnChangeToSea);
            this.layoutControl1.Controls.Add(this.txtQty);
            this.layoutControl1.Controls.Add(this.txtSalesOrderNo);
            this.layoutControl1.Controls.Add(this.btnShipmentReport);
            this.layoutControl1.Controls.Add(this.btnTSIOK);
            this.layoutControl1.Controls.Add(this.btnChangeQty);
            this.layoutControl1.Controls.Add(this.txtItemNo);
            this.layoutControl1.Controls.Add(this.txtBarcode);
            this.layoutControl1.Controls.Add(this.btnOtherCustomer);
            this.layoutControl1.Controls.Add(this.btnChangeToAir);
            this.layoutControl1.Controls.Add(this.btnReload);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutQty,
            this.layoutItemNo,
            this.layoutSalesOrderNo});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(982, 156);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(733, 116);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(237, 20);
            this.txtTime.StyleController = this.layoutControl1;
            this.txtTime.TabIndex = 16;
            this.txtTime.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(63, 64);
            this.txtResult.Name = "txtResult";
            this.txtResult.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Properties.Appearance.Options.UseFont = true;
            this.txtResult.Properties.Appearance.Options.UseForeColor = true;
            this.txtResult.Properties.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(666, 46);
            this.txtResult.StyleController = this.layoutControl1;
            this.txtResult.TabIndex = 15;
            this.txtResult.TabStop = false;
            // 
            // txtCartonNo
            // 
            this.txtCartonNo.EditValue = "0";
            this.txtCartonNo.Location = new System.Drawing.Point(784, 12);
            this.txtCartonNo.Name = "txtCartonNo";
            this.txtCartonNo.Properties.ReadOnly = true;
            this.txtCartonNo.Size = new System.Drawing.Size(186, 20);
            this.txtCartonNo.StyleController = this.layoutControl1;
            this.txtCartonNo.TabIndex = 14;
            this.txtCartonNo.TabStop = false;
            // 
            // btnChangeToSea
            // 
            this.btnChangeToSea.Location = new System.Drawing.Point(733, 38);
            this.btnChangeToSea.Name = "btnChangeToSea";
            this.btnChangeToSea.Size = new System.Drawing.Size(237, 22);
            this.btnChangeToSea.StyleController = this.layoutControl1;
            this.btnChangeToSea.TabIndex = 7;
            this.btnChangeToSea.Text = "改寄船货";
            this.btnChangeToSea.Click += new System.EventHandler(this.btnChangeToSea_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(544, 64);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(185, 20);
            this.txtQty.StyleController = this.layoutControl1;
            this.txtQty.TabIndex = 10;
            // 
            // txtSalesOrderNo
            // 
            this.txtSalesOrderNo.Location = new System.Drawing.Point(63, 64);
            this.txtSalesOrderNo.Name = "txtSalesOrderNo";
            this.txtSalesOrderNo.Size = new System.Drawing.Size(666, 20);
            this.txtSalesOrderNo.StyleController = this.layoutControl1;
            this.txtSalesOrderNo.TabIndex = 8;
            // 
            // btnShipmentReport
            // 
            this.btnShipmentReport.Location = new System.Drawing.Point(493, 12);
            this.btnShipmentReport.Name = "btnShipmentReport";
            this.btnShipmentReport.Size = new System.Drawing.Size(236, 22);
            this.btnShipmentReport.StyleController = this.layoutControl1;
            this.btnShipmentReport.TabIndex = 3;
            this.btnShipmentReport.Text = "今天出货单";
            this.btnShipmentReport.Click += new System.EventHandler(this.btnShipmentReport_Click);
            // 
            // btnTSIOK
            // 
            this.btnTSIOK.Location = new System.Drawing.Point(252, 38);
            this.btnTSIOK.Name = "btnTSIOK";
            this.btnTSIOK.Size = new System.Drawing.Size(237, 22);
            this.btnTSIOK.StyleController = this.layoutControl1;
            this.btnTSIOK.TabIndex = 5;
            this.btnTSIOK.Text = "TSI OK";
            this.btnTSIOK.Click += new System.EventHandler(this.btnTSIOK_Click);
            // 
            // btnChangeQty
            // 
            this.btnChangeQty.Location = new System.Drawing.Point(12, 38);
            this.btnChangeQty.Name = "btnChangeQty";
            this.btnChangeQty.Size = new System.Drawing.Size(236, 22);
            this.btnChangeQty.StyleController = this.layoutControl1;
            this.btnChangeQty.TabIndex = 4;
            this.btnChangeQty.Text = "改数";
            this.btnChangeQty.Click += new System.EventHandler(this.btnChangeQty_Click);
            // 
            // txtItemNo
            // 
            this.txtItemNo.Location = new System.Drawing.Point(303, 64);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.Size = new System.Drawing.Size(426, 20);
            this.txtItemNo.StyleController = this.layoutControl1;
            this.txtItemNo.TabIndex = 9;
            // 
            // txtBarcode
            // 
            this.txtBarcode.EnterMoveNextControl = true;
            this.txtBarcode.Location = new System.Drawing.Point(63, 12);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(426, 20);
            this.txtBarcode.StyleController = this.layoutControl1;
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // btnOtherCustomer
            // 
            this.btnOtherCustomer.Location = new System.Drawing.Point(733, 64);
            this.btnOtherCustomer.Name = "btnOtherCustomer";
            this.btnOtherCustomer.Size = new System.Drawing.Size(237, 22);
            this.btnOtherCustomer.StyleController = this.layoutControl1;
            this.btnOtherCustomer.TabIndex = 13;
            this.btnOtherCustomer.Text = "手工扫单";
            this.btnOtherCustomer.Click += new System.EventHandler(this.btnOtherCustomer_Click);
            // 
            // btnChangeToAir
            // 
            this.btnChangeToAir.Location = new System.Drawing.Point(493, 38);
            this.btnChangeToAir.Name = "btnChangeToAir";
            this.btnChangeToAir.Size = new System.Drawing.Size(236, 22);
            this.btnChangeToAir.StyleController = this.layoutControl1;
            this.btnChangeToAir.TabIndex = 6;
            this.btnChangeToAir.Text = "改寄飞机货";
            this.btnChangeToAir.Click += new System.EventHandler(this.btnChangeToAir_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(733, 90);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(237, 22);
            this.btnReload.StyleController = this.layoutControl1;
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "重新读取资料";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutBarcode,
            this.layoutChangeQty,
            this.layoutCartonNo,
            this.layoutShipmentReport,
            this.layoutTSIOk,
            this.layoutOtherCustomer,
            this.layoutChangeToAir,
            this.layoutChangeToSea,
            this.layoutReload,
            this.layoutResult,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(982, 156);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutBarcode
            // 
            this.layoutBarcode.Control = this.txtBarcode;
            this.layoutBarcode.CustomizationFormText = "条码";
            this.layoutBarcode.Location = new System.Drawing.Point(0, 0);
            this.layoutBarcode.Name = "layoutBarcode";
            this.layoutBarcode.Size = new System.Drawing.Size(481, 26);
            this.layoutBarcode.Text = "条码";
            this.layoutBarcode.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutChangeQty
            // 
            this.layoutChangeQty.Control = this.btnChangeQty;
            this.layoutChangeQty.CustomizationFormText = "layoutChangeQty";
            this.layoutChangeQty.Location = new System.Drawing.Point(0, 26);
            this.layoutChangeQty.Name = "layoutChangeQty";
            this.layoutChangeQty.Size = new System.Drawing.Size(240, 26);
            this.layoutChangeQty.Text = "layoutChangeQty";
            this.layoutChangeQty.TextSize = new System.Drawing.Size(0, 0);
            this.layoutChangeQty.TextToControlDistance = 0;
            this.layoutChangeQty.TextVisible = false;
            // 
            // layoutSalesOrderNo
            // 
            this.layoutSalesOrderNo.Control = this.txtSalesOrderNo;
            this.layoutSalesOrderNo.CustomizationFormText = "销售单号";
            this.layoutSalesOrderNo.Location = new System.Drawing.Point(0, 52);
            this.layoutSalesOrderNo.Name = "layoutSalesOrderNo";
            this.layoutSalesOrderNo.Size = new System.Drawing.Size(721, 24);
            this.layoutSalesOrderNo.Text = "销售单号";
            this.layoutSalesOrderNo.TextSize = new System.Drawing.Size(48, 14);
            this.layoutSalesOrderNo.TextToControlDistance = 5;
            // 
            // layoutCartonNo
            // 
            this.layoutCartonNo.Control = this.txtCartonNo;
            this.layoutCartonNo.CustomizationFormText = "现在箱号";
            this.layoutCartonNo.Location = new System.Drawing.Point(721, 0);
            this.layoutCartonNo.Name = "layoutCartonNo";
            this.layoutCartonNo.Size = new System.Drawing.Size(241, 26);
            this.layoutCartonNo.Text = "现在箱号";
            this.layoutCartonNo.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutItemNo
            // 
            this.layoutItemNo.Control = this.txtItemNo;
            this.layoutItemNo.CustomizationFormText = "产品编码";
            this.layoutItemNo.Location = new System.Drawing.Point(240, 52);
            this.layoutItemNo.Name = "layoutItemNo";
            this.layoutItemNo.Size = new System.Drawing.Size(481, 24);
            this.layoutItemNo.Text = "产品编码";
            this.layoutItemNo.TextSize = new System.Drawing.Size(48, 14);
            this.layoutItemNo.TextToControlDistance = 5;
            // 
            // layoutQty
            // 
            this.layoutQty.Control = this.txtQty;
            this.layoutQty.CustomizationFormText = "数量";
            this.layoutQty.Location = new System.Drawing.Point(481, 52);
            this.layoutQty.Name = "layoutQty";
            this.layoutQty.Size = new System.Drawing.Size(240, 24);
            this.layoutQty.Text = "数量";
            this.layoutQty.TextSize = new System.Drawing.Size(48, 14);
            this.layoutQty.TextToControlDistance = 5;
            // 
            // layoutShipmentReport
            // 
            this.layoutShipmentReport.Control = this.btnShipmentReport;
            this.layoutShipmentReport.CustomizationFormText = "layoutShipmentReport";
            this.layoutShipmentReport.Location = new System.Drawing.Point(481, 0);
            this.layoutShipmentReport.Name = "layoutShipmentReport";
            this.layoutShipmentReport.Size = new System.Drawing.Size(240, 26);
            this.layoutShipmentReport.Text = "layoutShipmentReport";
            this.layoutShipmentReport.TextSize = new System.Drawing.Size(0, 0);
            this.layoutShipmentReport.TextToControlDistance = 0;
            this.layoutShipmentReport.TextVisible = false;
            // 
            // layoutTSIOk
            // 
            this.layoutTSIOk.Control = this.btnTSIOK;
            this.layoutTSIOk.CustomizationFormText = "layoutTSIOk";
            this.layoutTSIOk.Location = new System.Drawing.Point(240, 26);
            this.layoutTSIOk.Name = "layoutTSIOk";
            this.layoutTSIOk.Size = new System.Drawing.Size(241, 26);
            this.layoutTSIOk.Text = "layoutTSIOk";
            this.layoutTSIOk.TextSize = new System.Drawing.Size(0, 0);
            this.layoutTSIOk.TextToControlDistance = 0;
            this.layoutTSIOk.TextVisible = false;
            // 
            // layoutOtherCustomer
            // 
            this.layoutOtherCustomer.Control = this.btnOtherCustomer;
            this.layoutOtherCustomer.CustomizationFormText = "layoutOtherCustomer";
            this.layoutOtherCustomer.Location = new System.Drawing.Point(721, 52);
            this.layoutOtherCustomer.Name = "layoutOtherCustomer";
            this.layoutOtherCustomer.Size = new System.Drawing.Size(241, 26);
            this.layoutOtherCustomer.Text = "layoutOtherCustomer";
            this.layoutOtherCustomer.TextSize = new System.Drawing.Size(0, 0);
            this.layoutOtherCustomer.TextToControlDistance = 0;
            this.layoutOtherCustomer.TextVisible = false;
            // 
            // layoutChangeToAir
            // 
            this.layoutChangeToAir.Control = this.btnChangeToAir;
            this.layoutChangeToAir.CustomizationFormText = "layoutChangeToAir";
            this.layoutChangeToAir.Location = new System.Drawing.Point(481, 26);
            this.layoutChangeToAir.Name = "layoutChangeToAir";
            this.layoutChangeToAir.Size = new System.Drawing.Size(240, 26);
            this.layoutChangeToAir.Text = "layoutChangeToAir";
            this.layoutChangeToAir.TextSize = new System.Drawing.Size(0, 0);
            this.layoutChangeToAir.TextToControlDistance = 0;
            this.layoutChangeToAir.TextVisible = false;
            // 
            // layoutChangeToSea
            // 
            this.layoutChangeToSea.Control = this.btnChangeToSea;
            this.layoutChangeToSea.CustomizationFormText = "layoutChangeToSea";
            this.layoutChangeToSea.Location = new System.Drawing.Point(721, 26);
            this.layoutChangeToSea.Name = "layoutChangeToSea";
            this.layoutChangeToSea.Size = new System.Drawing.Size(241, 26);
            this.layoutChangeToSea.Text = "layoutChangeToSea";
            this.layoutChangeToSea.TextSize = new System.Drawing.Size(0, 0);
            this.layoutChangeToSea.TextToControlDistance = 0;
            this.layoutChangeToSea.TextVisible = false;
            // 
            // layoutReload
            // 
            this.layoutReload.Control = this.btnReload;
            this.layoutReload.CustomizationFormText = "layoutControlItem1";
            this.layoutReload.Location = new System.Drawing.Point(721, 78);
            this.layoutReload.Name = "layoutReload";
            this.layoutReload.Size = new System.Drawing.Size(241, 26);
            this.layoutReload.Text = "layoutReload";
            this.layoutReload.TextSize = new System.Drawing.Size(0, 0);
            this.layoutReload.TextToControlDistance = 0;
            this.layoutReload.TextVisible = false;
            // 
            // layoutResult
            // 
            this.layoutResult.Control = this.txtResult;
            this.layoutResult.CustomizationFormText = "系统信息";
            this.layoutResult.Location = new System.Drawing.Point(0, 52);
            this.layoutResult.Name = "layoutResult";
            this.layoutResult.Size = new System.Drawing.Size(721, 84);
            this.layoutResult.Text = "系统信息";
            this.layoutResult.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtTime;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(721, 104);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(241, 32);
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
            this.gridShipment.Size = new System.Drawing.Size(982, 300);
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
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.ColShipMethod;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "Sea";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
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
            this.ColMoveDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColMoveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColMoveDate.FieldName = "MoveDate";
            this.ColMoveDate.Name = "ColMoveDate";
            this.ColMoveDate.Visible = true;
            this.ColMoveDate.VisibleIndex = 7;
            this.ColMoveDate.Width = 57;
            // 
            // ColSalesOrderNo
            // 
            this.ColSalesOrderNo.Caption = "销售单号";
            this.ColSalesOrderNo.FieldName = "SalesOrderNo";
            this.ColSalesOrderNo.Name = "ColSalesOrderNo";
            this.ColSalesOrderNo.Visible = true;
            this.ColSalesOrderNo.VisibleIndex = 9;
            this.ColSalesOrderNo.Width = 56;
            // 
            // ColSalesOrderIndex
            // 
            this.ColSalesOrderIndex.Caption = "Index";
            this.ColSalesOrderIndex.FieldName = "SalesOrderIndex";
            this.ColSalesOrderIndex.MinWidth = 10;
            this.ColSalesOrderIndex.Name = "ColSalesOrderIndex";
            this.ColSalesOrderIndex.Visible = true;
            this.ColSalesOrderIndex.VisibleIndex = 10;
            this.ColSalesOrderIndex.Width = 13;
            // 
            // ColCustomer
            // 
            this.ColCustomer.Caption = "人客";
            this.ColCustomer.FieldName = "Customer";
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.Visible = true;
            this.ColCustomer.VisibleIndex = 11;
            this.ColCustomer.Width = 38;
            // 
            // ColCarton
            // 
            this.ColCarton.Caption = "箱号";
            this.ColCarton.FieldName = "Carton";
            this.ColCarton.Name = "ColCarton";
            this.ColCarton.Visible = true;
            this.ColCarton.VisibleIndex = 12;
            this.ColCarton.Width = 54;
            // 
            // ColOrderDate
            // 
            this.ColOrderDate.Caption = "建立日期";
            this.ColOrderDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ColOrderDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ColOrderDate.FieldName = "OrderDate";
            this.ColOrderDate.Name = "ColOrderDate";
            this.ColOrderDate.Visible = true;
            this.ColOrderDate.VisibleIndex = 13;
            this.ColOrderDate.Width = 82;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 461);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmShipOrderExist";
            this.Text = "寄货单出货";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmShipOrderExist_FormClosed);
            this.Load += new System.EventHandler(this.frmShipOrderExist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCartonNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutCartonNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutShipmentReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTSIOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutOtherCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeToAir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutChangeToSea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutReload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.TextEdit txtItemNo;
        private DevExpress.XtraEditors.TextEdit txtSalesOrderNo;
        private DevExpress.XtraEditors.SimpleButton btnShipmentReport;
        private DevExpress.XtraEditors.SimpleButton btnTSIOK;
        private DevExpress.XtraEditors.SimpleButton btnChangeQty;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutChangeQty;
        private DevExpress.XtraLayout.LayoutControlItem layoutTSIOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutShipmentReport;
        private DevExpress.XtraLayout.LayoutControlItem layoutSalesOrderNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutQty;
        private DevExpress.XtraEditors.SimpleButton btnChangeToSea;
        private DevExpress.XtraEditors.SimpleButton btnChangeToAir;
        private DevExpress.XtraLayout.LayoutControlItem layoutChangeToAir;
        private DevExpress.XtraLayout.LayoutControlItem layoutChangeToSea;
        private DevExpress.XtraEditors.SimpleButton btnOtherCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutOtherCustomer;
        private DevExpress.XtraEditors.TextEdit txtCartonNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutCartonNo;
        private DevExpress.XtraEditors.TextEdit txtResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutResult;
        private DevExpress.XtraEditors.TextEdit txtTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}