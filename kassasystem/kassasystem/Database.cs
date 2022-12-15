using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kassasystem
{
    internal class Room
    {
        public Int64 id { get; set; }
        public decimal rate { get; set; }
        public Int64 number { get; set; }
        public Int64 floor { get; set; }
        public string type { get; set; }
        public Int64 recommendedPeople { get; set; }
    }

    internal class Booking
    {
        public Int64 id { get; set; }
        public Int64 paymentId { get; set; }
        public Int64 paymentDate { get; set; }
        public decimal amountDue { get; set; }
        public string paymentType { get; set; }
        public string guestFirstName { get; set; }
        public string guestLastName { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }

    }

    internal class Database
    {
        public SQLiteConnection con { get; set; }

        public Database()
        {
            initDatabase();
        }

        private void initDatabase()
        {
            string[] tables = {
                "CREATE TABLE \"bookings\" (\r\n\t\"bookingID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"dateFrom\"\tNUMERIC,\r\n\t\"dateTo\"\tNUMERIC,\r\n\t\"roomCount\"\tINTEGER,\r\n\t\"isBreakfastIncluded\"\tNUMERIC,\r\n\tPRIMARY KEY(\"bookingID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tFOREIGN KEY(\"paymentID\") REFERENCES \"payment\"(\"paymentID\")\r\n);",
                "CREATE TABLE \"externalCosts\" (\r\n\t\"externalCostsID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"paymentID\"\tINTEGER,\r\n\t\"externalCost\"\tTEXT,\r\n\t\"costDescription\"\tTEXT,\r\n\tFOREIGN KEY(\"paymentID\") REFERENCES \"payment\"(\"paymentID\"),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\"),\r\n\tPRIMARY KEY(\"externalCostsID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"guestContact\" (\r\n\t\"guestContactID\"\tINTEGER NOT NULL,\r\n\t\"guestID\"\tINTEGER,\r\n\t\"mail\"\tTEXT,\r\n\t\"phoneNumber\"\tINTEGER,\r\n\tPRIMARY KEY(\"guestContactID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"guestID\") REFERENCES \"guests\"(\"guestID\")\r\n);",
                "CREATE TABLE \"guests\" (\r\n\t\"guestID\"\tINTEGER NOT NULL,\r\n\t\"firstName\"\tTEXT,\r\n\t\"lastName\"\tTEXT,\r\n\tPRIMARY KEY(\"guestID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"payment\" (\r\n\t\"paymentID\"\tINTEGER NOT NULL,\r\n\t\"paymentTypeID\"\tINTEGER,\r\n\t\"date\"\tINTEGER,\r\n\t\"amount\"\tNUMERIC,\r\n\t\"isPaid\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"paymentTypeID\") REFERENCES \"paymentType\"(\"paymentTypeID\")\r\n);",
                "CREATE TABLE \"paymentType\" (\r\n\t\"paymentTypeID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tNUMERIC,\r\n\tPRIMARY KEY(\"paymentTypeID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"roomTypes\" (\r\n\t\"roomTypesID\"\tINTEGER NOT NULL,\r\n\t\"type\"\tTEXT,\r\n\t\"totalPeople\"\tINTEGER,\r\n\tPRIMARY KEY(\"roomTypesID\" AUTOINCREMENT)\r\n);",
                "CREATE TABLE \"rooms\" (\r\n\t\"roomID\"\tINTEGER NOT NULL,\r\n\t\"roomTypesID\"\tINTEGER,\r\n\t\"floor\"\tINTEGER,\r\n\t\"roomNumber\"\tINTEGER,\r\n\t\"rate\"\tNUMERIC,\r\n\tPRIMARY KEY(\"roomID\" AUTOINCREMENT),\r\n\tFOREIGN KEY(\"roomTypesID\") REFERENCES \"roomTypes\"(\"roomTypesID\")\r\n);",
                "CREATE TABLE \"roomsBooked\" (\r\n\t\"roomsBookedID\"\tINTEGER NOT NULL,\r\n\t\"bookingID\"\tINTEGER,\r\n\t\"roomID\"\tINTEGER,\r\n\tFOREIGN KEY(\"roomID\") REFERENCES \"rooms\"(\"roomID\"),\r\n\tFOREIGN KEY(\"bookingID\") REFERENCES \"bookings\"(\"bookingID\"),\r\n\tPRIMARY KEY(\"roomsBookedID\" AUTOINCREMENT)\r\n);"
            };

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
            string path = string.Format(@"C:\Users\{0}\Documents\hotel_database\", userName);
            string filePath = string.Format(@"C:\Users\{0}\Documents\hotel_database\database.db", userName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(filePath))
            {
                var db = new SQLiteConnection($"Data Source={filePath};");
                db.Open();
                using (DbCommand cmd = db.CreateCommand())
                {
                    foreach (string query in tables)
                    {
                        cmd.CommandText += query;
                    }
                    cmd.ExecuteReader();
                }

                db.Close();
            }

            this.con = new SQLiteConnection($"Data Source={filePath};");
        }

        public List<Dictionary<string, object>> QueryExecutor(string query)
        {
            /* 
             * Returns a list of dictonaroies with result from db
             * REF: https://www.daniweb.com/programming/software-development/threads/234938/get-the-column-values-from-the-sqlite-database
             * 
            */

            List<Dictionary<string, object>> output = new List<Dictionary<string, object>>();

            SQLiteCommand cmd = new SQLiteCommand(query, this.con);
            this.con.Open();
            try
            {
                using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        dataTable.Load(dataReader);

                        // loop over each row
                        for (int i1 = 0; i1 < dataTable.Rows.Count; i1++)
                        {

                            DataRow currentRow = dataTable.Rows[i1];
                            Dictionary<string, object> temporaryDictionary = new Dictionary<string, object>();

                            // For each row loop over each column in row
                            for (int i2 = 0; i2 < dataTable.Columns.Count; i2++)
                            {
                                var currentColumnName = dataTable.Columns[i2].ToString();
                                var currentColumnValue = currentRow[currentColumnName];

                                System.Diagnostics.Debug.Write($" {currentColumnName}: ");
                                System.Diagnostics.Debug.Write($" {currentColumnValue} ");

                                // Add row columns to dictionary with column name as key and column value as dictionary value
                                temporaryDictionary.Add(currentColumnName, currentColumnValue);

                            }

                            System.Diagnostics.Debug.WriteLine("");

                            // add row dictionary to output list
                            output.Add(temporaryDictionary);
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.con.Close();
            }

            return output;

        }

        public Int64 QueryInsertExecutor(string query)
        {
            /* 
             * Insert the the index the item was inserted in
             * REF: https://stackoverflow.com/questions/4341178/getting-the-last-insert-id-with-sqlite-net-in-c-sharp
            */

            Int64 output_row_id = -1;

            SQLiteCommand cmd = new SQLiteCommand(query, this.con);
            this.con.Open();
            try
            {
                SQLiteTransaction transaction = null;
                transaction = this.con.BeginTransaction();

                cmd.ExecuteNonQuery();

                output_row_id = this.con.LastInsertRowId;

                transaction.Commit();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            this.con.Close();

            return output_row_id;

        }
        public void testGetSomething()
        {
            var data = QueryExecutor("SELECT * FROM roomTypes");

            for (int i = 0; i < data.Count; i++)
            {
                foreach (KeyValuePair<string, object> nogot in data[i])
                {
                    System.Diagnostics.Debug.WriteLine("Dict rad ");
                    System.Diagnostics.Debug.WriteLine(nogot.Key, nogot.Value.ToString());
                }
            }
        }

        public List<Room> GetAvailableRooms(int epochStartDate, int epochEndDate)
        {
            var row = QueryExecutor($"SELECT r.roomID, r.floor, r.roomNumber, r.rate, b.dateFrom, b.dateTo, r2.type, r2.totalPeople FROM rooms r LEFT JOIN roomsBooked r1 ON ( r1.roomID = r.roomID  ) LEFT JOIN bookings b ON ( b.bookingID = r1.bookingID  ) LEFT JOIN roomTypes r2 ON ( r2.roomTypesID = r.roomTypesID  ) WHERE (r.roomID NOT IN (SELECT roomID FROM roomsBooked)) OR NOT (5 <= b.dateTo AND 10 >= b.dateFrom) GROUP BY r.roomID;");

            var output = new List<Room>();
            for (int i = 0; i < row.Count; i++)
            {
                Room newRoom = new Room();
                newRoom.id = (Int64)row[i]["roomID"];
                newRoom.rate = (decimal)row[i]["rate"];
                newRoom.number = (Int64)row[i]["roomNumber"];
                newRoom.floor = (Int64)row[i]["floor"];
                newRoom.type = (string)row[i]["type"];
                newRoom.recommendedPeople = (Int64)row[i]["totalPeople"];

                output.Add(newRoom);
            }
            return output;
        }

        public void CreateNewBooking(Int64 roomID, string GuestFirstName, string GuestLastName, int checkinDate, int checkoutDate, Decimal totalPrice)
        {
            TimeSpan t = DateTime.Now - new DateTime(1970, 1, 1); // Time in seconds since january 1 1970
            int currentDateNow = ((int)t.TotalSeconds);

            var newPaymentID = QueryInsertExecutor($"INSERT INTO payment (paymentTypeId, date, amount, isPaid) VALUES ('1', '{currentDateNow}', '{totalPrice}', '0')");
            var newGuestID = QueryInsertExecutor($"INSERT INTO guests (firstName, lastName) VALUES ('{GuestFirstName}', '{GuestLastName}')");
            System.Diagnostics.Debug.WriteLine(newGuestID);

            var newBookingID = QueryInsertExecutor($"INSERT INTO bookings (guestID, paymentID, dateFrom, dateTo, roomCount, isBreakfastIncluded) VALUES ('{newGuestID}', '{newPaymentID}', '{checkinDate}', '{checkoutDate}', '1', '1') ");

            QueryInsertExecutor($"INSERT INTO roomsBooked (bookingID, roomID) VALUES ('{newBookingID}', '{roomID}')");

        }

        public List<Booking> GetUnpaidBookings()
        {
            var rows = QueryExecutor("SELECT b.bookingID, b.dateFrom, b.dateTo, b.paymentID, p.date, p.amount, p1.\"type\", g.firstName, g.lastName\r\nFROM bookings b \r\n\tINNER JOIN payment p ON ( p.paymentID = b.paymentID  )  \r\n\tINNER JOIN paymentType p1 ON ( p1.paymentTypeID = p.paymentTypeID  )  \r\n\tINNER JOIN guests g ON ( g.guestID = b.guestID  )  \r\n\tLEFT OUTER JOIN guestContact g1 ON ( g1.guestID = g.guestID  )  \r\nWHERE p.isPaid = 0");

            var output = new List<Booking>();
            for (int i = 0; i < rows.Count; i++)
            {
                Booking newBooking = new Booking();
                newBooking.id = (Int64)rows[i]["bookingID"];
                newBooking.paymentId = (Int64)rows[i]["paymentID"];
                newBooking.paymentDate = (Int64)rows[i]["date"];
                newBooking.amountDue = (decimal)rows[i]["amount"];
                newBooking.paymentType = (string)rows[i]["type"];
                newBooking.guestFirstName = (string)rows[i]["firstName"];
                newBooking.guestLastName = (string)rows[i]["lastName"];
                //newBooking.dateFrom = (string)rows[i]["dateFrom"];
                //newBooking.dateTo = (string)rows[i]["dateTo"];


                output.Add(newBooking);
            }

            return output;

        }

    }
}
