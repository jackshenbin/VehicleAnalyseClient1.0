using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.VehicleAnalyse.Main.ViewModels;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Service.DAO;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public partial class ucSearchSettings : DevExpress.XtraEditors.XtraUserControl
    {
        #region Events
        
        public event EventHandler SearchClicked;
        public event EventHandler CancelClicked;

        public event EventHandler ToShowPopup;
        public event EventHandler ToHidePopup;

        #endregion

        #region Fields
        
        private SearchSettingsViewModel m_ViewModel;

        #endregion

        #region Constructors
        
        public ucSearchSettings()
        {
            InitializeComponent();
            if (Framework.Environment.UseCustomTitle)
                this.pictureEdit2.Properties.InitialImage = Framework.Environment.CustomLogo;

        }

        #endregion

        #region Private helper functions

        private void UpdateVehiclePic(VehicleBrandInfo modelInfo)
        {
            Image image = null;

            if (modelInfo != null)
            {
                try
                {
                    Image imgTmp = pictureEdit2.Image;
                    pictureEdit2.Image = null;
                    if (imgTmp != null)
                    {
                        imgTmp.Dispose();
                    }

                    if ((byte)this.radioGroup1.EditValue == 0)
                    {
                        if (modelInfo.Front != null)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(modelInfo.Front);
                            try
                            {
                                image = System.Drawing.Image.FromStream(ms);
                            }
                            catch (ArgumentException aex)
                            {
                                image = null;
                            }
                        }
                    }
                    else
                    {
                        if (modelInfo.Back != null)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(modelInfo.Back);
                            try
                            {
                                image = System.Drawing.Image.FromStream(ms);
                            }
                            catch (ArgumentException aex)
                            {
                                image = null;
                            }
                        }
                    }

                    //image = ((byte)this.radioGroup1.EditValue == 0) ? modelInfo.Front : modelInfo.Back;

                    pictureEdit2.ToolTip = string.Format("车型编号: {1}, 名称: {0}", modelInfo.Name, modelInfo.ID);
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.Message);
                }
            }
            else
            {
                pictureEdit2.ToolTip = string.Empty;
            }

            pictureEdit2.Image = image;
            pictureEdit2.Properties.SizeMode = PictureSizeMode.Zoom;
        }
        
        #endregion

        #region Event handlers
        
        private void ucSearchSettings_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            
            m_ViewModel = new SearchSettingsViewModel();
            //this.btnCompare.Top = this.btnSearch.Top = this.simpleButton2.Top = this.ucSearchSettingsContainer1.Bottom + 2;
            ucSearchSettingsContainer1.ViewModel = m_ViewModel;
            ucSearchSettingsContainer1.Init();
            ucSearchSettingsContainer1.SelectedBrandChanged += new Action<long, bool, long[]>(ucSearchSettingsContainer1_SelectedBrandChanged);
            ucSearchSettingsContainer1.FocusedModelChanged += new Action<long,long>(ucSearchSettingsContainer1_FocusedModelChanged);
            ucSearchSettingsContainer1.VehilceModelDropdownClosed += new Action<long, bool, long[]>(ucSearchSettingsContainer1_VehilceModelDropdownClosed);

        }

        void ucSearchSettingsContainer1_VehilceModelDropdownClosed(long arg1, bool arg2, long[] arg3)
        {
            m_ViewModel.SelectAllVehicleModels = arg2;
            if (!arg2)
            {
                List<VehicleBrandInfo> models = new List<VehicleBrandInfo>();

                foreach (var id in arg3)
                {
                    VehicleBrandInfo model = (VehicleBrandInfo)Constant.GetVehicleDetailBrand((int)arg1).Find(iterator => iterator.ID == (int)id);
                    models.Add(model);
                }

                m_ViewModel.CheckedVehicleModels = models.ToArray();
                if (models.Count == 1)
                {
                    UpdateVehiclePic(models[0]);
                }
                else
                {
                    UpdateVehiclePic(m_ViewModel.Brand);
                }
            }
            else
            {
                UpdateVehiclePic(m_ViewModel.Brand);
            }
        }

        void ucSearchSettingsContainer1_FocusedModelChanged(long arg1,long arg2)
        {
            VehicleBrandInfo model = (VehicleBrandInfo)Constant.GetVehicleDetailBrand((int)arg1).Find(iterator => iterator.ID == (int)arg2); 
            UpdateVehiclePic(model);
        }

        void ucSearchSettingsContainer1_SelectedBrandChanged(long arg1, bool arg2, long[] arg3)
        {
            VehicleBrandInfo brand = (VehicleBrandInfo)Constant.PropertyInfo_VehicleBrand.Find(it => it.ID == (int)arg1);

            m_ViewModel.Brand = brand;
            m_ViewModel.SelectAllVehicleModels = true;
            UpdateVehiclePic(brand);
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelClicked != null)
            {
                CancelClicked(this, EventArgs.Empty);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool valid = true;


            if(valid)
            {

                m_ViewModel.Commit();

                if (SearchClicked != null)
                {
                    SearchClicked(this, EventArgs.Empty);
                }
            }
        }

        #endregion


        private void simpleButtonClearSetting_Click(object sender, EventArgs e)
        {
            ucSearchSettingsContainer1.ResetAll();
        }



    }
}
