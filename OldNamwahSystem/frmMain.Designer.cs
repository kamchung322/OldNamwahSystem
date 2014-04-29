namespace OldNamwahSystem
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.navBarMain = new DevExpress.XtraNavBar.NavBarControl();
            this.barGroupFQC = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarFQCShipment = new DevExpress.XtraNavBar.NavBarItem();
            this.barGroupWH = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarShipmentExit = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarSOLine = new DevExpress.XtraNavBar.NavBarItem();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.navBarTest = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarMain
            // 
            this.navBarMain.ActiveGroup = this.barGroupFQC;
            this.navBarMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.barGroupFQC,
            this.barGroupWH,
            this.navBarGroup1});
            this.navBarMain.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarFQCShipment,
            this.navBarShipmentExit,
            this.navBarSOLine,
            this.navBarTest});
            this.navBarMain.Location = new System.Drawing.Point(0, 0);
            this.navBarMain.Name = "navBarMain";
            this.navBarMain.OptionsNavPane.ExpandedWidth = 150;
            this.navBarMain.Size = new System.Drawing.Size(150, 407);
            this.navBarMain.TabIndex = 0;
            // 
            // barGroupFQC
            // 
            this.barGroupFQC.Caption = "FQC";
            this.barGroupFQC.Expanded = true;
            this.barGroupFQC.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarFQCShipment)});
            this.barGroupFQC.Name = "barGroupFQC";
            // 
            // navBarFQCShipment
            // 
            this.navBarFQCShipment.Caption = "FQC派货";
            this.navBarFQCShipment.Name = "navBarFQCShipment";
            this.navBarFQCShipment.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarFQCShipment_LinkClicked);
            // 
            // barGroupWH
            // 
            this.barGroupWH.Caption = "货仓";
            this.barGroupWH.Expanded = true;
            this.barGroupWH.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarShipmentExit)});
            this.barGroupWH.Name = "barGroupWH";
            // 
            // navBarShipmentExit
            // 
            this.navBarShipmentExit.Caption = "寄货单出货";
            this.navBarShipmentExit.Name = "navBarShipmentExit";
            this.navBarShipmentExit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarShipmentExit_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "销售";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSOLine),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTest)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarSOLine
            // 
            this.navBarSOLine.Caption = "销售单";
            this.navBarSOLine.Name = "navBarSOLine";
            this.navBarSOLine.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarSOLine_LinkClicked);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // navBarTest
            // 
            this.navBarTest.Caption = "Test";
            this.navBarTest.Name = "navBarTest";
            this.navBarTest.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTest_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 407);
            this.Controls.Add(this.navBarMain);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "大货系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarMain;
        private DevExpress.XtraNavBar.NavBarGroup barGroupFQC;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraNavBar.NavBarGroup barGroupWH;
        private DevExpress.XtraNavBar.NavBarItem navBarFQCShipment;
        private DevExpress.XtraNavBar.NavBarItem navBarShipmentExit;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarSOLine;
        private DevExpress.XtraNavBar.NavBarItem navBarTest;

    }
}

