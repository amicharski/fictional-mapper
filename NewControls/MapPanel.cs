using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace FictionalMapper.NewControls
{
    public class MapPanel : Panel
    {
        public class HoverEventArgs
        {
            public bool Active { get; set; }

            public HoverEventArgs(bool active)
            {
                Active = active;
            }
        }

        public event EventHandler<HoverEventArgs> Hover;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OnHover(true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnHover(false);
        }

        protected void OnHover(bool active)
        {
            //Debug.WriteLine("HOVERING");
            EventHandler<HoverEventArgs> hover = Hover;
            if (hover != null)
            {
                hover(this, new HoverEventArgs(active));
            }
        }
    }
}
