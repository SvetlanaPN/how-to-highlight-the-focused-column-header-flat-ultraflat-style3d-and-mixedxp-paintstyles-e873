using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AppearanceObject style;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.nwindDataSet.Customers);

            style = new AppearanceObject();
            style.BackColor = Color.Orange;
            style.Options.UseBackColor = true;
        }

        private void advBandedGridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            advBandedGridView1.InvalidateColumnHeader(e.PrevFocusedColumn);
            advBandedGridView1.InvalidateColumnHeader(e.FocusedColumn);
        }

        private void advBandedGridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == advBandedGridView1.FocusedColumn)
                e.Appearance.Assign(style);
            else
                e.Appearance.Assign(advBandedGridView1.Appearance.HeaderPanel);
        }
    }
}