# How to set a selection state of a group based on its children selection


<p>This example illustrates how to set a selection state of a group based on its children selection.</p>
<p> </p>
<p>Place ASPxCheckBox to ASPxGridView's GroupRowContent template and handle ASPxCheckBox’ Load event. In this event handler, check if a row is selected. It is possible to get the check box' NamingContainer of the GridViewGroupRowTemplateContainer type and the container index. After that, iterate through the GroupRow child rows and set ASPxCheckBox’ CheckState property. To properly get the number of GroupRow ChildRows, disable the RowCache in ASPxGridView. It is neccessary to enable ASPxGridView's ProcessSelectionChangedOnServer property to process selection changes on the server side.</p>
<p>Also, refer to the <a href="https://www.devexpress.com/Support/Center/Example/Details/E1760">How to implement select/unselect for all rows in a group row</a>  example for detailed information.</p>

<br/>


