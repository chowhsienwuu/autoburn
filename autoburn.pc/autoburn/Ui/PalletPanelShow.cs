using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Autoburn.Ui
{
    public partial class PalletPanelShow : UserControl
    {
        public PalletPanelShow()
        {
            InitializeComponent();
            InitializeComponent2();

            initShow();
        }

        ChartArea chartAreaMain;
        Series SeriesBurnOK;
        Series SeriesBurnNG;
        Series SeriesNotBurn;

        private void InitializeComponent2()
        {
            //图表区域
            foreach (ChartArea c in chart1.ChartAreas)
            {
                if (c.Name.Equals("ChartAreaMain"))
                {
                    chartAreaMain = c;
                }
            }

            //点区城
            foreach (Series s in chart1.Series)
            {
                if (s.Name.Equals("SeriesBurnOk"))
                {
                    SeriesBurnOK = s;
                }
                else if (s.Name.Equals("SeriesBurnNG"))
                {
                    SeriesBurnNG = s;
                }
                else if (s.Name.Equals("SeriesNotBurn"))
                {
                    SeriesNotBurn = s;
                }
            }


            //图例 
            SeriesBurnOK.MarkerBorderColor = System.Drawing.Color.Navy;
            SeriesBurnOK.MarkerBorderWidth = _PointMartetSize;
            SeriesBurnOK.MarkerColor = System.Drawing.Color.Green;
            SeriesBurnOK.MarkerSize = 10;
            SeriesBurnOK.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;

            SeriesBurnNG.MarkerBorderColor = System.Drawing.Color.Navy;
            SeriesBurnNG.MarkerBorderWidth = 10;
            SeriesBurnNG.MarkerColor = System.Drawing.Color.Red;
            SeriesBurnNG.MarkerSize = _PointMartetSize;
            SeriesBurnNG.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;

            SeriesNotBurn.MarkerBorderColor = System.Drawing.Color.Navy;
            SeriesNotBurn.MarkerBorderWidth = 10;
            SeriesNotBurn.MarkerColor = System.Drawing.Color.Gray;
            SeriesNotBurn.MarkerSize = _PointMartetSize;
            SeriesNotBurn.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
        }

        private int _PointMartetSize = 8;
        public const int BURN_STATUS_NOT_BURN = 0;
        public const int BURN_STATUS_BURN_OK = 1;
        public const int BURN_STATUS_BURN_NG = 2;
        public const int BURN_STATUS_EMPTY = 3;

        private int _GridLineWidth = 10;
        private int _PalletColNums = 15;
        private int _PalletRowNums = 7;

        public class PointStatus
        {
            public int x = 0;
            public int y = 0;
            public int status = BURN_STATUS_NOT_BURN;
        }

        List<PointStatus> _AllPointStatus = new List<PointStatus>();

        private void initShow()
        {
            SetColX(_PalletColNums);
            SetRowY(_PalletRowNums);

            //clear old point.
            SeriesBurnOK.Points.Clear();
            SeriesBurnNG.Points.Clear();
            SeriesNotBurn.Points.Clear();

            _AllPointStatus.Clear();
            for (int y = 0; y < _PalletRowNums; y++)
            {
                for (int x = 0; x < _PalletColNums; x++)
                {
                    PointStatus p = new PointStatus();
                    p.x = x;
                    p.y = y;
                    p.status = BURN_STATUS_NOT_BURN;
                    _AllPointStatus.Add(p);
                }
            }

            ReFreshPoint();
        }

        public  void SetColRowNums(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                _PalletColNums = x;
                _PalletRowNums = y;
                initShow();
            }
        }

        private void ClearPointAtXY(Series series, int x, int y)
        {
            if (series == null || x <= 0 || y <= 0)
            {
                return;
            }
            DataPoint datapoint = null;
            foreach(var point in series.Points)
            {
                 if (Math.Abs(point.XValue - x - 0.5) < 0.1 && Math.Abs(point.YValues[0] - y - 0.5) < 0.1)
                {
                 //   Console.Out.WriteLine("found point " + point.XValue + ":" + point.YValues[0]);
                    datapoint = point;
                }
            }
            if (datapoint != null)
            {
                series.Points.Remove(datapoint);
            }
        }

        public void SetXYPointStatus(int x, int y, int Status)
        {
            foreach (var p in _AllPointStatus)
            {
                if (p.x == x && p.y == y)
                {
                    p.status = Status;
                    ReFreshPoint();
                }
            }
        }

        private void ReFreshPoint()
        {
            SeriesNotBurn.Points.Clear();
            SeriesBurnOK.Points.Clear();
            SeriesBurnNG.Points.Clear();

            foreach (var p in _AllPointStatus)
            {
                switch (p.status)
                {
                    case BURN_STATUS_NOT_BURN:
                        SeriesNotBurn.Points.AddXY(p.x + 0.5, p.y + 0.5);
                        break;
                    case BURN_STATUS_BURN_OK:
                        SeriesBurnOK.Points.AddXY(p.x + 0.5, p.y + 0.5);
                        break;
                    case BURN_STATUS_BURN_NG:
                        SeriesBurnNG.Points.AddXY(p.x + 0.5, p.y + 0.5);
                        break;
                    case BURN_STATUS_EMPTY:
                        break;
                    default:
                        break;
                }
            }
        }

        private  void SetColX(int maxx)
        {
            //坐标每过1都有网络线.                                     vvg 
            chartAreaMain.AxisX.Interval = 1D;
            chartAreaMain.AxisX.IntervalOffset = 1D;
            chartAreaMain.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartAreaMain.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            //坐标轴的宽度
            chartAreaMain.AxisX.LineWidth = _GridLineWidth;

            //网格的宽度与范围.
            chartAreaMain.AxisX.MajorGrid.LineWidth = _GridLineWidth;
            chartAreaMain.AxisX.Maximum = maxx;
            chartAreaMain.AxisX.Minimum = 0D;
        }

        private void SetRowY(int maxy)
        {
            //坐标每过1都有网络线.                                     vvg 
            chartAreaMain.AxisY.Interval = 1D;
            chartAreaMain.AxisY.IntervalOffset = 1D;
            chartAreaMain.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartAreaMain.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            //坐标轴的宽度
            chartAreaMain.AxisY.LineWidth = _GridLineWidth;

            //网格的宽度与范围.
            chartAreaMain.AxisY.MajorGrid.LineWidth = _GridLineWidth;
            chartAreaMain.AxisY.Maximum = maxy;
            chartAreaMain.AxisY.Minimum = 0D;
        }

    }
}
