using ProjectLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineIntersectionTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIntersection_Click(object sender, EventArgs e)
        {
            string line1point1x = line1Point1X.Text;
            string line1point1y = line1Point1Y.Text;
            string line1point2x = line1Point2X.Text;
            string line1point2y = line1Point2Y.Text;

            string line2point1x = line2Point1X.Text;
            string line2point1y = line2Point1Y.Text;
            string line2point2x = line2Point2X.Text;
            string line2point2y = line2Point2Y.Text;

            bool success = areAllPointsValid(line1point1x, line1point1y, line1point2x, line1point2y, line2point1x, line2point1y, line2point2x, line2point2y);

            if (success)
            {

                int l2point1X = int.Parse(line2point1x);
                int l2point1Y = int.Parse(line2point1y);
                int l2point2X = int.Parse(line2point2x);
                int l2point2Y = int.Parse(line2point2y);

                int l1point1X = int.Parse(line1point1x);
                int l1point1Y = int.Parse(line1point1y);
                int l1point2X = int.Parse(line1point2x);
                int l1point2Y = int.Parse(line1point2y);

                LineSegment line1 = new LineSegment(l1point1X, l1point1Y, l1point2X, l1point2Y);
                LineSegment line2 = new LineSegment(l2point1X, l2point1Y, l2point2X, l2point2Y);

                bool intersection = LineSegmentUtil.SegIntersect(line1, line2);

                if (intersection)
                {
                    labelResult.Text = "Lines are intersecting";
                }
                else
                {
                    labelResult.Text = "Lines are not intersecting";
                }
            }
            else {
                MessageBox.Show("Enter valid numbers in all boxes");
            }
        }

        bool validatePoint(string num) {

            Regex pattern = new Regex("[0-9]");

            if (string.IsNullOrWhiteSpace(num))
            {
                return false;
            }
            if (pattern.IsMatch(num))
            {
                return true;
            }
            return false;
        }

        bool areAllPointsValid(string l1p1x, string l1p1y, string l1p2x, string l1p2y, string l2p1x, string l2p1y, string l2p2x, string l2p2y) {
            if (validatePoint(l1p1x) && validatePoint(l1p1y) && validatePoint(l1p1x) && validatePoint(l1p2x) && validatePoint(l1p2y) &&
                validatePoint(l2p1x) && validatePoint(l2p1y) && validatePoint(l2p2x) && validatePoint(l2p2y))
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
