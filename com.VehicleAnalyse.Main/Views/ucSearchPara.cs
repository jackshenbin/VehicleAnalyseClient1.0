using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucSearchPara : DevExpress.XtraEditors.XtraUserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected DevExpress.XtraEditors.ComboBoxEdit cmbBoxEdit;

        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        { get; set; }


        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

                public int SelectedIndex{
            get
            {
                if (cmbBoxEdit != null )
                {
                    var info = cmbBoxEdit.SelectedItem as VehiclePropertyInfo;
                    if(info!=null)
                    return info.ID;
                    
                }
                return -1;
            }
            set
            {
                if (cmbBoxEdit != null)
                {
                    foreach (VehiclePropertyInfo item in cmbBoxEdit.Properties.Items)
                    {
                        if (item != null && item.ID == value)
                            cmbBoxEdit.SelectedItem = item;
                    }
                    //cmbBoxEdit.SelectedIndex = value;
                }
            }
        }

        //[Bindable(true)]
        //public int SelectedIndex
        //{
        //    get
        //    {
        //        if (cmbBoxEdit != null)
        //        {
        //            return cmbBoxEdit.SelectedIndex;
        //        }
        //        return -1;
        //    }
        //    set
        //    {
        //        if (cmbBoxEdit != null)
        //        {
        //            cmbBoxEdit.SelectedIndex = value;
        //        }
        //    }
        //}

        public ucSearchPara()
        {
            InitializeComponent();
        }

        public virtual void Init(object para)
        {

        }

        public virtual void Update(object para)
        {

        }

        protected void RaisePropertyChangedEvent(PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
