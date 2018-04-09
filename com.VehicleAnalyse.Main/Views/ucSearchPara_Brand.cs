using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.VehicleAnalyse.DataModel;
using com.VehicleAnalyse.Service.DAO;
using com.VehicleAnalyse.Main.ViewModels;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using VehicleHelper.DataModel;

namespace com.VehicleAnalyse.Main.Views
{
    public class ucSearchPara_Brand : ucSearchPara
    {
        private VehicleHelper.ucSelectVehicleModel ucSelectVehicleModel1;
        public event EventHandler ToShowPopup;
        public event EventHandler ToHidePopup;

        public event Action<long, bool, long[]> SelectedBrandChanged;
        public event Action<long, bool, long[]> VehilceModelDropdownClosed;
        public event Action<long, long> FocusedModelChanged;

        private CheckedListBoxControl m_listBoxVehicleModel;

        public VehicleBrandInfo SelectedBrand
        {
            get;
            private set;
        }

        public bool SelectAllVehicleModels
        {
            get;
            private set;
        }

        //internal VehicleModelInfo FocusedModel
        //{
        //    get;
        //    private set;
        //}

        public ucSearchPara_Brand()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ucSelectVehicleModel1 = new VehicleHelper.ucSelectVehicleModel();
            this.SuspendLayout();
            // 
            // ucSelectVehicleModel1
            // 
            this.ucSelectVehicleModel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSelectVehicleModel1.Location = new System.Drawing.Point(0, 0);
            this.ucSelectVehicleModel1.Name = "ucSelectVehicleModel1";
            this.ucSelectVehicleModel1.Size = new System.Drawing.Size(191, 81);
            this.ucSelectVehicleModel1.TabIndex = 0;
            // 
            // ucSearchPara_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.ucSelectVehicleModel1);
            this.Name = "ucSearchPara_Brand";
            this.Size = new System.Drawing.Size(191, 81);
            this.Load += new System.EventHandler(this.ucSearchPara_Brand_Load);
            this.ResumeLayout(false);

        }

        private long[] GetCheckedModelIds()
        {
            long[] models = null;
            if (ucSelectVehicleModel1.CheckedVehicleModels != null)
            {
                models = new long[ucSelectVehicleModel1.CheckedVehicleModels.Length];
                int i = 0;
                foreach (var m in ucSelectVehicleModel1.CheckedVehicleModels)
                {
                    models[i++] = m.ID;
                }
            }
            return models;
        }

        private void ucSearchPara_Brand_Load(object sender, EventArgs e)
        {
            
        }

        public override void Init(object para)
        {
            ucSelectVehicleModel1.Init();
            ucSelectVehicleModel1.ShowNoLogoBrand = Framework.Environment.ShowNoLogoBrand;
            ucSelectVehicleModel1.SelectedBrandChanged += new EventHandler(ucSelectVehicleModel1_SelectedBrandChanged);
            ucSelectVehicleModel1.SelectedItemChanged += new EventHandler(ucSelectVehicleModel1_SelectedItemChanged);
            ucSelectVehicleModel1.Close += new EventHandler(ucSelectVehicleModel1_Close);
        }

        void ucSelectVehicleModel1_Close(object sender, EventArgs e)
        {
            if (VehilceModelDropdownClosed != null)
            {
                long[] models = GetCheckedModelIds();
                VehilceModelDropdownClosed(ucSelectVehicleModel1.Brand.ID, ucSelectVehicleModel1.SelectAllVehicleModels,
                    models);
            }
        }

        void ucSelectVehicleModel1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (FocusedModelChanged != null && this.ucSelectVehicleModel1.SelectedItem != null &&
                this.ucSelectVehicleModel1.SelectedItem.Model != null)
            {
                long brandId = -1;
                if (ucSelectVehicleModel1.Brand != null)
                {
                    brandId = ucSelectVehicleModel1.Brand.ID;
                }
                else
                {
                    brandId = -1;
                }
                FocusedModelChanged(brandId,this.ucSelectVehicleModel1.SelectedItem.Model.ID);   
            }
        }

        void ucSelectVehicleModel1_SelectedBrandChanged(object sender, EventArgs e)
        {
            if (SelectedBrandChanged != null)
            {
                long[] models = GetCheckedModelIds();
                long brandId = -1;
                if (ucSelectVehicleModel1.Brand != null)
                {
                    brandId = ucSelectVehicleModel1.Brand.ID;
                }
                else
                {
                    brandId = -1;
                }
                SelectedBrandChanged(brandId, ucSelectVehicleModel1.SelectAllVehicleModels,
                    models);
            }
        }
        
    }
}
