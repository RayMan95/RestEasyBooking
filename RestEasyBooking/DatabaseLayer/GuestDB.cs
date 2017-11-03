using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.DatabaseLayer
{
    class GuestDB : DB
    {
        private Collection<Guest> allGuests;
        //private Collection<GuestAccount> allGuestAccounts;
        //private Collection<ReferenceNumber> allRefNumbers;

        #region Properties
        public Collection<Guest> AllGuests
        {
            get { return allGuests; }
        }
        #endregion
        public GuestDB() : base()
        {
            allGuests = new Collection<Guest>();
            //allGuestAccounts = new Collection<GuestAccount>();
            //allRefNumbers = new Collection<ReferenceNumber>();
            FillDataSet(sqlLocalGuest, tableGuest);
            FillDataSet(sqlLocalGuestAccount, tableGuestAccount);
            FillDataSet(sqlLocalRefNum, tableRefNum);
            //FillDataSet(sqlLocalBooking, tableBooking);

            PopulateCollections();
        }

        

        protected override void PopulateCollections()
        {
            //Declare references to a myRow object and each relevant object
            DataRow myRow = null;
            Guest guest = null;
            GuestAccount guestAcc = null;
            
            //string referenceNum;
            
            //READ from Guest table
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tableGuest].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // collect attributes
                    int id  = Convert.ToInt32(myRow[columnAttributes.ID]);
                    
                    string name = "", phone = "", email= "", address = "", guestAccountNumber = "";
                    
                    // The code below shows the test for database Null values
                    if (myRow[columnAttributes.GuestAccountNumber] != System.DBNull.Value)
                    {
                        guestAccountNumber = Convert.ToString(myRow[columnAttributes.GuestAccountNumber]).TrimEnd();
                        double amount = 0;
                        //double amount = Convert.ToInt32(dsMain.Tables[tableGuestAccount].Select(filterExpression: "Id=g1")[0].ItemArray[1]);
                        //READ from GuestAccount table
                        foreach (DataRow myRow_loopVariable2 in dsMain.Tables[tableGuestAccount].Rows)
                        {
                            myRow = myRow_loopVariable2;
                            if (!(myRow.RowState == DataRowState.Deleted))
                            {
                                if (Convert.ToString(myRow[columnAttributes.ID]).TrimEnd() == guestAccountNumber)
                                {
                                    amount = Convert.ToDouble(myRow[columnAttributes.Balance]);
                                }
                            }
                        }

                        guestAcc = new GuestAccount(guestAccountNumber, amount); // TODO check

                        myRow = myRow_loopVariable; // back to Guest table

                        name = Convert.ToString(myRow[columnAttributes.Name]).TrimEnd();
                        phone = Convert.ToString(myRow[columnAttributes.Phone]).TrimEnd();
                        email = Convert.ToString(myRow[columnAttributes.Email]).TrimEnd();
                        address = Convert.ToString(myRow[columnAttributes.Address]).TrimEnd();

                        //READ from ReferenceNumber table
                        foreach (DataRow myRow_loopVariable2 in dsMain.Tables[tableRefNum].Rows)
                        {
                            myRow = myRow_loopVariable2;
                            if (!(myRow.RowState == DataRowState.Deleted))
                            {
                                if (Convert.ToInt32(myRow[columnAttributes.GuestID]) == id)
                                {
                                    int refId = Convert.ToInt32(myRow[columnAttributes.ID]);
                                    string refNum = Convert.ToString(myRow[columnAttributes.ReferenceNumber]).TrimEnd();
                                    // Add all reference numbers
                                    guestAcc.AddReferenceNumber(new ReferenceNumber(refId, refNum));
                                }
                            }
                        }

                        guest = new Guest(id, guestAccountNumber, name, phone, email, address)
                        {
                            guestAccount = guestAcc
                        };

                        allGuests.Add(guest);

                    }
                    
                }
            }
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;  //***W3
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
//namespaces
using INF2011S_Workshop8_WaS7_PII.Employees;

namespace INF2011S_Workshop8_WaS7_PII.DatabaseLayer
{
    public class EmployeeDB : DB
    {
        //Data members

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public EmployeeDB() : base()
        {
            employees = new Collection<Employee>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);
        }
        public Collection<Employee> AllEmployees
        {
            get
            {
                return employees;
            }
        }
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Employee anEmp, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    dataTable = table1;
                    break;
                case Role.RoleType.Waiter:
                    dataTable = table2;
                    break;
                case Role.RoleType.Runner:
                    dataTable = table3;
                    break;
            }
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, anEmp, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp,dataTable)];
                    FillRow(aRow, anEmp, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(anEmp, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Utility Methods
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Employee anEmp;
            HeadWaiter headw;
            Waiter waiter;
            Runner runner;
            Role.RoleType roleValue = Role.RoleType.NoRole;  //Declare roleValue and initialise
            switch (table)
            {
                case "HeadWaiter":
                    roleValue = Role.RoleType.Headwaiter;
                    break;
                case "Waiter":
                    roleValue = Role.RoleType.Waiter;
                    break;
                case "Runner":
                    roleValue = Role.RoleType.Runner;
                    break;
            }
            //READ from the table
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Employee object
                    anEmp = new Employee(roleValue);
                    //Obtain each employee attribute from the specific field in the row in the table
                    anEmp.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                    //Do the same for all other attributes
                    anEmp.EmpID = Convert.ToString(myRow["EmpID"]).TrimEnd();
                    //***The code below shows thee test for database Null values
                    if (myRow["Name"] == System.DBNull.Value)
                    { anEmp.Name = ""; }
                    else { anEmp.Name = Convert.ToString(myRow["Name"]).TrimEnd(); }
                     anEmp.Phone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    anEmp.role.RoleValue = (Role.RoleType)Convert.ToByte(myRow["Role"]);
                    //Depending on Role read more Values
                    switch (anEmp.role.RoleValue)
                    {
                        case Role.RoleType.Headwaiter:
                            headw = (HeadWaiter)anEmp.role;
                            headw.Salary = Convert.ToDecimal(myRow["Salary"]);
                            break;
                        case Role.RoleType.Waiter:
                            waiter = (Waiter)anEmp.role;
                            waiter.Rate = Convert.ToDecimal(myRow["DayRate"]);
                            waiter.NumberOfShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                        case Role.RoleType.Runner:
                            runner = (Runner)anEmp.role;
                            runner.Rate = Convert.ToDecimal(myRow["DayRate"]);
                            runner.NumberOfShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                    }
                    employees.Add(anEmp);
                }
            }
        }
        private void FillRow(DataRow aRow, Employee anEmp, DB.DBOperation operation)
        {
            HeadWaiter headwaiter;
            Runner runner;
            Waiter waiter;
            if (operation == DB.DBOperation.Add)
            {
                aRow["ID"] = anEmp.ID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["EmpID"] = anEmp.EmpID;
            }
            aRow["Name"] = anEmp.Name;
            aRow["Phone"] = anEmp.Phone;
            aRow["Role"] = (byte)anEmp.role.RoleValue;
            //*** For each role add the specific data variables
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headwaiter = (HeadWaiter)anEmp.role;
                    aRow["Salary"] = headwaiter.Salary;
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)anEmp.role;
                    aRow["DayRate"] = waiter.Rate;
                    aRow["NoOfShifts"] = waiter.NumberOfShifts;
                    aRow["Tips"] = waiter.Tips;
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)anEmp.role;
                    aRow["DayRate"] = runner.Rate;
                    aRow["NoOfShifts"] = runner.NumberOfShifts;
                    break;
            }
        }

        //The FindRow method finds the row for a specific employee(by ID)  in a specific table
        private int FindRow(Employee anEmp, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it is automatically known to the compiler when used as below
                    if (anEmp.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Employee anEmp)
        {
            //Create Parameters to communicate with SQL INSERT
            //https://www.google.co.za/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=size+in+bytes+of+Int+in+SQL
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.TinyInt, 1, "Role");
            daMain.InsertCommand.Parameters.Add(param);
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }
            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Build_UPDATE_Parameters(Employee anEmp)
        {
            //---Create Parameters to communicate with SQL UPDATE
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do for all fields other than ID and EMPID as for Insert
            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Role", SqlDbType.TinyInt, 1, "Role");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    param.SourceVersion = DataRowVersion.Current;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
            }
            //testing the ID of record that needs to change with the original ID of the record
            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Employee anEmp)
        {
            //Create the command that must be used to insert values into the Books table..
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into HeadWaiter (ID, EMPID, Name, Phone, Role, Salary) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into Waiter (ID, EMPID, Name, Phone, Role, Tips, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Tips, @DayRate, @NoOfShifts)", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @DayRate, @NoOfShifts)", cnMain);
                    break;
            }
            Build_INSERT_Parameters(anEmp);
        }

        private void Create_UPDATE_Command(Employee anEmp)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed

            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.UpdateCommand = new SqlCommand("UPDATE HeadWaiter SET Name =@Name, Phone =@Phone, Role =@Role, Salary = @Salary " + "WHERE ID = @Original_ID", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.UpdateCommand = new SqlCommand("UPDATE Waiter SET Name =@Name, Phone =@Phone, Role =@Role, Tips =@Tips, DayRate =@DayRate, NoOfShifts =@NoOfShifts " + "WHERE ID = @Original_ID", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.UpdateCommand = new SqlCommand("UPDATE Runner SET Name =@Name, Phone =@Phone, Role =@Role, DayRate =@DayRate, NoOfShifts =@NoOfShifts " + "WHERE ID = @Original_ID", cnMain);
                    break;
            }
                      Build_UPDATE_Parameters(anEmp);
        }

        private string Create_DELETE_Command(Employee anEmp)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.DeleteCommand = new SqlCommand("DELETE FROM HeadWaiter WHERE ID = @ID", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.DeleteCommand = new SqlCommand("DELETE FROM Waiter WHERE ID = @ID", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.DeleteCommand = new SqlCommand("DELETE FROM Runner WHERE ID = @ID", cnMain);
                    break;
            }
            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        public bool UpdateDataSource(Employee anEmp)
        {
            bool success = true;
            Create_INSERT_Command(anEmp);
            Create_UPDATE_Command(anEmp);
            Create_DELETE_Command(anEmp);
            switch (anEmp.role.RoleValue)
            {
                case Role.RoleType.Headwaiter:
                    success = UpdateDataSource(sqlLocal1, table1);
                    break;
                case Role.RoleType.Waiter:
                    success = UpdateDataSource(sqlLocal2, table2);
                    break;
                case Role.RoleType.Runner:
                    success = UpdateDataSource(sqlLocal3, table3);
                    break;
            }
            return success;
        }
        #endregion

    }
} 
 */
