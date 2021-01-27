# Dashboard for ASP.NET Core - How to load and save dashboards from/to a database

*Files to look at*:

* [Index.cshtml](./CS/SaveDashboardDB/Views/Home/Index.cshtml)
* [DataBaseEditaleDashboardStorage.cs](./CS/SaveDashboardDB/Code/DataBaseEditaleDashboardStorage.cs)
* [Startup.cs](./CS/SaveDashboardDB/Startup.cs#L30)

<p>This example shows how to create custom dashboard storage in an ASP.NET Core application and to store dashboards in a database. Here, you see <a href="https://msdn.microsoft.com/en-us/library/system.data.sqlclient(v=vs.110).aspx">System.Data.SqlClient</a> members that allow you to connect to an MS SQL server database and operate it.
<br><br>
Custom dashboard storage should implement either <strong>IDashboardStorage</strong> or <strong>IEditableDashboardStorage</strong>.
<br><br>
<strong>IDashboardStorage</strong> supports the ability to open and edit dashboards available in the storage.
<br>
<strong>XDocument LoadDashboard(string dashboardID) </strong> - returns a dashboard by its ID in the XDocument format, which describes the dashboard's object model.
<br>
<strong>IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()</strong> - returns a list of dashboard IDs and Captions available in the data storage.
<br>
<strong>void SaveDashboard(string dashboardID, XDocument dashboard)</strong> - updates the dashboard with new settings by its id.
<br><br>
<strong>IEditableDashboardStorage</strong> inherits the <strong>IDashboardStorage</strong> interface and contains an extra method that adds new dashboards to the storage.
<br>
<strong>string AddDashboard(XDocument dashboard, string dashboardName)</strong> - takes a dashboard definition with its caption, saves it to the data storage, and returns the ID of a new saved dashboard.
<br><br>
Additionally, this example contains an SQL file ([SavedDashboards.sql](./CS/SaveDashboardDB/SavedDashboards.sql)), which can be used to recreate a database used in this example on your side. Do no forget to update the connection string in the <strong>appsettings.json</strong> file to make it valid in your environment.
<br><br>
See also: 
<br>
<a href="https://www.devexpress.com/Support/Center/p/T392813">How to save dashboards created in ASPxDashboard to a DataSet</a>
<br>
<a href="https://www.devexpress.com/Support/Center/p/T400693">MVCxDashboard - How to save dashboards to a database</a>
<br><br>
The approach from this example applies to the Dashboard Designer for ASP.NET Core starting with v2017 vol 2. For previous versions, refer to the <a href="https://www.devexpress.com/Support/Center/p/T373382">OBSOLETE - ASPxDashboardDesigner - How to save dashboards to a database</a> example.
