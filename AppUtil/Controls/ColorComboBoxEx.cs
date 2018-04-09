using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace AppUtil.Controls
{
    [System.ComponentModel.DefaultBindingProperty("SelectedColor")]
    public partial class ColorComboBoxEx : DevExpress.XtraEditors.ImageComboBoxEdit
    {

        public readonly static ColorName COLOR_TRANSPARENT = new ColorName(Color.Transparent, "不限");

        public event PropertyChangedEventHandler PropertyChanged;

        private ColorName[] m_Colors;

        private Color m_SelectedColor;

        private ColorName m_SelectedColorName;


        // [Bindable(true)]
        public Color SelectedColor
        {
            get
            {
                return m_SelectedColor;
            }
            set
            {
                if (m_SelectedColor.ToArgb() != value.ToArgb())
                {
                    m_SelectedColor = value;
                    foreach (ImageComboBoxItem item in this.Properties.Items)
                    {
                        if (((Color)(item.Value)).ToArgb() == value.ToArgb())
                        {
                            this.SelectedItem = item;
                            break;
                        }
                    }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedColor"));
                    }
                }
            }
        }

        public ColorName SelectedColorName
        {
            get
            {
                ColorName colorName = m_Colors[0];
                
                if (m_Colors != null && m_Colors.Length > 0 && SelectedIndex > -1)
                {
                    colorName = m_Colors[SelectedIndex];
                }
                return colorName;
            }
        }

        public ColorComboBoxEx()
        {
            InitializeComponent();
      
            SelectedIndexChanged += new EventHandler(ColorComboBoxEx_SelectedIndexChanged);
        }

        void ColorComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex > -1)
            {
                SelectedColor = (Color)((ImageComboBoxItem)SelectedItem).Value;
            }
        }

        private void FillupItems(ColorName[] colors)
        {
            ImageCollection imgCollection = new ImageCollection();
            foreach (ColorName color in colors)
            {
                Image img = new Bitmap(20, 20);
                Graphics g = Graphics.FromImage(img);
                g.FillRectangle(new SolidBrush(color.Color), new Rectangle(0, 0, 20, 20));
                g.Dispose();
                imgCollection.AddImage(img);
            }

            this.Properties.SmallImages = imgCollection;
            int i = 0;
            foreach (ColorName color in colors)
            {
                ImageComboBoxItem item = new ImageComboBoxItem(color.Name, color.Color, i);
                item.Value = color.Color;
                this.Properties.Items.Add(item); //colors[i].Item3));
                i++;
            }
        }

        public int SetColors(ColorName[] colors)
        {
            this.Properties.Items.Clear();
            m_Colors = colors;
            FillupItems(colors);

            this.SelectedIndex = 0;
            return this.Properties.Items.Count;
        }

    }

    public struct ColorName
    {
        private Color m_Color;

        private string m_Name;

        public Color Color
        {
            get
            {
                return m_Color;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public ColorName(Color color, string name)
        {
            m_Color = color;
            m_Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
