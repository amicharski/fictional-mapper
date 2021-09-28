using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FictionalMapper
{
    public partial class Form1 : Form
    {
        public LineType currentLineType;
        public RegionType currentRegionType;
        public Pen lineMain;
        public Pen lineOutline;
        public Pen drawing;
        public Brush region;
        public Graphics g;
        public Tool tool;
        public List<Point> points;
        public ArrayList elements;
        public string selectionName;
        public Func<Point, Point, int> distance = (Point p1, Point p2) =>
        {
            return (int)Math.Sqrt(Math.Pow(p2.Y - p1.Y, 2.0) + Math.Pow(p2.X - p1.X, 2.0));
        };
        public Form1()
        {
            InitializeComponent();
            g = canvasPanel.CreateGraphics();
            tool = Tool.VIEW;
            toolState.Text = "Tool Being Used: View";
            lineMain = new Pen(Colors.highwayInterior, 5);
            lineOutline = new Pen(Colors.highwayExterior, 7);
            drawing = new Pen(Color.Black, 5);
            points = new List<Point>();
            region = new SolidBrush(Colors.water);
            elements = new ArrayList();
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void roadButton_Click(object sender, EventArgs e)
        {
            points.Clear();

            tool = Tool.LINE;
            toolState.Text = "Tool Being Used: Line";
        }

        private void paneButton_Click(object sender, EventArgs e) // viewButton
        {
            g.Clear(Color.White);
            selectionName = selectionNameBox.Text;
            switch (tool)
            {
                case Tool.LINE:
                    Line l = new Line();
                    l.roadName = selectionName;
                    l.points = points;
                    l.lineType = currentLineType;
                    elements.Add(l);
                    break;
                case Tool.REGION:
                    Region r = new Region();
                    r.points = points;
                    r.regionType = currentRegionType;
                    elements.Add(r);
                    break;
            }
            
            foreach(object o in elements)
            {
                int viewableDistance = 0;
                if (o.GetType() == Type.GetType("FictionalMapper.Line", false, false))
                {
                    switch (((Line)o).lineType)
                    {
                        case LineType.HIGHWAY:
                            lineOutline.Color = Colors.highwayExterior;
                            lineMain.Color = Colors.highwayInterior;
                            break;
                        case LineType.ROAD:
                            lineOutline.Color = Colors.roadExterior;
                            lineMain.Color = Colors.roadInterior;
                            break;
                        case LineType.CREEK:
                            lineMain.Color = Colors.water;
                            break;
                    }
                    
                    for (int i = 1; i < ((Line)o).points.Count; i++)
                    {
                        if(!(((Line)o).lineType == LineType.CREEK))
                        {
                            g.DrawLine(lineOutline, ((Line)o).points[i - 1], ((Line)o).points[i]);
                        }
                        viewableDistance += distance.Invoke(((Line)o).points[i - 1], ((Line)o).points[i]);
                        g.DrawLine(lineMain, ((Line)o).points[i - 1], ((Line)o).points[i]);
                    }
                } else if(o.GetType() == Type.GetType("FictionalMapper.Region", false, false))
                {
                    g.FillPolygon(region, ((Region)o).points.ToArray());
                }
                //MessageBox.Show("viewableDistance: " + viewableDistance.ToString());
                if (viewableDistance > selectionName.Length * 5)
                {
                    //MessageBox.Show(((Line)o).roadName);
                    Label label = new Label();
                    label.Text = ((Line)o).roadName;
                    label.Location = ((Line)o).points[1];
                    label.Font = new Font("Calibri", 18);
                    label.ForeColor = Color.Black;
                    label.Padding = new Padding(6);
                    label.Visible = true;
                    Controls.Add(label);
                    //write road in between text
                }
            }
            tool = Tool.VIEW;
            toolState.Text = "Tool Being Used: View";
        }

        private void canvasPanel_MouseHover(object sender, EventArgs e)
        {
            switch (tool)
            {
                case Tool.VIEW:
                    Cursor.Current = Cursors.Hand;
                    break;
                case Tool.LINE:
                case Tool.REGION:
                    Cursor.Current = Cursors.Cross;
                    break;
            }
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void canvasPanel_Click(object sender, EventArgs e)
        {
            Point p = canvasPanel.PointToClient(Cursor.Position);
            g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(new Point(p.X-3, p.Y-3), new Size(6, 6)));
            points.Add(p);
        }

        private void drawTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void drawRegionButton_Click(object sender, EventArgs e)
        {
            points.Clear();

            tool = Tool.REGION;
            toolState.Text = "Tool Being Used: Region";
        }

        private void drawingLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drawingLines.SelectedItem.ToString())
            {
                case "Highway":
                    currentLineType = LineType.HIGHWAY;
                    break;
                case "Road":
                    currentLineType = LineType.ROAD;
                    break;
                case "Creek":
                    currentLineType = LineType.CREEK;
                    break;
            }
        }

        private void drawingRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drawingRegions.SelectedItem.ToString())
            {
                case "Urban":
                    currentRegionType = RegionType.URBAN_LAND;
                    break;
                case "Rural":
                    currentRegionType = RegionType.RURAL_LAND;
                    break;
                case "Nature":
                    currentRegionType = RegionType.NATURE_LAND;
                    break;
                case "Beach":
                    currentRegionType = RegionType.BEACH;
                    break;
                case "Water":
                    currentRegionType = RegionType.WATER;
                    break;
            }
        }

        private void shieldBosToggle_CheckedChanged(object sender, EventArgs e)
        {
            shieldType.Enabled = shieldBoxToggle.Checked;
            routeNumber.Enabled = shieldBoxToggle.Checked;
        }
        private void routeNumber_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void routeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    public enum Tool
    {
        VIEW = 0,
        LINE = 1,
        REGION = 2
    }
    public enum LineType
    {
        HIGHWAY = 0,
        ROAD = 1,
        CREEK = 2
    }
    public enum RegionType
    {
        URBAN_LAND = 0,
        RURAL_LAND = 1,
        NATURE_LAND = 2,
        BEACH = 3, 
        WATER = 4
    }
    public class Line
    {
        public int highwayNum { get; set; }
        public string roadName { get; set; }
        public List<Point> points { get; set; }
        public LineType lineType { get; set; }
        public override string ToString()
        {
            return "lineType: " + this.lineType.ToString();
        }
    }

    public class Region
    {
        public List<Point> points { get; set; }
        public RegionType regionType { get; set; }
    }
    public static class Colors
    {
        // Roads
        public static Color highwayInterior = Color.FromArgb(253, 226, 147);
        public static Color highwayExterior = Color.FromArgb(252, 179, 23);
        public static Color roadInterior = Color.White;
        public static Color roadExterior = Color.FromArgb(221, 221, 228);
        // Land
        public static Color urbanLand = Color.FromArgb(232, 234, 237);
        public static Color ruralLand = Color.FromArgb(187, 226, 198);
        public static Color natureLand = Color.FromArgb(168, 218, 181);
        public static Color beach = Color.FromArgb(255, 236, 196);
        // Water
        public static Color water = Color.FromArgb(160, 196, 252);
    }
}
