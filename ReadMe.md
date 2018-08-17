# Dashboard for ASP.NET Core - How to save dashboards to a database

*Files to look at*:

* [Index.cshtml](./CS/SaveDashboardDB/Views/Home/Index.cshtml)
* [DataBaseEditaleDashboardStorage.cs](./CS/SaveDashboardDB/Code/DataBaseEditaleDashboardStorage.cs)
* [Startup.cs](./CS/SaveDashboardDB/Startup.cs#L30)

<p>This example shows how to create a custom dashboard storage in an ASP.NET Core application to allow storing dashboards in a data base. It uses the <a href="https://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.110).aspx">System.Data.SqlClient</a> members to connect to and operate an MS SQL server data base. 
<br><br>
A custom dashboard storage should implement one of the following interfaces:<strong> IDashboardStorage</strong> or <strong>IEditableDashboardStorage</strong>.<br><br>IDashboardStorage provides the capability to open and edit dashboards available in the storage. <br><strong>XDocument LoadDashboard(string dashboardID) </strong>- returns a dashboard by its ID in the XDocument format, which describes the dashboard's object model.
<br>
<strong>IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()</strong> - returns a list of dashboard IDs and Captions available in the data storage.
<br>
<strong>void SaveDashboard(string dashboardID, XDocument dashboard)</strong> - updates the dashboard with new settings by its id.
<br><br>
IEditableDashboardStorage inherits the IDashboardStorage interface and contains one additional method that allows adding new dashboards to the storage.<br><strong>string AddDashboard(XDocument dashboard, string dashboardName)</strong> - takes a dashboard definition with its caption, saves it to the data storage, and returns the ID of a new saved dashboard.<br><br> This example also contains an SQL query and a data base backup file, which can be used to recreate the data base used in this example on your side.
<br><br>
See also: 
<br>
<a href="https://www.devexpress.com/Support/Center/p/T392813">How to save dashboards created in ASPxDashboard to a DataSet</a>
<br>
<a href="https://www.devexpress.com/Support/Center/p/T400693">MVCxDashboard - How to save dashboards to a data base</a>
<br><br>
This example applies to the Dashboard Designer for ASP.NET Core starting with v2017 vol 2. To learn how to achieve this goal in previous versions, refer to the <a href="https://www.devexpress.com/Support/Center/p/T373382">OBSOLETE - ASPxDashboardDesigner - How to save dashboards to a data base</a> example.</p>