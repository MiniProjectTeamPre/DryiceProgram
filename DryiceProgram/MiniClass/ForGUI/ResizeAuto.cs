using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class ResizeAuto {
    public ResizeAuto(Form form) {
        //the calling form
        formMain = form;

        //Save initial form size
        formSize = form.ClientSize;

        fontFamily = new List<FontFamily>();
        fontSize = new List<float>();
        controlList = new List<Rectangle>();
        fontStyle = new List<FontStyle>();
    }

    #region =========================================== Input ===========================================
    /// <summary>
    /// For save all control in gui [Position and Size]
    /// </summary>
    private List<Rectangle> controlList { get; set; }
    /// <summary>
    /// For save all Font size in gui
    /// </summary>
    private List<float> fontSize { get; set; }
    /// <summary>
    /// For save all Font Family in gui
    /// </summary>
    private List<FontFamily> fontFamily { get; set; }
    /// <summary>
    /// For save all Font Style in gui
    /// </summary>
    private List<FontStyle> fontStyle { get; set; }
    /// <summary>
    /// For save value size of form
    /// </summary>
    private SizeF formSize { get; set; }
    /// <summary>
    /// For save form Main
    /// </summary>
    private Form formMain { get; set; }
    /// <summary>
    /// For data grid view row header
    /// </summary>
    private bool showRowHeader { get; set; }
    #endregion

    #region =========================================== DisPlay ===========================================

    #endregion

    #region =========================================== Cal ===========================================
    /// <summary>
    /// If you have Datagridview and want to resize the column base on its dimension.
    /// </summary>
    /// <param name="dataGrid">is Datagridview for control</param>
    /// <param name="showRowHeaderSup">is Row of header</param>
    private void DataGridColumnAdjust(DataGridView dataGrid, bool showRowHeaderSup) {
        int intRowHeader = 0;
        const int hscrollbarWidth = 5;
        if (showRowHeaderSup)
        {
            intRowHeader = dataGrid.RowHeadersWidth;
        }
        else
        {
            dataGrid.RowHeadersVisible = false;
        }

        for (int loop = 0; loop < dataGrid.ColumnCount; loop++)
        {
            //in case the datagridview is docked
            if (dataGrid.Dock == DockStyle.Fill)
            {
                dataGrid.Columns[loop].Width = (dataGrid.Width - intRowHeader) / dataGrid.ColumnCount;
            }
            else
            {
                dataGrid.Columns[loop].Width = (dataGrid.Width - intRowHeader - hscrollbarWidth) / dataGrid.ColumnCount;
            }
        }
    }
    /// <summary>
    /// Get all control in gui
    /// </summary>
    /// <param name="form">is form at get all control</param>
    /// <returns>All control</returns>
    private static IEnumerable<Control> GetAllControl(Control form) {
        return form.Controls.Cast<Control>().SelectMany(item =>
            GetAllControl(item)).Concat(form.Controls.Cast<Control>()).Where(control =>
            control.Name != string.Empty);
    }
    #endregion

    #region =========================================== Main ===========================================
    /// <summary>
    /// Get initial size
    /// </summary>
    public void Initial() {
        //call the enumerator
        IEnumerable<Control> controls = GetAllControl(formMain);

        //Loop through the controls
        foreach (Control control in controls)
        {
            //saves control bounds/dimension   
            controlList.Add(control.Bounds);

            //saves control Font.Size
            fontSize.Add(control.Font.Size);

            //Save control Font.FontFamily
            fontFamily.Add(control.Font.FontFamily);

            //Save control Font.Style
            fontStyle.Add(control.Font.Style);

            //If you have datagridview
            if (control.GetType() == typeof(DataGridView))
            {
                DataGridColumnAdjust((DataGridView)control, showRowHeader);
            }
        }
    }
    /// <summary>
    /// Set the resize
    /// </summary>
    public void Resize() {
        //ratio could be greater or less than 1
        double formRatioWidth = (double)formMain.ClientSize.Width / (double)formSize.Width;

        // this one too
        double formRatioHeight = (double)formMain.ClientSize.Height / (double)formSize.Height;

        //reenumerate the control collection
        IEnumerable<Control> controls = GetAllControl(formMain);

        //do not change this value unless you know what you are doing
        int index = -1;
        foreach (Control control in controls)
        {
            // do some math calc

            //increment by 1;
            index += 1;

            //use for sizing
            Size controlSize = new Size((int)(controlList[index].Width * formRatioWidth),
                (int)(controlList[index].Height * formRatioHeight));

            //use for location
            Point controlposition = new Point((int)
            (controlList[index].X * formRatioWidth), (int)(controlList[index].Y * formRatioHeight));

            //set bounds  
            //Put together
            control.Bounds = new Rectangle(controlposition, controlSize);

            //Assuming you have a datagridview inside a form()
            //if you want to show the row header, replace the false statement of 
            //showRowHeader on top/public declaration to true;
            if (control.GetType() == typeof(DataGridView))
            {
                DataGridColumnAdjust((DataGridView)control, showRowHeader);
            }

            //Font AutoSize
            try
            {
                control.Font = new Font(fontFamily[index],
            (float)((fontSize[index] * formRatioWidth / 2) + (fontSize[index] * formRatioHeight / 2)),
            fontStyle[index]);
            } catch { }
        }
    }
    #endregion
}
