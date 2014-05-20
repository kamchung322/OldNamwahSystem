namespace OldNamwahSystem
{
    partial class frmManualLabel
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
            this.btnPrintBoxLabelManually = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.txtManualInspectSpec = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtManualInspectStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtManualMaterial = new DevExpress.XtraEditors.TextEdit();
            this.txtManualPartType = new DevExpress.XtraEditors.TextEdit();
            this.txtManualRevision = new DevExpress.XtraEditors.TextEdit();
            this.txtManualQty = new DevExpress.XtraEditors.TextEdit();
            this.txtManualPONo = new DevExpress.XtraEditors.TextEdit();
            this.txtManualPartName = new DevExpress.XtraEditors.TextEdit();
            this.txtManualPartNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualInspectSpec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualInspectStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualRevision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintBoxLabelManually
            // 
            this.btnPrintBoxLabelManually.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBoxLabelManually.Appearance.Options.UseFont = true;
            this.btnPrintBoxLabelManually.Location = new System.Drawing.Point(258, 177);
            this.btnPrintBoxLabelManually.Name = "btnPrintBoxLabelManually";
            this.btnPrintBoxLabelManually.Size = new System.Drawing.Size(133, 40);
            this.btnPrintBoxLabelManually.TabIndex = 41;
            this.btnPrintBoxLabelManually.Text = "打印大标签";
            this.btnPrintBoxLabelManually.Click += new System.EventHandler(this.btnPrintBoxLabelManually_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Location = new System.Drawing.Point(216, 153);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(60, 16);
            this.labelControl21.TabIndex = 37;
            this.labelControl21.Text = "检查状态";
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Location = new System.Drawing.Point(18, 153);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(60, 16);
            this.labelControl22.TabIndex = 34;
            this.labelControl22.Text = "桧查标准";
            // 
            // txtManualInspectSpec
            // 
            this.txtManualInspectSpec.EditValue = "Normal";
            this.txtManualInspectSpec.EnterMoveNextControl = true;
            this.txtManualInspectSpec.Location = new System.Drawing.Point(108, 147);
            this.txtManualInspectSpec.Name = "txtManualInspectSpec";
            this.txtManualInspectSpec.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualInspectSpec.Properties.Appearance.Options.UseFont = true;
            this.txtManualInspectSpec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtManualInspectSpec.Properties.Items.AddRange(new object[] {
            "Normal",
            "GP12"});
            this.txtManualInspectSpec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtManualInspectSpec.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtManualInspectSpec.Size = new System.Drawing.Size(96, 22);
            this.txtManualInspectSpec.TabIndex = 39;
            // 
            // txtManualInspectStatus
            // 
            this.txtManualInspectStatus.EditValue = "NRI";
            this.txtManualInspectStatus.EnterMoveNextControl = true;
            this.txtManualInspectStatus.Location = new System.Drawing.Point(293, 147);
            this.txtManualInspectStatus.Name = "txtManualInspectStatus";
            this.txtManualInspectStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualInspectStatus.Properties.Appearance.Options.UseFont = true;
            this.txtManualInspectStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtManualInspectStatus.Properties.Items.AddRange(new object[] {
            "NRI",
            "PRRI"});
            this.txtManualInspectStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtManualInspectStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtManualInspectStatus.Size = new System.Drawing.Size(97, 22);
            this.txtManualInspectStatus.TabIndex = 40;
            // 
            // txtManualMaterial
            // 
            this.txtManualMaterial.EnterMoveNextControl = true;
            this.txtManualMaterial.Location = new System.Drawing.Point(293, 87);
            this.txtManualMaterial.Name = "txtManualMaterial";
            this.txtManualMaterial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualMaterial.Properties.Appearance.Options.UseFont = true;
            this.txtManualMaterial.Size = new System.Drawing.Size(97, 22);
            this.txtManualMaterial.TabIndex = 35;
            // 
            // txtManualPartType
            // 
            this.txtManualPartType.EnterMoveNextControl = true;
            this.txtManualPartType.Location = new System.Drawing.Point(108, 87);
            this.txtManualPartType.Name = "txtManualPartType";
            this.txtManualPartType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualPartType.Properties.Appearance.Options.UseFont = true;
            this.txtManualPartType.Size = new System.Drawing.Size(97, 22);
            this.txtManualPartType.TabIndex = 33;
            // 
            // txtManualRevision
            // 
            this.txtManualRevision.EnterMoveNextControl = true;
            this.txtManualRevision.Location = new System.Drawing.Point(293, 26);
            this.txtManualRevision.Name = "txtManualRevision";
            this.txtManualRevision.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualRevision.Properties.Appearance.Options.UseFont = true;
            this.txtManualRevision.Size = new System.Drawing.Size(98, 22);
            this.txtManualRevision.TabIndex = 31;
            // 
            // txtManualQty
            // 
            this.txtManualQty.EnterMoveNextControl = true;
            this.txtManualQty.Location = new System.Drawing.Point(293, 117);
            this.txtManualQty.Name = "txtManualQty";
            this.txtManualQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualQty.Properties.Appearance.Options.UseFont = true;
            this.txtManualQty.Size = new System.Drawing.Size(97, 22);
            this.txtManualQty.TabIndex = 38;
            // 
            // txtManualPONo
            // 
            this.txtManualPONo.EnterMoveNextControl = true;
            this.txtManualPONo.Location = new System.Drawing.Point(108, 117);
            this.txtManualPONo.Name = "txtManualPONo";
            this.txtManualPONo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualPONo.Properties.Appearance.Options.UseFont = true;
            this.txtManualPONo.Size = new System.Drawing.Size(97, 22);
            this.txtManualPONo.TabIndex = 36;
            // 
            // txtManualPartName
            // 
            this.txtManualPartName.EnterMoveNextControl = true;
            this.txtManualPartName.Location = new System.Drawing.Point(109, 56);
            this.txtManualPartName.Name = "txtManualPartName";
            this.txtManualPartName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualPartName.Properties.Appearance.Options.UseFont = true;
            this.txtManualPartName.Size = new System.Drawing.Size(282, 22);
            this.txtManualPartName.TabIndex = 32;
            // 
            // txtManualPartNo
            // 
            this.txtManualPartNo.EnterMoveNextControl = true;
            this.txtManualPartNo.Location = new System.Drawing.Point(109, 26);
            this.txtManualPartNo.Name = "txtManualPartNo";
            this.txtManualPartNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManualPartNo.Properties.Appearance.Options.UseFont = true;
            this.txtManualPartNo.Size = new System.Drawing.Size(122, 22);
            this.txtManualPartNo.TabIndex = 30;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Location = new System.Drawing.Point(216, 90);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(30, 16);
            this.labelControl20.TabIndex = 25;
            this.labelControl20.Text = "材料";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Location = new System.Drawing.Point(215, 126);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(30, 16);
            this.labelControl19.TabIndex = 28;
            this.labelControl19.Text = "数量";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(18, 90);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(30, 16);
            this.labelControl14.TabIndex = 24;
            this.labelControl14.Text = "种类";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Location = new System.Drawing.Point(18, 123);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(31, 16);
            this.labelControl18.TabIndex = 27;
            this.labelControl18.Text = "PO号";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Location = new System.Drawing.Point(239, 30);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(30, 16);
            this.labelControl15.TabIndex = 23;
            this.labelControl15.Text = "版本";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(19, 63);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(60, 16);
            this.labelControl16.TabIndex = 29;
            this.labelControl16.Text = "产品名称";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(19, 33);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 16);
            this.labelControl17.TabIndex = 26;
            this.labelControl17.Text = "产品编码";
            // 
            // frmManualLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 352);
            this.Controls.Add(this.btnPrintBoxLabelManually);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.labelControl22);
            this.Controls.Add(this.txtManualInspectSpec);
            this.Controls.Add(this.txtManualInspectStatus);
            this.Controls.Add(this.txtManualMaterial);
            this.Controls.Add(this.txtManualPartType);
            this.Controls.Add(this.txtManualRevision);
            this.Controls.Add(this.txtManualQty);
            this.Controls.Add(this.txtManualPONo);
            this.Controls.Add(this.txtManualPartName);
            this.Controls.Add(this.txtManualPartNo);
            this.Controls.Add(this.labelControl20);
            this.Controls.Add(this.labelControl19);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl17);
            this.Name = "frmManualLabel";
            this.Text = "手工打印标签";
            ((System.ComponentModel.ISupportInitialize)(this.txtManualInspectSpec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualInspectStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualRevision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManualPartNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrintBoxLabelManually;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.ComboBoxEdit txtManualInspectSpec;
        private DevExpress.XtraEditors.ComboBoxEdit txtManualInspectStatus;
        private DevExpress.XtraEditors.TextEdit txtManualMaterial;
        private DevExpress.XtraEditors.TextEdit txtManualPartType;
        private DevExpress.XtraEditors.TextEdit txtManualRevision;
        private DevExpress.XtraEditors.TextEdit txtManualQty;
        private DevExpress.XtraEditors.TextEdit txtManualPONo;
        private DevExpress.XtraEditors.TextEdit txtManualPartName;
        private DevExpress.XtraEditors.TextEdit txtManualPartNo;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
    }
}