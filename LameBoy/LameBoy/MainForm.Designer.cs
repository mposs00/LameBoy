namespace LameBoy
{
    partial class MainForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemOpenRom = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemPause = new System.Windows.Forms.MenuItem();
            this.menuItemRestart = new System.Windows.Forms.MenuItem();
            this.panelGraphics = new System.Windows.Forms.Panel();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpenRom,
            this.menuItem3,
            this.menuItemExit});
            this.menuItem1.Text = "File";
            // 
            // menuItemOpenRom
            // 
            this.menuItemOpenRom.Index = 0;
            this.menuItemOpenRom.Text = "&Open ROM...";
            this.menuItemOpenRom.Click += new System.EventHandler(this.menuItemOpenRom_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 2;
            this.menuItemExit.Text = "E&xit";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemPause,
            this.menuItemRestart});
            this.menuItem2.Text = "System";
            // 
            // menuItemPause
            // 
            this.menuItemPause.Index = 0;
            this.menuItemPause.Text = "&Pause";
            // 
            // menuItemRestart
            // 
            this.menuItemRestart.Index = 1;
            this.menuItemRestart.Text = "&Restart";
            // 
            // panelGraphics
            // 
            this.panelGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphics.Location = new System.Drawing.Point(0, 0);
            this.panelGraphics.Name = "panelGraphics";
            this.panelGraphics.Size = new System.Drawing.Size(800, 720);
            this.panelGraphics.TabIndex = 0;
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5});
            this.menuItem4.Text = "View";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7,
            this.menuItem8});
            this.menuItem5.Text = "Palette";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "BGB";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Dark Green";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Gray";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 720);
            this.Controls.Add(this.panelGraphics);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "LameBoy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemOpenRom;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemPause;
        private System.Windows.Forms.MenuItem menuItemRestart;
        private System.Windows.Forms.Panel panelGraphics;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
    }
}