namespace LameBoy
{
    partial class Debugger
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Disassembly", System.Windows.Forms.HorizontalAlignment.Left);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonGo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerDisassemblyAndMemory = new System.Windows.Forms.SplitContainer();
            this.tabControlDisassembly = new System.Windows.Forms.TabControl();
            this.tabPageROM = new System.Windows.Forms.TabPage();
            this.listViewDisassemblyROM = new System.Windows.Forms.ListView();
            this.AddressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstructionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlMemory = new System.Windows.Forms.TabControl();
            this.tabPageRAM = new System.Windows.Forms.TabPage();
            this.editTextBox = new System.Windows.Forms.TextBox();
            this.listViewMemory = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxFlags = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFlags = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxZ = new System.Windows.Forms.CheckBox();
            this.checkBoxS = new System.Windows.Forms.CheckBox();
            this.checkBoxH = new System.Windows.Forms.CheckBox();
            this.checkBoxC = new System.Windows.Forms.CheckBox();
            this.groupBoxRegisters = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAF = new LameBoy.NumericUpDownHex();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownBC = new LameBoy.NumericUpDownHex();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDE = new LameBoy.NumericUpDownHex();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownHL = new LameBoy.NumericUpDownHex();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownSP = new LameBoy.NumericUpDownHex();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPC = new LameBoy.NumericUpDownHex();
            this.contextMenuStripDisasm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisassemblyAndMemory)).BeginInit();
            this.splitContainerDisassemblyAndMemory.Panel1.SuspendLayout();
            this.splitContainerDisassemblyAndMemory.Panel2.SuspendLayout();
            this.splitContainerDisassemblyAndMemory.SuspendLayout();
            this.tabControlDisassembly.SuspendLayout();
            this.tabPageROM.SuspendLayout();
            this.tabControlMemory.SuspendLayout();
            this.tabPageRAM.SuspendLayout();
            this.groupBoxFlags.SuspendLayout();
            this.flowLayoutPanelFlags.SuspendLayout();
            this.groupBoxRegisters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPC)).BeginInit();
            this.contextMenuStripDisasm.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.menuItem1.Text = "File";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "&Reset";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuItem5.Text = "E&xit";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem8,
            this.menuItem9,
            this.menuItem7});
            this.menuItem2.Text = "Run";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem6.Text = "&Go";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "S&top";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.menuItem7.Text = "&Step Once";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonGo,
            this.toolStripButtonStep,
            this.toolStripButtonStop,
            this.toolStripLabelStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonGo
            // 
            this.toolStripButtonGo.Image = global::LameBoy.Properties.Resources.DebuggerGo;
            this.toolStripButtonGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGo.Name = "toolStripButtonGo";
            this.toolStripButtonGo.Size = new System.Drawing.Size(42, 22);
            this.toolStripButtonGo.Text = "Go";
            this.toolStripButtonGo.Click += new System.EventHandler(this.toolStripButtonGo_Click);
            // 
            // toolStripButtonStep
            // 
            this.toolStripButtonStep.Image = global::LameBoy.Properties.Resources.DebuggerStep;
            this.toolStripButtonStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStep.Name = "toolStripButtonStep";
            this.toolStripButtonStep.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonStep.Text = "Step";
            this.toolStripButtonStep.Click += new System.EventHandler(this.toolStripButtonStep_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.Image = global::LameBoy.Properties.Resources.DebbugerStop;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripLabelStatus
            // 
            this.toolStripLabelStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelStatus.Image = global::LameBoy.Properties.Resources.DebbugerStop;
            this.toolStripLabelStatus.Name = "toolStripLabelStatus";
            this.toolStripLabelStatus.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabelStatus.Text = "Stopped";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainerDisassemblyAndMemory);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBoxFlags);
            this.splitContainer.Panel2.Controls.Add(this.groupBoxRegisters);
            this.splitContainer.Size = new System.Drawing.Size(792, 470);
            this.splitContainer.SplitterDistance = 585;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 1;
            // 
            // splitContainerDisassemblyAndMemory
            // 
            this.splitContainerDisassemblyAndMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDisassemblyAndMemory.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDisassemblyAndMemory.Name = "splitContainerDisassemblyAndMemory";
            this.splitContainerDisassemblyAndMemory.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDisassemblyAndMemory.Panel1
            // 
            this.splitContainerDisassemblyAndMemory.Panel1.Controls.Add(this.tabControlDisassembly);
            // 
            // splitContainerDisassemblyAndMemory.Panel2
            // 
            this.splitContainerDisassemblyAndMemory.Panel2.Controls.Add(this.tabControlMemory);
            this.splitContainerDisassemblyAndMemory.Size = new System.Drawing.Size(585, 470);
            this.splitContainerDisassemblyAndMemory.SplitterDistance = 281;
            this.splitContainerDisassemblyAndMemory.TabIndex = 0;
            // 
            // tabControlDisassembly
            // 
            this.tabControlDisassembly.Controls.Add(this.tabPageROM);
            this.tabControlDisassembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDisassembly.Location = new System.Drawing.Point(0, 0);
            this.tabControlDisassembly.Name = "tabControlDisassembly";
            this.tabControlDisassembly.SelectedIndex = 0;
            this.tabControlDisassembly.Size = new System.Drawing.Size(585, 281);
            this.tabControlDisassembly.TabIndex = 0;
            // 
            // tabPageROM
            // 
            this.tabPageROM.Controls.Add(this.listViewDisassemblyROM);
            this.tabPageROM.Location = new System.Drawing.Point(4, 22);
            this.tabPageROM.Name = "tabPageROM";
            this.tabPageROM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageROM.Size = new System.Drawing.Size(577, 255);
            this.tabPageROM.TabIndex = 0;
            this.tabPageROM.Text = "ROM";
            this.tabPageROM.UseVisualStyleBackColor = true;
            // 
            // listViewDisassemblyROM
            // 
            this.listViewDisassemblyROM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AddressColumn,
            this.HexColumn,
            this.InstructionColumn});
            this.listViewDisassemblyROM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDisassemblyROM.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDisassemblyROM.FullRowSelect = true;
            listViewGroup1.Header = "Disassembly";
            listViewGroup1.Name = "DisassemblyView";
            this.listViewDisassemblyROM.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewDisassemblyROM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDisassemblyROM.Location = new System.Drawing.Point(3, 3);
            this.listViewDisassemblyROM.MultiSelect = false;
            this.listViewDisassemblyROM.Name = "listViewDisassemblyROM";
            this.listViewDisassemblyROM.ShowGroups = false;
            this.listViewDisassemblyROM.Size = new System.Drawing.Size(571, 249);
            this.listViewDisassemblyROM.TabIndex = 0;
            this.listViewDisassemblyROM.UseCompatibleStateImageBehavior = false;
            this.listViewDisassemblyROM.View = System.Windows.Forms.View.Details;
            this.listViewDisassemblyROM.VirtualMode = true;
            this.listViewDisassemblyROM.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewDisassemblyROM_RetrieveVirtualItem);
            // 
            // AddressColumn
            // 
            this.AddressColumn.Text = "Addr";
            this.AddressColumn.Width = 58;
            // 
            // HexColumn
            // 
            this.HexColumn.Text = "Raw";
            this.HexColumn.Width = 89;
            // 
            // InstructionColumn
            // 
            this.InstructionColumn.Text = "Instruction";
            this.InstructionColumn.Width = 406;
            // 
            // tabControlMemory
            // 
            this.tabControlMemory.Controls.Add(this.tabPageRAM);
            this.tabControlMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMemory.Location = new System.Drawing.Point(0, 0);
            this.tabControlMemory.Name = "tabControlMemory";
            this.tabControlMemory.SelectedIndex = 0;
            this.tabControlMemory.Size = new System.Drawing.Size(585, 185);
            this.tabControlMemory.TabIndex = 0;
            // 
            // tabPageRAM
            // 
            this.tabPageRAM.Controls.Add(this.editTextBox);
            this.tabPageRAM.Controls.Add(this.listViewMemory);
            this.tabPageRAM.Location = new System.Drawing.Point(4, 22);
            this.tabPageRAM.Name = "tabPageRAM";
            this.tabPageRAM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRAM.Size = new System.Drawing.Size(577, 159);
            this.tabPageRAM.TabIndex = 0;
            this.tabPageRAM.Text = "Memory";
            this.tabPageRAM.UseVisualStyleBackColor = true;
            // 
            // editTextBox
            // 
            this.editTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTextBox.Location = new System.Drawing.Point(0, 0);
            this.editTextBox.MaxLength = 2;
            this.editTextBox.Name = "editTextBox";
            this.editTextBox.Size = new System.Drawing.Size(100, 22);
            this.editTextBox.TabIndex = 2;
            this.editTextBox.Visible = false;
            this.editTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editTextBox_KeyDown);
            this.editTextBox.Leave += new System.EventHandler(this.editTextBox_Leave);
            // 
            // listViewMemory
            // 
            this.listViewMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colC0,
            this.colC1,
            this.colC2,
            this.colC3,
            this.colC4,
            this.colC5,
            this.colC6,
            this.colC7,
            this.colC8,
            this.colC9,
            this.colCA,
            this.colCB,
            this.colCC,
            this.colCD,
            this.colCE,
            this.colCF});
            this.listViewMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMemory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewMemory.FullRowSelect = true;
            this.listViewMemory.GridLines = true;
            this.listViewMemory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMemory.HideSelection = false;
            this.listViewMemory.Location = new System.Drawing.Point(3, 3);
            this.listViewMemory.MultiSelect = false;
            this.listViewMemory.Name = "listViewMemory";
            this.listViewMemory.ShowGroups = false;
            this.listViewMemory.Size = new System.Drawing.Size(571, 153);
            this.listViewMemory.TabIndex = 0;
            this.listViewMemory.UseCompatibleStateImageBehavior = false;
            this.listViewMemory.View = System.Windows.Forms.View.Details;
            this.listViewMemory.VirtualMode = true;
            this.listViewMemory.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewMemory_RetrieveVirtualItem);
            this.listViewMemory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMemory_DoubleClick);
            // 
            // colAddress
            // 
            this.colAddress.Text = "Addr";
            // 
            // colC0
            // 
            this.colC0.Text = "0";
            this.colC0.Width = 30;
            // 
            // colC1
            // 
            this.colC1.Text = "1";
            this.colC1.Width = 30;
            // 
            // colC2
            // 
            this.colC2.Text = "2";
            this.colC2.Width = 30;
            // 
            // colC3
            // 
            this.colC3.Text = "3";
            this.colC3.Width = 30;
            // 
            // colC4
            // 
            this.colC4.Text = "4";
            this.colC4.Width = 30;
            // 
            // colC5
            // 
            this.colC5.Text = "5";
            this.colC5.Width = 30;
            // 
            // colC6
            // 
            this.colC6.Text = "6";
            this.colC6.Width = 30;
            // 
            // colC7
            // 
            this.colC7.Text = "7";
            this.colC7.Width = 30;
            // 
            // colC8
            // 
            this.colC8.Text = "8";
            this.colC8.Width = 30;
            // 
            // colC9
            // 
            this.colC9.Text = "9";
            this.colC9.Width = 30;
            // 
            // colCA
            // 
            this.colCA.Text = "A";
            this.colCA.Width = 30;
            // 
            // colCB
            // 
            this.colCB.Text = "B";
            this.colCB.Width = 30;
            // 
            // colCC
            // 
            this.colCC.Text = "C";
            this.colCC.Width = 30;
            // 
            // colCD
            // 
            this.colCD.Text = "D";
            this.colCD.Width = 30;
            // 
            // colCE
            // 
            this.colCE.Text = "E";
            this.colCE.Width = 30;
            // 
            // colCF
            // 
            this.colCF.Text = "F";
            this.colCF.Width = 30;
            // 
            // groupBoxFlags
            // 
            this.groupBoxFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFlags.Controls.Add(this.flowLayoutPanelFlags);
            this.groupBoxFlags.Location = new System.Drawing.Point(4, 145);
            this.groupBoxFlags.Name = "groupBoxFlags";
            this.groupBoxFlags.Size = new System.Drawing.Size(212, 57);
            this.groupBoxFlags.TabIndex = 1;
            this.groupBoxFlags.TabStop = false;
            this.groupBoxFlags.Text = "Flags";
            // 
            // flowLayoutPanelFlags
            // 
            this.flowLayoutPanelFlags.Controls.Add(this.checkBoxZ);
            this.flowLayoutPanelFlags.Controls.Add(this.checkBoxS);
            this.flowLayoutPanelFlags.Controls.Add(this.checkBoxH);
            this.flowLayoutPanelFlags.Controls.Add(this.checkBoxC);
            this.flowLayoutPanelFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFlags.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelFlags.Name = "flowLayoutPanelFlags";
            this.flowLayoutPanelFlags.Size = new System.Drawing.Size(206, 38);
            this.flowLayoutPanelFlags.TabIndex = 0;
            // 
            // checkBoxZ
            // 
            this.checkBoxZ.AutoSize = true;
            this.checkBoxZ.Location = new System.Drawing.Point(3, 3);
            this.checkBoxZ.Name = "checkBoxZ";
            this.checkBoxZ.Size = new System.Drawing.Size(33, 17);
            this.checkBoxZ.TabIndex = 1;
            this.checkBoxZ.Tag = "Flag.Z";
            this.checkBoxZ.Text = "Z";
            this.checkBoxZ.UseVisualStyleBackColor = true;
            this.checkBoxZ.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxS
            // 
            this.checkBoxS.AutoSize = true;
            this.checkBoxS.Location = new System.Drawing.Point(42, 3);
            this.checkBoxS.Name = "checkBoxS";
            this.checkBoxS.Size = new System.Drawing.Size(33, 17);
            this.checkBoxS.TabIndex = 2;
            this.checkBoxS.Tag = "Flag.S";
            this.checkBoxS.Text = "S";
            this.checkBoxS.UseVisualStyleBackColor = true;
            this.checkBoxS.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxH
            // 
            this.checkBoxH.AutoSize = true;
            this.checkBoxH.Location = new System.Drawing.Point(81, 3);
            this.checkBoxH.Name = "checkBoxH";
            this.checkBoxH.Size = new System.Drawing.Size(34, 17);
            this.checkBoxH.TabIndex = 3;
            this.checkBoxH.Tag = "Flag.H";
            this.checkBoxH.Text = "H";
            this.checkBoxH.UseVisualStyleBackColor = true;
            this.checkBoxH.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxC
            // 
            this.checkBoxC.AutoSize = true;
            this.checkBoxC.Location = new System.Drawing.Point(121, 3);
            this.checkBoxC.Name = "checkBoxC";
            this.checkBoxC.Size = new System.Drawing.Size(33, 17);
            this.checkBoxC.TabIndex = 4;
            this.checkBoxC.Tag = "Flag.C";
            this.checkBoxC.Text = "C";
            this.checkBoxC.UseVisualStyleBackColor = true;
            this.checkBoxC.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // groupBoxRegisters
            // 
            this.groupBoxRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRegisters.Controls.Add(this.label1);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownAF);
            this.groupBoxRegisters.Controls.Add(this.label2);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownBC);
            this.groupBoxRegisters.Controls.Add(this.label3);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownDE);
            this.groupBoxRegisters.Controls.Add(this.label4);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownHL);
            this.groupBoxRegisters.Controls.Add(this.label5);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownSP);
            this.groupBoxRegisters.Controls.Add(this.label6);
            this.groupBoxRegisters.Controls.Add(this.numericUpDownPC);
            this.groupBoxRegisters.Location = new System.Drawing.Point(4, 3);
            this.groupBoxRegisters.Name = "groupBoxRegisters";
            this.groupBoxRegisters.Size = new System.Drawing.Size(212, 136);
            this.groupBoxRegisters.TabIndex = 0;
            this.groupBoxRegisters.TabStop = false;
            this.groupBoxRegisters.Text = "Registers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "AF";
            // 
            // numericUpDownAF
            // 
            this.numericUpDownAF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownAF.DecimalPlaces = 4;
            this.numericUpDownAF.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAF.Hexadecimal = true;
            this.numericUpDownAF.Location = new System.Drawing.Point(36, 19);
            this.numericUpDownAF.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownAF.Name = "numericUpDownAF";
            this.numericUpDownAF.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownAF.TabIndex = 13;
            this.numericUpDownAF.Tag = "Register.AF";
            this.numericUpDownAF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAF.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "BC";
            // 
            // numericUpDownBC
            // 
            this.numericUpDownBC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownBC.DecimalPlaces = 4;
            this.numericUpDownBC.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBC.Hexadecimal = true;
            this.numericUpDownBC.Location = new System.Drawing.Point(129, 18);
            this.numericUpDownBC.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownBC.Name = "numericUpDownBC";
            this.numericUpDownBC.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownBC.TabIndex = 15;
            this.numericUpDownBC.Tag = "Register.BC";
            this.numericUpDownBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownBC.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "DE";
            // 
            // numericUpDownDE
            // 
            this.numericUpDownDE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownDE.DecimalPlaces = 4;
            this.numericUpDownDE.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDE.Hexadecimal = true;
            this.numericUpDownDE.Location = new System.Drawing.Point(36, 41);
            this.numericUpDownDE.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownDE.Name = "numericUpDownDE";
            this.numericUpDownDE.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownDE.TabIndex = 17;
            this.numericUpDownDE.Tag = "Register.DE";
            this.numericUpDownDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDE.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "HL";
            // 
            // numericUpDownHL
            // 
            this.numericUpDownHL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownHL.DecimalPlaces = 4;
            this.numericUpDownHL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHL.Hexadecimal = true;
            this.numericUpDownHL.Location = new System.Drawing.Point(129, 40);
            this.numericUpDownHL.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownHL.Name = "numericUpDownHL";
            this.numericUpDownHL.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownHL.TabIndex = 19;
            this.numericUpDownHL.Tag = "Register.HL";
            this.numericUpDownHL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownHL.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "SP";
            // 
            // numericUpDownSP
            // 
            this.numericUpDownSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownSP.DecimalPlaces = 4;
            this.numericUpDownSP.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSP.Hexadecimal = true;
            this.numericUpDownSP.Location = new System.Drawing.Point(36, 63);
            this.numericUpDownSP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSP.Name = "numericUpDownSP";
            this.numericUpDownSP.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownSP.TabIndex = 21;
            this.numericUpDownSP.Tag = "Register.SP";
            this.numericUpDownSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSP.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "PC";
            // 
            // numericUpDownPC
            // 
            this.numericUpDownPC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownPC.DecimalPlaces = 4;
            this.numericUpDownPC.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPC.Hexadecimal = true;
            this.numericUpDownPC.Location = new System.Drawing.Point(129, 62);
            this.numericUpDownPC.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPC.Name = "numericUpDownPC";
            this.numericUpDownPC.Size = new System.Drawing.Size(58, 16);
            this.numericUpDownPC.TabIndex = 23;
            this.numericUpDownPC.Tag = "Register.PC";
            this.numericUpDownPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPC.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // contextMenuStripDisasm
            // 
            this.contextMenuStripDisasm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToAddressToolStripMenuItem});
            this.contextMenuStripDisasm.Name = "contextMenuStripDisasm";
            this.contextMenuStripDisasm.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripDisasm.ShowImageMargin = false;
            this.contextMenuStripDisasm.Size = new System.Drawing.Size(133, 26);
            // 
            // goToAddressToolStripMenuItem
            // 
            this.goToAddressToolStripMenuItem.Name = "goToAddressToolStripMenuItem";
            this.goToAddressToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.goToAddressToolStripMenuItem.Text = "Go to Address...";
            this.goToAddressToolStripMenuItem.Click += new System.EventHandler(this.goToAddressToolStripMenuItem_Click);
            // 
            // Debugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 495);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Menu = this.mainMenu1;
            this.Name = "Debugger";
            this.ShowIcon = false;
            this.Text = "Debugger";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainerDisassemblyAndMemory.Panel1.ResumeLayout(false);
            this.splitContainerDisassemblyAndMemory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDisassemblyAndMemory)).EndInit();
            this.splitContainerDisassemblyAndMemory.ResumeLayout(false);
            this.tabControlDisassembly.ResumeLayout(false);
            this.tabPageROM.ResumeLayout(false);
            this.tabControlMemory.ResumeLayout(false);
            this.tabPageRAM.ResumeLayout(false);
            this.tabPageRAM.PerformLayout();
            this.groupBoxFlags.ResumeLayout(false);
            this.flowLayoutPanelFlags.ResumeLayout(false);
            this.flowLayoutPanelFlags.PerformLayout();
            this.groupBoxRegisters.ResumeLayout(false);
            this.groupBoxRegisters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPC)).EndInit();
            this.contextMenuStripDisasm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonGo;
        private System.Windows.Forms.ToolStripButton toolStripButtonStep;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerDisassemblyAndMemory;
        private System.Windows.Forms.TabControl tabControlDisassembly;
        private System.Windows.Forms.TabPage tabPageROM;
        private System.Windows.Forms.ListView listViewDisassemblyROM;
        private System.Windows.Forms.ColumnHeader AddressColumn;
        private System.Windows.Forms.ColumnHeader InstructionColumn;
        private System.Windows.Forms.TabControl tabControlMemory;
        private System.Windows.Forms.TabPage tabPageRAM;
        private System.Windows.Forms.GroupBox groupBoxRegisters;
        private System.Windows.Forms.GroupBox groupBoxFlags;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFlags;
        private System.Windows.Forms.CheckBox checkBoxZ;
        private System.Windows.Forms.CheckBox checkBoxS;
        private System.Windows.Forms.CheckBox checkBoxH;
        private System.Windows.Forms.CheckBox checkBoxC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader HexColumn;
        private System.Windows.Forms.ListView listViewMemory;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colC0;
        private System.Windows.Forms.ColumnHeader colC1;
        private System.Windows.Forms.ColumnHeader colC2;
        private System.Windows.Forms.ColumnHeader colC3;
        private System.Windows.Forms.ColumnHeader colC4;
        private System.Windows.Forms.ColumnHeader colC5;
        private System.Windows.Forms.ColumnHeader colC6;
        private System.Windows.Forms.ColumnHeader colC7;
        private System.Windows.Forms.ColumnHeader colC8;
        private System.Windows.Forms.ColumnHeader colC9;
        private System.Windows.Forms.ColumnHeader colCA;
        private System.Windows.Forms.ColumnHeader colCB;
        private System.Windows.Forms.ColumnHeader colCC;
        private System.Windows.Forms.ColumnHeader colCD;
        private System.Windows.Forms.ColumnHeader colCE;
        private System.Windows.Forms.ColumnHeader colCF;
        private System.Windows.Forms.TextBox editTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisasm;
        private System.Windows.Forms.ToolStripMenuItem goToAddressToolStripMenuItem;
        private NumericUpDownHex numericUpDownAF;
        private NumericUpDownHex numericUpDownBC;
        private NumericUpDownHex numericUpDownDE;
        private NumericUpDownHex numericUpDownHL;
        private NumericUpDownHex numericUpDownSP;
        private NumericUpDownHex numericUpDownPC;
    }
}