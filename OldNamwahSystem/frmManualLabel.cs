using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OldNamwahSystem.Label;
namespace OldNamwahSystem
{
    public partial class frmManualLabel : XtraForm
    {
        public frmManualLabel()
        {
            InitializeComponent();
        }

        private void btnPrintBoxLabelManually_Click(object sender, EventArgs e)
        {
            try
            {
                BoxLabel BoxLabel = new Label.BoxLabel();

                if (BoxLabel.IsReady == false)
                {
                    XtraMessageBox.Show("打印机出现问题, 不能打印, 请重启打印机 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BoxLabel.ItemNo = txtManualPartNo.Text;
                BoxLabel.ItemName = txtManualPartName.Text;
                BoxLabel.ItemType = txtManualPartType.Text;
                BoxLabel.Material = txtManualMaterial.Text;
                BoxLabel.InspectSpec = txtManualInspectSpec.Text;
                BoxLabel.InspectStatus = txtManualInspectStatus.Text;
                BoxLabel.SalesOrderNo = txtManualPONo.Text;
                BoxLabel.ShipQty = int.Parse(txtManualQty.Text);
                BoxLabel.Revision = txtManualRevision.Text;

                BoxLabel.PrintLabel();
                BoxLabel = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("不能列印, 请检查输入的资料是否正确 !!\n原因 : {0}", ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}