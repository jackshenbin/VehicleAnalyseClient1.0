namespace Bocom.ImageAnalysisClient.App
{
    partial class PaintMenuBar {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BarSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.BarButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            this.BarButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Built-in Menus", new System.Guid("b1340900-e029-4178-881b-b60d8e2f3df5")),
            new DevExpress.XtraBars.BarManagerCategory("File", new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed")),
            new DevExpress.XtraBars.BarManagerCategory("Edit", new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7")),
            new DevExpress.XtraBars.BarManagerCategory("Help", new System.Guid("2b8b9175-119d-4795-b137-9d2b46edfe27"))});
            this.barManager1.DockControls.Add(this.barDockControl5);
            this.barManager1.DockControls.Add(this.barDockControl6);
            this.barManager1.DockControls.Add(this.barDockControl7);
            this.barManager1.DockControls.Add(this.barDockControl8);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarSubItem1,
            this.BarButtonItem1,
            this.BarButtonItem2,
            this.BarButtonItem3,
            this.BarButtonItem4,
            this.BarButtonItem5,
            this.BarButtonItem6,
            this.BarButtonItem7,
            this.BarButtonItem8,
            this.BarButtonItem9,
            this.BarButtonItem10,
            this.BarButtonItem11,
            this.BarButtonItem20});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 25;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main Menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(46, 146);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem20)});
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main Menu";
            // 
            // BarSubItem1
            // 
            this.BarSubItem1.Caption = "&File";
            this.BarSubItem1.CategoryGuid = new System.Guid("b1340900-e029-4178-881b-b60d8e2f3df5");
            this.BarSubItem1.Id = 0;
            this.BarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem6, true)});
            this.BarSubItem1.MenuBarWidth = 20;
            this.BarSubItem1.Name = "BarSubItem1";
            this.BarSubItem1.PaintMenuBar += new DevExpress.XtraBars.BarCustomDrawEventHandler(this.BarSubItem1_PaintMenuBar);
            // 
            // BarButtonItem1
            // 
            this.BarButtonItem1.Caption = "&New";
            this.BarButtonItem1.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem1.Id = 4;
            this.BarButtonItem1.ImageIndex = 0;
            this.BarButtonItem1.Name = "BarButtonItem1";
            // 
            // BarButtonItem2
            // 
            this.BarButtonItem2.Caption = "&Open...";
            this.BarButtonItem2.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem2.Id = 5;
            this.BarButtonItem2.ImageIndex = 1;
            this.BarButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.BarButtonItem2.Name = "BarButtonItem2";
            // 
            // BarButtonItem3
            // 
            this.BarButtonItem3.Caption = "&Close";
            this.BarButtonItem3.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem3.Id = 6;
            this.BarButtonItem3.ImageIndex = 2;
            this.BarButtonItem3.Name = "BarButtonItem3";
            // 
            // BarButtonItem4
            // 
            this.BarButtonItem4.Caption = "&Save";
            this.BarButtonItem4.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem4.Id = 7;
            this.BarButtonItem4.ImageIndex = 3;
            this.BarButtonItem4.Name = "BarButtonItem4";
            // 
            // BarButtonItem5
            // 
            this.BarButtonItem5.Caption = "Save &As...";
            this.BarButtonItem5.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem5.Id = 8;
            this.BarButtonItem5.Name = "BarButtonItem5";
            // 
            // BarButtonItem6
            // 
            this.BarButtonItem6.Caption = "E&xit";
            this.BarButtonItem6.CategoryGuid = new System.Guid("76d438f4-8c99-4952-923e-c28989e802ed");
            this.BarButtonItem6.Id = 9;
            this.BarButtonItem6.Name = "BarButtonItem6";
            // 
            // BarButtonItem20
            // 
            this.BarButtonItem20.Caption = "&About";
            this.BarButtonItem20.CategoryGuid = new System.Guid("2b8b9175-119d-4795-b137-9d2b46edfe27");
            this.BarButtonItem20.Id = 23;
            this.BarButtonItem20.ImageIndex = 18;
            this.BarButtonItem20.Name = "BarButtonItem20";
            this.BarButtonItem20.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl5.Location = new System.Drawing.Point(0, 0);
            this.barDockControl5.Size = new System.Drawing.Size(364, 24);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl6.Location = new System.Drawing.Point(0, 197);
            this.barDockControl6.Size = new System.Drawing.Size(364, 0);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl7.Location = new System.Drawing.Point(0, 24);
            this.barDockControl7.Size = new System.Drawing.Size(0, 173);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl8.Location = new System.Drawing.Point(364, 24);
            this.barDockControl8.Size = new System.Drawing.Size(0, 173);
            // 
            // BarButtonItem7
            // 
            this.BarButtonItem7.Caption = "Cu&t";
            this.BarButtonItem7.CategoryGuid = new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7");
            this.BarButtonItem7.Id = 10;
            this.BarButtonItem7.ImageIndex = 4;
            this.BarButtonItem7.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.BarButtonItem7.Name = "BarButtonItem7";
            // 
            // BarButtonItem8
            // 
            this.BarButtonItem8.Caption = "&Copy";
            this.BarButtonItem8.CategoryGuid = new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7");
            this.BarButtonItem8.Id = 11;
            this.BarButtonItem8.ImageIndex = 5;
            this.BarButtonItem8.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
            this.BarButtonItem8.Name = "BarButtonItem8";
            // 
            // BarButtonItem9
            // 
            this.BarButtonItem9.Caption = "&Paste";
            this.BarButtonItem9.CategoryGuid = new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7");
            this.BarButtonItem9.Id = 12;
            this.BarButtonItem9.ImageIndex = 6;
            this.BarButtonItem9.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            this.BarButtonItem9.Name = "BarButtonItem9";
            // 
            // BarButtonItem10
            // 
            this.BarButtonItem10.Caption = "&Find...";
            this.BarButtonItem10.CategoryGuid = new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7");
            this.BarButtonItem10.Id = 13;
            this.BarButtonItem10.ImageIndex = 7;
            this.BarButtonItem10.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.BarButtonItem10.Name = "BarButtonItem10";
            // 
            // BarButtonItem11
            // 
            this.BarButtonItem11.Caption = "R&eplace...";
            this.BarButtonItem11.CategoryGuid = new System.Guid("f84df199-d33c-46e1-a48c-249c4b2949c7");
            this.BarButtonItem11.Id = 14;
            this.BarButtonItem11.ImageIndex = 8;
            this.BarButtonItem11.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H));
            this.BarButtonItem11.Name = "BarButtonItem11";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.barManager1.SetPopupContextMenu(this.panelControl1, this.popupMenu1);
            this.panelControl1.Size = new System.Drawing.Size(364, 173);
            this.panelControl1.TabIndex = 4;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem10, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItem11)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.MenuBarWidth = 20;
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.PaintMenuBar += new DevExpress.XtraBars.BarCustomDrawEventHandler(this.popupMenu1_PaintMenuBar);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PaintMenuBar
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl7);
            this.Controls.Add(this.barDockControl8);
            this.Controls.Add(this.barDockControl6);
            this.Controls.Add(this.barDockControl5);
            this.Name = "PaintMenuBar";
            this.Size = new System.Drawing.Size(364, 197);
            this.TutorialInfo.AboutFile = null;
            this.TutorialInfo.Description = null;
            this.TutorialInfo.TutorialName = null;
            this.TutorialInfo.WhatsThisCodeFile = null;
            this.TutorialInfo.WhatsThisXMLFile = null;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem BarSubItem1;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem1;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem2;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem3;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem4;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem5;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem6;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem7;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem8;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem9;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem10;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem11;
        private DevExpress.XtraBars.BarButtonItem BarButtonItem20;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl7;
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.IContainer components;

    }
}
