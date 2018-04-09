using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.VehicleAnalyse.Main.Views;
using DevExpress.XtraEditors;
using VehicleHelper.ViewModels;
using VehicleHelper.DAO;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using VehicleHelper.DataModel;

namespace VehicleHelper
{
    public partial class ucSelectVehicleModel : UserControl
    {
        #region events
        
        public event EventHandler ToShowPopup;
        public event EventHandler ToHidePopup;

        public event EventHandler Popup;
        public event EventHandler Close;

        public event EventHandler SelectedItemChanged;
        public event EventHandler SelectedBrandChanged;
        
        #endregion

        #region Fields

        private CheckedListBoxControl m_listBoxVehicleModel;

        private SelectVehicleModelViewModel m_ViewModel;

        private VehicleModelInfo m_SelectedItem;

        private bool m_ShowNoLogoBrand = true;

        #endregion

        #region Properties
        
        public VehicleModelInfo SelectedItem
        {
            get { return m_SelectedItem; }
        }

        public VehicleBrandInfo Brand
        {
            get
            {
                return this.m_ViewModel.Brand;
            }
        }

        public bool SelectAllVehicleModels
        {
            get
            {
                return m_ViewModel.SelectAllVehicleModels;
            }
        }

        public VehicleBrandInfo[] CheckedVehicleModels
        {
            get
            {
                return m_ViewModel.CheckedVehicleModels;
            }
        }

        public bool ShowNoLogoBrand
        {
            get { return m_ShowNoLogoBrand; }
            set { m_ShowNoLogoBrand = value; }
        }

        #endregion

        public ucSelectVehicleModel()
        {
            InitializeComponent();
            // this.checkedComboBoxEdit1.Properties.PopupFormSize = new Size(160, 100);
        }

        private void FillupVehicleModels()
        {
            bool hasModel = m_ViewModel.VehicleModels != null && m_ViewModel.VehicleModels.Length > 0;
            checkedComboBoxEdit1.Enabled = hasModel;
            if (hasModel)
            {
                foreach (VehicleBrandInfo model in m_ViewModel.VehicleModels)
                {
                    checkedComboBoxEdit1.Properties.Items.Add(new VehicleModelInfo(model), CheckState.Checked);
                }
            }
        }

        public void Init()
        {
            if (m_ViewModel == null)
            {
                m_ViewModel = new SelectVehicleModelViewModel();

                checkedComboBoxEdit1.Enabled = false;
                checkedComboBoxEdit1.Properties.SeparatorChar = '@';
            }
        }

        #region Event handlers
        
        private void pictureCarStyle_Click(object sender, EventArgs e)
        {
            using (FormCarStyle dlg = new FormCarStyle())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Init(ShowNoLogoBrand);
                dlg.SelectImage = pictureCarStyle.Image;
                dlg.TopMost = true;
                if (ToHidePopup != null)
                {
                    ToHidePopup(this, EventArgs.Empty);
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if(pictureCarStyle.Image.Tag == dlg.SelectImage.Tag)
                    {
                        return;
                    }
                    
                    if (dlg.SelectImage != null && dlg.SelectImage.Tag != null)
                    {
                        VehicleBrandInfo brand = dlg.SelectImage.Tag as VehicleBrandInfo;
                        if(pictureCarStyle.Image != null && pictureCarStyle.Image.Tag != null)
                        {
                            if (((VehicleBrandInfo)pictureCarStyle.Image.Tag).ID == brand.ID)
                            {
                                return;
                            }
                        }
                        pictureCarStyle.Image = new Bitmap(dlg.SelectImage);
                        pictureCarStyle.Image.Tag = brand;
                        m_ViewModel.Brand = brand;
                        m_listBoxVehicleModel = null;
                        checkedComboBoxEdit1.Properties.Items.Clear();
                        FillupVehicleModels();
                    }
                    else
                    {
                        pictureCarStyle.Image = new Bitmap(dlg.SelectImage);
                        m_ViewModel.Brand = null;
                        m_listBoxVehicleModel = null;
                        checkedComboBoxEdit1.Properties.Items.Clear();
                        checkedComboBoxEdit1.Enabled = false;
                    }
                    m_ViewModel.SelectAllVehicleModels = true;
                }
                this.pictureCarStyle.Focus();

                if (ToShowPopup != null)
                {
                    ToShowPopup(this, EventArgs.Empty);
                }
            }

            if (SelectedBrandChanged != null)
            {
                SelectedBrandChanged(this, EventArgs.Empty);
            }
        }

        private void checkedComboBoxEdit1_Popup(object sender, EventArgs e)
        {
            PopupContainerForm form = (sender as IPopupControl).PopupWindow as PopupContainerForm;

            (form.Controls[3].Controls[0] as CheckedListBoxControl).SelectedIndexChanged += new EventHandler(Dropdown_SelectedIndexChanged);

            if (m_listBoxVehicleModel == null)
            {
                m_listBoxVehicleModel = ((this.checkedComboBoxEdit1 as IPopupControl).PopupWindow as PopupContainerForm).Controls[3].Controls[0] as CheckedListBoxControl;
            }
        }

        private void checkedComboBoxEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            PopupContainerForm form = (sender as IPopupControl).PopupWindow as PopupContainerForm;
            (form.Controls[3].Controls[0] as CheckedListBoxControl).SelectedIndexChanged -= new EventHandler(Dropdown_SelectedIndexChanged);

            if (checkedComboBoxEdit1.Enabled)
            {
                List<VehicleBrandInfo> models = new List<VehicleBrandInfo>();

                if (checkedComboBoxEdit1.Properties.GetCheckedItems().ToString().Split(checkedComboBoxEdit1.Properties.SeparatorChar).Length ==
                    checkedComboBoxEdit1.Properties.Items.Count)
                {
                    m_ViewModel.SelectAllVehicleModels = true;
                }
                else
                {
                    m_ViewModel.SelectAllVehicleModels = false;
                    foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.Items)
                    {
                        if (item.CheckState == CheckState.Checked)
                        {
                            models.Add((item.Value as VehicleModelInfo).Model);
                        }
                    }
                }
                m_ViewModel.CheckedVehicleModels = models.ToArray();
            }
            if (Close != null)
            {
                Close(this, EventArgs.Empty);
            }
        }

        void Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseListBoxControl listCtrl = sender as BaseListBoxControl;

            if (listCtrl.SelectedIndex == 0)
            {
                m_SelectedItem = null;
                // return;
            }
            else if (listCtrl != null && listCtrl.SelectedItem != null)
            {
                ListBoxItem listBoxItem = (ListBoxItem)listCtrl.SelectedItem;
                m_SelectedItem = listBoxItem.Value as VehicleModelInfo;
            }
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(this, EventArgs.Empty);
            }
        }

        private void checkedComboBoxEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (m_listBoxVehicleModel == null)
            {
                e.DisplayText = "不限";
            }
            else if (m_listBoxVehicleModel.Items[0].CheckState == CheckState.Checked)
            {
                e.DisplayText = "不限";
            }

        }

        private void ucSelectVehicleModel_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void ucSelectVehicleModel_Resize(object sender, EventArgs e)
        {
            checkedComboBoxEdit1.Width = this.Width - 6 - checkedComboBoxEdit1.Left;
        }
    }
}
