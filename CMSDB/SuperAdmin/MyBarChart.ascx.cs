using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class SuperAdmin_MyBarChart : System.Web.UI.UserControl
{


    private String _sXAxisTitle;
    private String _sChartTitle;
    private Int32 _iUserWidth = 300;
    private String[] _sYAxisItems;
    private Int32[] _iYAxisValues;

    public Int32 UserWidth
    {
        get { return _iUserWidth; }
        set { _iUserWidth = value; }
    }

    public Int32[] YAxisValues
    {
        get { return _iYAxisValues; }
        set { _iYAxisValues = value; }
    }

    public String[] YAxisItems
    {
        get { return _sYAxisItems; }
        set { _sYAxisItems = value; }
    }

    public String XAxisTitle
    {
        get { return _sXAxisTitle; }
        set { _sXAxisTitle = value; }
    }

    public String ChartTitle
    {
        get { return _sChartTitle; }
        set { _sChartTitle = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {


        // As long as we have values to display, do so
        if (_iYAxisValues != null)
        {

            // Color array
            String[] sColor = new String[9];
            //sColor[0] = "#C9D651";
            //sColor[1] = "#D6B551";
            //sColor[2] = "#7C9CB3";
            //sColor[3] = "#2A90C7";
            //sColor[4] = "#74BADF";
            //sColor[5] = "#C6ECCE";
            //sColor[6] = "#5A5E57";
            //sColor[7] = "pink";
            //sColor[8] = "#E6D1B3";

            sColor[0] = "BarChartRow1";
            sColor[1] = "BarChartRow2";
            sColor[2] = "BarChartRow3";
            sColor[3] = "BarChartRow4";
            sColor[4] = "BarChartRow5";
            sColor[5] = "BarChartRow6";
            sColor[6] = "BarChartRow7";
            sColor[7] = "BarChartRow8";
            sColor[8] = "BarChartRow9";

            


            // Initialize the color category
            Int32 iColor = 0;

            // Display the chart title
            lblChartTitle.Text = _sChartTitle;

            // Get the largest value from the available items
            Int32 iMaxVal = 0;
            for (int i = 0; i < _iYAxisValues.Length; i++)
            {
                if (_iYAxisValues[i] > iMaxVal)
                    iMaxVal = _iYAxisValues[i];
            }

            // Take the user-provided maximum width of the chart, and divide it by the
            // largest value in our valueset to obtain the modifier
            if (iMaxVal == 0)
                iMaxVal = 1;
            Int32 iMod = Math.Abs(_iUserWidth / iMaxVal);

            // This will be the string holder for our actual bars.
            String sOut = "";

            // Render a bar for each item
            for (int i = 0; i < _iYAxisValues.Length; i++)
            {

                // Only display this item if we have a value to display
                if (_iYAxisValues[i] > 0)
                {

                    sOut += "<tr><td align=right class='HelpInputCss' width='80px;'  nobr nowrap>&nbsp;&nbsp;" + _sYAxisItems[i] + "&nbsp;&nbsp;</td>";
                    sOut += "<td align=left>" + RenderItem(_iYAxisValues[i], iMod, sColor[iColor]) + "</td></tr>";
                    iColor++;

                    // If we have reached the end of our color array, start over
                    if (iColor > 8) iColor = 0;
                }
            }

            // Place the rendered string in the appropriate label
            lblItems.Text = sOut;

            // Drop in the Y Axis label
            lblXAxisTitle.Text = _sXAxisTitle;
        }
    }

    private String RenderItem(Int32 iVal, Int32 iMod, String sColor)
    {
        //String sRet = "";
        //sRet += "<table border=0 bgcolor=" + sColor + " cellpadding=0 cellspacing=0><tr>";
        //sRet += "<td align=center width=" + (iVal * iMod) + " nobr nowrap>";
        //sRet += "<b>" + iVal + "</b>";
        //sRet += "</tr><td></table>";
        //return sRet;

        StringBuilder sb = new StringBuilder();
        //sb.Append("<table border='0' bgcolor='" + sColor + "' cellpadding='0' cellspacing='0'><tr>");
        sb.Append("<table border='0'  cellpadding='0' cellspacing='0'><tr>");
        sb.Append("<td align='center' class='" + sColor + "' width='" + (iVal * iMod) + "' nobr nowrap>");
        sb.Append("<b>" + iVal + "</b>");
        sb.Append("</tr><td></table>");
        return sb.ToString();

    }
}
