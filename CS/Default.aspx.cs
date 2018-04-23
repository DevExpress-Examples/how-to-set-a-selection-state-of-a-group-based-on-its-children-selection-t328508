using DevExpress.Web;
using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] parameters = e.Parameters.Split(';');
        int index = int.Parse(parameters[0]);
        bool isGroupRowSelected = false;
        CheckState currentState = (CheckState)Enum.Parse(typeof(CheckState), parameters[1]);
        switch (currentState)
        {
            case CheckState.Indeterminate:
            case CheckState.Checked:
                isGroupRowSelected = true;
                break;
            case CheckState.Unchecked:
                isGroupRowSelected = false;
                break;
        }
        for (int i = 0; i < ASPxGridView1.GetChildRowCount(index); i++)
        {
            DataRow row = ASPxGridView1.GetChildDataRow(index, i);
            ASPxGridView1.Selection.SetSelectionByKey(row["ProductID"], isGroupRowSelected);
        }
    }

    protected void cb_Init(object sender, EventArgs e)
    {
        ASPxCheckBox checkBox = sender as ASPxCheckBox;
        GridViewGroupRowTemplateContainer container = checkBox.NamingContainer as GridViewGroupRowTemplateContainer;
        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s, e){{ grid.PerformCallback('{0};' + s.GetCheckState()); }}", container.VisibleIndex);
    }

    protected void cb_Load(object sender, EventArgs e)
    {
        ASPxCheckBox checkBox = sender as ASPxCheckBox;
        GridViewGroupRowTemplateContainer container = checkBox.NamingContainer as GridViewGroupRowTemplateContainer;
        if (ASPxGridView1.Selection.Count != 0)
        {
            int rowInGroupCount = ASPxGridView1.GetChildRowCount(container.VisibleIndex);
            int countToCompare = 0;
            for (int j = 0; j < rowInGroupCount; j++)
            {
                DataRow row = ASPxGridView1.GetChildDataRow(container.VisibleIndex, j);
                var key = row["ProductID"];
                if (ASPxGridView1.Selection.IsRowSelectedByKey(key))
                    countToCompare++;
            }
            if (rowInGroupCount == countToCompare)
                checkBox.CheckState = CheckState.Checked;
            else if (rowInGroupCount > countToCompare && countToCompare != 0)
                checkBox.CheckState = CheckState.Indeterminate;
            else if (countToCompare == 0)
                checkBox.CheckState = CheckState.Unchecked;
        }
        else
            checkBox.CheckState = CheckState.Unchecked;
    }
}