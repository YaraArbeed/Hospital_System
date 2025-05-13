using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Queries
{
    public class AdvancedQueries
    {
        public static void ShowMostBookedDoctorThisMonth()
        {
            string query = @"
        SELECT TOP 1
            D.Doctor_ID,
            S.Emp_FName + ' ' + S.Emp_LName AS Doctor_Name,
            COUNT(*) AS Appointment_Count
        FROM Appointment A
        INNER JOIN Doctor D ON A.Doctor_ID = D.Doctor_ID
        INNER JOIN Staff S ON D.Emp_ID = S.Emp_ID
        WHERE MONTH(A.Date) = MONTH(GETDATE()) AND YEAR(A.Date) = YEAR(GETDATE())
        GROUP BY D.Doctor_ID, S.Emp_FName, S.Emp_LName
        ORDER BY Appointment_Count DESC";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nMost Booked Doctor This Month:");
                    Console.WriteLine(new string('-', 50));

                    if (reader.Read())
                    {
                        Console.WriteLine($"Doctor: {reader["Doctor_Name"]}, Appointments: {reader["Appointment_Count"]}");
                    }
                    else
                    {
                        Console.WriteLine("No appointments found for this month.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void ListDepartmentsWithNoDoctors()
        {
            string query = @"
        SELECT Dept_ID, Dept_Name, Dept_Head
        FROM Department
        WHERE Dept_ID NOT IN (
            SELECT DISTINCT Dept_ID FROM Doctor
        )";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nDepartments with No Assigned Doctors:");
                    Console.WriteLine(new string('-', 50));

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("All departments have at least one doctor.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"Dept ID: {reader["Dept_ID"]}, Name: {reader["Dept_Name"]}, Head: {reader["Dept_Head"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void ListInactivePatients()
        {
            string query = @"
        SELECT P.Patient_ID, P.Patient_FName, P.Patient_LName
        FROM Patient P
        WHERE P.Patient_ID NOT IN (
            SELECT DISTINCT Patient_ID
            FROM Appointment
            WHERE Date >= DATEADD(MONTH, -6, GETDATE())
        )";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nPatients Who Haven’t Visited in the Last 6 Months:");
                    Console.WriteLine(new string('-', 60));

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("All patients have recent visits.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"Patient ID: {reader["Patient_ID"]}, Name: {reader["Patient_FName"]} {reader["Patient_LName"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

    }
}
