namespace FictionalMapper
{
    partial class Form1
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.intersectionTool = new System.Windows.Forms.Button();
            this.movePointsButton = new System.Windows.Forms.Button();
            this.parallelButton = new System.Windows.Forms.Button();
            this.selectionNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.routeNumber = new System.Windows.Forms.TextBox();
            this.shieldBoxToggle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shieldType = new System.Windows.Forms.ListBox();
            this.drawRegionButton = new System.Windows.Forms.Button();
            this.drawingRegions = new System.Windows.Forms.ListBox();
            this.drawingLines = new System.Windows.Forms.ListBox();
            this.toolState = new System.Windows.Forms.Label();
            this.drawLineButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.perpendicularTool = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.perpendicularTool);
            this.topPanel.Controls.Add(this.intersectionTool);
            this.topPanel.Controls.Add(this.movePointsButton);
            this.topPanel.Controls.Add(this.parallelButton);
            this.topPanel.Controls.Add(this.selectionNameBox);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.routeNumber);
            this.topPanel.Controls.Add(this.shieldBoxToggle);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.shieldType);
            this.topPanel.Controls.Add(this.drawRegionButton);
            this.topPanel.Controls.Add(this.drawingRegions);
            this.topPanel.Controls.Add(this.drawingLines);
            this.topPanel.Controls.Add(this.toolState);
            this.topPanel.Controls.Add(this.drawLineButton);
            this.topPanel.Controls.Add(this.viewButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1272, 136);
            this.topPanel.TabIndex = 0;
            // 
            // intersectionTool
            // 
            this.intersectionTool.Location = new System.Drawing.Point(12, 94);
            this.intersectionTool.Name = "intersectionTool";
            this.intersectionTool.Size = new System.Drawing.Size(115, 23);
            this.intersectionTool.TabIndex = 14;
            this.intersectionTool.Text = "Intersection";
            this.intersectionTool.UseVisualStyleBackColor = true;
            this.intersectionTool.Click += new System.EventHandler(this.intersectionsTool_Click);
            // 
            // movePointsButton
            // 
            this.movePointsButton.Location = new System.Drawing.Point(12, 6);
            this.movePointsButton.Name = "movePointsButton";
            this.movePointsButton.Size = new System.Drawing.Size(115, 23);
            this.movePointsButton.TabIndex = 13;
            this.movePointsButton.Text = "Move Points";
            this.movePointsButton.UseVisualStyleBackColor = true;
            this.movePointsButton.Click += new System.EventHandler(this.movePointsButton_Click);
            // 
            // parallelButton
            // 
            this.parallelButton.Location = new System.Drawing.Point(12, 36);
            this.parallelButton.Name = "parallelButton";
            this.parallelButton.Size = new System.Drawing.Size(115, 23);
            this.parallelButton.TabIndex = 12;
            this.parallelButton.Text = "Parallel";
            this.parallelButton.UseVisualStyleBackColor = true;
            this.parallelButton.Click += new System.EventHandler(this.parallelButton_Click);
            // 
            // selectionNameBox
            // 
            this.selectionNameBox.Location = new System.Drawing.Point(930, 95);
            this.selectionNameBox.Name = "selectionNameBox";
            this.selectionNameBox.Size = new System.Drawing.Size(217, 22);
            this.selectionNameBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(930, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Selection Name";
            // 
            // routeNumber
            // 
            this.routeNumber.Location = new System.Drawing.Point(930, 33);
            this.routeNumber.Name = "routeNumber";
            this.routeNumber.Size = new System.Drawing.Size(100, 22);
            this.routeNumber.TabIndex = 9;
            this.routeNumber.TextChanged += new System.EventHandler(this.routeNumber_TextChanged);
            this.routeNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.routeNumber_KeyPress);
            // 
            // shieldBoxToggle
            // 
            this.shieldBoxToggle.AutoSize = true;
            this.shieldBoxToggle.Location = new System.Drawing.Point(780, 34);
            this.shieldBoxToggle.Name = "shieldBoxToggle";
            this.shieldBoxToggle.Size = new System.Drawing.Size(18, 17);
            this.shieldBoxToggle.TabIndex = 8;
            this.shieldBoxToggle.UseVisualStyleBackColor = true;
            this.shieldBoxToggle.CheckedChanged += new System.EventHandler(this.shieldBosToggle_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(801, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Highway";
            // 
            // shieldType
            // 
            this.shieldType.Enabled = false;
            this.shieldType.FormattingEnabled = true;
            this.shieldType.ItemHeight = 16;
            this.shieldType.Items.AddRange(new object[] {
            "County",
            "State",
            "U.S.",
            "Interstate"});
            this.shieldType.Location = new System.Drawing.Point(804, 33);
            this.shieldType.Name = "shieldType";
            this.shieldType.Size = new System.Drawing.Size(120, 84);
            this.shieldType.TabIndex = 6;
            // 
            // drawRegionButton
            // 
            this.drawRegionButton.Location = new System.Drawing.Point(136, 94);
            this.drawRegionButton.Name = "drawRegionButton";
            this.drawRegionButton.Size = new System.Drawing.Size(103, 23);
            this.drawRegionButton.TabIndex = 5;
            this.drawRegionButton.Text = "Draw Region";
            this.drawRegionButton.UseVisualStyleBackColor = true;
            this.drawRegionButton.Click += new System.EventHandler(this.drawRegionButton_Click);
            // 
            // drawingRegions
            // 
            this.drawingRegions.FormattingEnabled = true;
            this.drawingRegions.ItemHeight = 16;
            this.drawingRegions.Items.AddRange(new object[] {
            "Urban",
            "Rural",
            "Nature",
            "Beach",
            "Water"});
            this.drawingRegions.Location = new System.Drawing.Point(371, 36);
            this.drawingRegions.Name = "drawingRegions";
            this.drawingRegions.Size = new System.Drawing.Size(120, 84);
            this.drawingRegions.TabIndex = 4;
            this.drawingRegions.SelectedIndexChanged += new System.EventHandler(this.drawingRegions_SelectedIndexChanged);
            // 
            // drawingLines
            // 
            this.drawingLines.FormattingEnabled = true;
            this.drawingLines.ItemHeight = 16;
            this.drawingLines.Items.AddRange(new object[] {
            "Highway",
            "Road",
            "Creek"});
            this.drawingLines.Location = new System.Drawing.Point(245, 36);
            this.drawingLines.Name = "drawingLines";
            this.drawingLines.Size = new System.Drawing.Size(120, 84);
            this.drawingLines.TabIndex = 3;
            this.drawingLines.SelectedIndexChanged += new System.EventHandler(this.drawingLines_SelectedIndexChanged);
            // 
            // toolState
            // 
            this.toolState.AutoSize = true;
            this.toolState.Location = new System.Drawing.Point(133, 15);
            this.toolState.Name = "toolState";
            this.toolState.Size = new System.Drawing.Size(121, 17);
            this.toolState.TabIndex = 2;
            this.toolState.Text = "Tool Being Used: ";
            // 
            // drawLineButton
            // 
            this.drawLineButton.Location = new System.Drawing.Point(136, 65);
            this.drawLineButton.Name = "drawLineButton";
            this.drawLineButton.Size = new System.Drawing.Size(103, 23);
            this.drawLineButton.TabIndex = 1;
            this.drawLineButton.Text = "Draw Line";
            this.drawLineButton.UseVisualStyleBackColor = true;
            this.drawLineButton.Click += new System.EventHandler(this.roadButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(136, 36);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(103, 23);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.paneButton_Click);
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 136);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(1272, 512);
            this.canvasPanel.TabIndex = 1;
            this.canvasPanel.Click += new System.EventHandler(this.canvasPanel_Click);
            this.canvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPanel_Paint);
            this.canvasPanel.MouseHover += new System.EventHandler(this.canvasPanel_MouseHover);
            // 
            // perpendicularTool
            // 
            this.perpendicularTool.Location = new System.Drawing.Point(12, 65);
            this.perpendicularTool.Name = "perpendicularTool";
            this.perpendicularTool.Size = new System.Drawing.Size(115, 23);
            this.perpendicularTool.TabIndex = 15;
            this.perpendicularTool.Text = "Perpendicular";
            this.perpendicularTool.UseVisualStyleBackColor = true;
            this.perpendicularTool.Click += new System.EventHandler(this.perpendicularTool_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 648);
            this.Controls.Add(this.canvasPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.Text = "Fictional Mapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Button drawLineButton;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Label toolState;
        private System.Windows.Forms.ListBox drawingLines;
        private System.Windows.Forms.ListBox drawingRegions;
        private System.Windows.Forms.Button drawRegionButton;
        private System.Windows.Forms.ListBox shieldType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox shieldBoxToggle;
        private System.Windows.Forms.TextBox routeNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox selectionNameBox;
        private System.Windows.Forms.Button parallelButton;
        private System.Windows.Forms.Button movePointsButton;
        private System.Windows.Forms.Button intersectionTool;
        private System.Windows.Forms.Button perpendicularTool;
    }
}

