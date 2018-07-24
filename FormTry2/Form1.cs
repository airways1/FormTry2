using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTry2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TransparencyKey = BackColor;
            //this.BackColor = Color.White;
            panel1.BackColor = Color.Transparent;// Color.FromArgb(25, Color.Black);
            //oldRect = new Size();
            DoubleBuffered = true;
            
        }

        
    

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        const int DragAreaSize = 16;
        const int ReSizeThreshold = 4;

        private Rectangle scrnBounds;
        private Rectangle bottomRightZone;
        private Rectangle topRightZone;
        private Rectangle bottomLeftZone;
        private Rectangle topLeftZone;
        private Rectangle centerZone;
        private Rectangle oldRect;
        // for use when making the Form movable
        private int mdx, mdy, dx, dy;

        private bool mouseIsUp = true;

  
        private void updateme()
        {
            Color hiColor = Color.LawnGreen;

            int thickness = DragAreaSize / 4;//it's up to you
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(hiColor, thickness))
            {
                Graphics g = panel1.CreateGraphics();

              //  if (oldRect.Width ==0 && oldRect.Height==0)
              //      oldRect = panel1.ClientSize;
                g.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          panel1.ClientSize.Width - thickness,
                                                          panel1.ClientSize.Height - thickness));
                //
                //scrnBounds = this.DisplayRectangle; //debug 說 = ClientArea
                scrnBounds = panel1.DisplayRectangle;// this.DisplayRectangle; //debug 說 = ClientArea

                bottomRightZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
                bottomRightZone.Offset(scrnBounds.Right - DragAreaSize, scrnBounds.Bottom - DragAreaSize);
                g.FillRectangle(new SolidBrush(hiColor), bottomRightZone);

                topRightZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
                topRightZone.Offset(scrnBounds.Right - DragAreaSize, 0);
                g.FillRectangle(new SolidBrush(hiColor), topRightZone);

                topLeftZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
                //topLeftZone.Offset(scrnBounds.Right - DragAreaSize, 0);
                g.FillRectangle(new SolidBrush(hiColor), topLeftZone);

                bottomLeftZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
                bottomLeftZone.Offset(0, scrnBounds.Bottom - DragAreaSize);
                g.FillRectangle(new SolidBrush(hiColor), bottomLeftZone);

                centerZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
                centerZone.Offset((int)(scrnBounds.Width / 2), (int)(scrnBounds.Height / 2));
                g.FillRectangle(new SolidBrush(hiColor), centerZone);
                g.Dispose();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            updateme();
        }
        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    Color hiColor=Color.LawnGreen;

        //        int thickness = DragAreaSize/4;//it's up to you
        //        int halfThickness = thickness / 2;
        //        using (Pen p = new Pen(hiColor, thickness))
        //        {
        //            e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
        //                                                      halfThickness,
        //                                                      panel1.ClientSize.Width - thickness,
        //                                                      panel1.ClientSize.Height - thickness));
        //        //


        //        //scrnBounds = this.DisplayRectangle; //debug 說 = ClientArea
        //        scrnBounds = panel1.DisplayRectangle;// this.DisplayRectangle; //debug 說 = ClientArea

        //        bottomRightZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
        //        bottomRightZone.Offset(scrnBounds.Right - DragAreaSize, scrnBounds.Bottom - DragAreaSize);
        //            e.Graphics.FillRectangle(new SolidBrush(hiColor), bottomRightZone);

        //        topRightZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
        //        topRightZone.Offset(scrnBounds.Right - DragAreaSize, 0);
        //        e.Graphics.FillRectangle(new SolidBrush(hiColor), topRightZone);

        //        topLeftZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
        //        //topLeftZone.Offset(scrnBounds.Right - DragAreaSize, 0);
        //        e.Graphics.FillRectangle(new SolidBrush(hiColor), topLeftZone);

        //        bottomLeftZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
        //        bottomLeftZone.Offset(0, scrnBounds.Bottom - DragAreaSize);
        //        e.Graphics.FillRectangle(new SolidBrush(hiColor), bottomLeftZone);

        //        centerZone = new Rectangle(00, 00, DragAreaSize, DragAreaSize);
        //        centerZone.Offset((int)(scrnBounds.Width /2), (int)(scrnBounds.Height/2));
        //        e.Graphics.FillRectangle(new SolidBrush(hiColor), centerZone);

        //    }

        //}
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_NCHITTEST = 0x0084;
        //    const int HTTRANSPARENT = (-1);

        //    if (m.Msg == WM_NCHITTEST)
        //        //non client hittest 
        //        // 把所有的 non client 都設為透明 
        //    {
        //        m.Result = (IntPtr)HTTRANSPARENT;
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
        //        return cp;
        //    }
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    const int wmNcHitTest = 0x84;
        //    const int htLeft = 10;
        //    const int htRight = 11;
        //    const int htTop = 12;
        //    const int htTopLeft = 13;
        //    const int htTopRight = 14;
        //    const int htBottom = 15;
        //    const int htBottomLeft = 16;
        //    const int htBottomRight = 17;

        //    if (m.Msg == wmNcHitTest)
        //    {
        //        Console.Write(true + "\n");
        //        int x = (int)(m.LParam.ToInt64() & 0xFFFF);
        //        int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
        //        Point pt = PointToClient(new Point(x, y));
        //        Size clientSize = ClientSize;
        //        //allow resize on the lower right corner
        //        if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
        //            return;
        //        }
        //        //allow resize on the lower left corner
        //        if (pt.X <= 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
        //            return;
        //        }
        //        //allow resize on the upper right corner
        //        if (pt.X <= 16 && pt.Y <= 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(IsMirrored ? htTopRight : htTopLeft);
        //            return;
        //        }
        //        //allow resize on the upper left corner
        //        if (pt.X >= clientSize.Width - 16 && pt.Y <= 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(IsMirrored ? htTopLeft : htTopRight);
        //            return;
        //        }
        //        //allow resize on the top border
        //        if (pt.Y <= 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(htTop);
        //            return;
        //        }
        //        //allow resize on the bottom border
        //        if (pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(htBottom);
        //            return;
        //        }
        //        //allow resize on the left border
        //        if (pt.X <= 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(htLeft);
        //            return;
        //        }
        //        //allow resize on the right border
        //        if (pt.X >= clientSize.Width - 16 && clientSize.Height >= 16)
        //        {
        //            m.Result = (IntPtr)(htRight);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        Console.Write(false + "\n");
        //    }
        //    base.WndProc(ref m);
        //}

        private int kind=0;
        private Point ppnt;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            kind = 0;
            if (topLeftZone.Contains(e.Location))
            {
                mdx = e.X;
                mdy = e.Y;
                oldRect = panel1.ClientRectangle;
                ppnt = panel1.PointToScreen(new Point(e.X, e.Y));
                //ppnt = new Point(e.X, e.Y);
                kind = 1;
                panel1.MouseMove += Panel1_MouseMove;
                
                //Console.Write("down\n");
            }
            if (topRightZone.Contains(e.Location))
            {
                mdx = e.X;
                mdy = e.Y;
                oldRect = panel1.ClientRectangle;
                ppnt = panel1.PointToScreen(new Point(e.X, e.Y));

                kind = 2;
                panel1.MouseMove += Panel1_MouseMove;

                //Console.Write("down\n");
            }

            if (bottomLeftZone.Contains(e.Location))
            {
                mdx = e.X;
                mdy = e.Y;
                oldRect = panel1.ClientRectangle;
                ppnt = panel1.PointToScreen(new Point(e.X, e.Y));

                kind = 3;
                panel1.MouseMove += Panel1_MouseMove;

                //Console.Write("down\n");
            }

            if (bottomRightZone.Contains(e.Location))
            {
                mdx = e.X;
                mdy = e.Y;
                oldRect = panel1.ClientRectangle;
                ppnt = panel1.PointToScreen(new Point(e.X, e.Y));

                kind = 4;
                panel1.MouseMove += Panel1_MouseMove;

                //Console.Write("down\n");
            }

            if (centerZone.Contains(e.Location))
            {
                mdx = e.X;
                mdy = e.Y;
                oldRect = panel1.ClientRectangle;
                oldRect.Y = panel1.Top;
                oldRect.X = panel1.Left;

                ppnt = panel1.PointToScreen(new Point(e.X, e.Y));

                kind = 5;
                panel1.MouseMove += Panel1_MouseMove;

                
            }
            Console.WriteLine(kind);
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            kind = 0;
            panel1.MouseMove -= Panel1_MouseMove;
            panel1.Invalidate();
            //UpdateScreenSize();
            Console.WriteLine(kind);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        //不能放在form的事件mouseMove中
        {
            if (kind == 0) return;
            Point cpnt = panel1.PointToScreen(new Point(e.X, e.Y));
            //Point cpnt =  new Point(e.X, e.Y);
            //dx =  e.X - mdx;//mdx,mdy是上次mouse down的滑鼠座標點
            //dy =  e.Y - mdy;
            dx = cpnt.X - ppnt.X;
            dy = cpnt.Y - ppnt.Y;
            if (Math.Abs(dx) < ReSizeThreshold && Math.Abs(dy) < ReSizeThreshold) return;
            Point pnt =  panel1.PointToScreen(new Point(e.X,e.Y)); //new Point(e.X, e.Y); //
            switch (kind)
            {
                case 1:
                    panel1.Top = cpnt.Y;
                    panel1.Left = cpnt.X;
                    panel1.Width = oldRect.Width- dx;
                    panel1.Height = oldRect.Height - dy;
                    //Console.WriteLine("("+this.Top+"," +this.Left+")("+this.Width+","+this.Height+")("+dx+","+dy+")");
                    Console.WriteLine("-(" + ppnt.X + "," + ppnt.Y + ")(" + cpnt.X + "," + cpnt.Y + ")(" + dx + "," + dy + ")");

                    break;
                case 2://右上
                    panel1.Top = ppnt.Y+dy;
                    //this.Width = pnt.X;
                    panel1.Width = oldRect.Width + dx;
                    panel1.Height = oldRect.Height - dy;

                    break;
                case 3: //左下
                    panel1.Left = pnt.X;
                    panel1.Width = oldRect.Width - dx;
                    panel1.Height = oldRect.Height + dy;
                    break;

                case 4:
                    //panel1.Width = pnt.X; //視窗的寬度設為panel的寬度
                    //panel1.Height = pnt.Y;
                    panel1.Width = oldRect.Width + dx;
                    panel1.Height = oldRect.Height + dy;

                    break;

                case 5:
                    //Point tl = panel1.PointToScreen(new Point(oldRect.X, oldRect.Y));
                    panel1.Top = oldRect.Y+dy;
                    panel1.Left = oldRect.X+dx;
                    break;

            }
            //updateme();
            this.Invalidate(); //只用上面會留下殘影
            
        }
    }
}
