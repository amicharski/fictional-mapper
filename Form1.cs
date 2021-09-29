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
        public RegionType mainRegionStyle;
        private bool mouseInPanel = false;
        public LineType currentLineType;
        public RegionType currentRegionType;
        public Pen lineMain;
        public Pen lineOutline;
        public Pen drawing;
        public SolidBrush region;
        public Graphics g;
        public Graphics tg;
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
            mainRegionStyle = RegionType.URBAN_LAND;
            g = canvasPanel.CreateGraphics();
            tg = canvasPanel.CreateGraphics();
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

        private ArrayList sortElements()    // Absolutely terrible O(n^3) algorithm
        {                                   // Sort the list so regions are first, then creeks, then the rest of the lines
            ArrayList tmp = new ArrayList();
            foreach (object o in elements)
            {
                if (o.GetType() == Type.GetType("FictionalMapper.Line", false, false))
                {
                    tmp.Add(o);
                }
            }
            foreach (object o in elements)
            {
                if (o.GetType() == Type.GetType("FictionalMapper.Line", false, false))
                {
                    if (((Line)o).lineType == LineType.CREEK)
                    {
                        tmp.Add(o);
                    }
                }
            }
            foreach (object o in elements)
            {
                if (o.GetType() == Type.GetType("FictionalMapper.Region", false, false))
                {
                    tmp.Add(o);
                }
            }
            tmp.Reverse();
            return tmp;
        }

        private void canvasPanel_OnMouseEnter(object sender, EventArgs e)
        {
            mouseInPanel = true;
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

        private void canvasPanel_OnMouseLeave(object sender, EventArgs e)
        {
            mouseInPanel = false;
            Cursor.Current = Cursors.UpArrow;
        }

        private void canvasPanel_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void canvasPanel_Click(object sender, EventArgs e)
        {
            if(tool == Tool.LINE || tool == Tool.REGION)
            {
                Point p = canvasPanel.PointToClient(Cursor.Position);
                g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(new Point(p.X - 3, p.Y - 3), new Size(6, 6)));
                points.Add(p);
            } else if(tool == Tool.PARALLEL)
            {

            }
        }

        private void drawTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private Color getRegionColor(RegionType rt)
        {
            switch (rt)
            {
                case RegionType.WATER:
                    return Colors.water;
                case RegionType.BEACH:
                    return Colors.beach;
                case RegionType.NATURE_LAND:
                    return Colors.natureLand;
                case RegionType.RURAL_LAND:
                    return Colors.ruralLand;
                case RegionType.URBAN_LAND:
                    return Colors.urbanLand;
                default:
                    throw new Exception("Invalid color");
            }
        }

        private void redraw()
        {
            try
            {
                g.Clear(getRegionColor(mainRegionStyle));
                selectionName = selectionNameBox.Text;
                switch (tool)
                {
                    case Tool.LINE:
                        Line l = new Line();
                        l.roadName = selectionName;
                        l.points = new Point[points.Count];
                        points.CopyTo(l.points);
                        l.lineType = currentLineType;
                        elements.Add(l);
                        break;
                    case Tool.REGION:
                        Region r = new Region();
                        r.points = new Point[points.Count];
                        points.CopyTo(r.points);
                        r.regionType = currentRegionType;
                        elements.Add(r);
                        break;
                }
                elements = sortElements();
                foreach (object o in elements)
                {
                    int viewableDistance = 0;
                    if (o.GetType() == Type.GetType("FictionalMapper.Region", false, false))
                    {
                        region.Color = getRegionColor(((Region)o).regionType);
                        g.FillPolygon(region, ((Region)o).points.ToArray());
                    }
                    else if (o.GetType() == Type.GetType("FictionalMapper.Line", false, false))
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

                        for (int i = 1; i < ((Line)o).points.Length; i++)
                        {
                            if (!(((Line)o).lineType == LineType.CREEK))
                            {
                                g.DrawLine(lineOutline, ((Line)o).points[i - 1], ((Line)o).points[i]);
                            }
                            viewableDistance += distance.Invoke(((Line)o).points[i - 1], ((Line)o).points[i]);
                            g.DrawLine(lineMain, ((Line)o).points[i - 1], ((Line)o).points[i]);
                        }
                    }
                    if (viewableDistance > selectionName.Length * 5)
                    {
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
            } catch (ArgumentException nex)
            {

            }
        }

        private void roadButton_Click(object sender, EventArgs e)   // drawLineButton
        {
            points.Clear();
            redraw();
            tool = Tool.LINE;
            toolState.Text = "Tool Being Used: Line";
        }

        private void paneButton_Click(object sender, EventArgs e) // viewButton
        {
            redraw();
            tool = Tool.VIEW;
            toolState.Text = "Tool Being Used: View";
        }

        private void drawRegionButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            redraw();
            tool = Tool.REGION;
            toolState.Text = "Tool Being Used: Region";
        }

        private void parallelButton_Click(object sender, EventArgs e)
        {
            redraw();
            tool = Tool.PARALLEL;
            toolState.Text = "Tool Being Used: Parallel";
        }

        private void movePointsButton_Click(object sender, EventArgs e)
        {
            redraw();
            tool = Tool.MOVE_POINTS;
            toolState.Text = "Tool Being Used: Move Points";

            foreach(object o in elements)
            {
                if(o.GetType() == Type.GetType("FictionalMapper.Line", false, false))
                {
                    foreach(Point p in ((Line)o).points)
                    {
                        g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(new Point(p.X - 3, p.Y - 3), new Size(6, 6)));
                    }
                } else if(o.GetType() == Type.GetType("FictionalMapper.Region", false, false))
                {
                    foreach (Point p in ((Region)o).points)
                    {
                        g.DrawEllipse(new Pen(Color.Black, 1), new Rectangle(new Point(p.X - 3, p.Y - 3), new Size(6, 6)));
                    }
                }
            }
        }

        private void intersectionsTool_Click(object sender, EventArgs e)
        {
            redraw();
            tool = Tool.INTERSECTION;
            toolState.Text = "Tool Being Used: Intersection";
        }

        private void perpendicularTool_Click(object sender, EventArgs e)
        {
            redraw();
            tool = Tool.PERPENDICULAR;
            toolState.Text = "Tool Being Used: Perpendicular";
        }

        private void mainRegionStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainRegionStyle = (RegionType)mainRegionStyleBox.SelectedIndex;
            redraw();
        }
    }
    public enum Tool
    {
        VIEW = 0,
        LINE = 1,
        REGION = 2,
        MOVE_POINTS = 3,
        PARALLEL = 4,
        PERPENDICULAR = 5,
        INTERSECTION = 6
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
        public Point[] points { get; set; }
        public LineType lineType { get; set; }
        public override string ToString()
        {
            return "lineType: " + lineType.ToString();
        }
    }

    public class Region
    {
        public Point[] points { get; set; }
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
