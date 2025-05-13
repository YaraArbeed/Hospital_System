using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Queries
{
    public class IntermediateQueries
    {
        public static void ListAppointmentsWithDoctorAndPatient()
        {
            string query = @"
        SELECT 
            A.Appt_ID,
            A.Date,
            A.Time,
            D.Doctor_ID,
            S.Emp_FName + ' ' + S.Emp_LName AS Doctor_Name,
            P.Patient_ID,
            P.Patient_FName + ' ' + P.Patient_LName AS Patient_Name
        FROM Appointment A
        INNER JOIN Doctor D ON A.Doctor_ID = D.Doctor_ID
        INNER JOIN Staff S ON D.Emp_ID = S.Emp_ID
        INNER JOIN Patient P ON A.Patient_ID = P.Patient_ID
        ORDER BY A.Date, A.Time";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Appt ID: {reader["Appt_ID"]}, Date: {reader["Date"]}, Time: {reader["Time"]}");
                        Console.WriteLine($"Doctor: {reader["Doctor_Name"]} (ID: {reader["Doctor_ID"]})");
                        Console.WriteLine($"Patient: {reader["Patient_Name"]} (ID: {reader["Patient_ID"]})");
                        Console.WriteLine(new string('-', 40));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void FindDoctorsByDepartment()
        {
            Console.Write("Enter Department Name: ");
            string deptName = Console.ReadLine();

            string query = @"
        SELECT 
            D.Doctor_ID,
            S.Emp_FName + ' ' + S.Emp_LName AS Doctor_Name,
            D.Specialization,
            Dept.Dept_Name
        FROM Doctor D
        INNER JOIN Staff S ON D.Emp_ID = S.Emp_ID
        INNER JOIN Department Dept ON D.Dept_ID = Dept.Dept_ID
        WHERE Dept.Dept_Name = @DeptName";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DeptName", deptName);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine($"\nDoctors in Department: {deptName}");
                    Console.WriteLine(new string('-', 40));

                    while (reader.Read())
                    {
                        Console.WriteLine($"Doctor ID: {reader["Doctor_ID"]}, Name: {reader["Doctor_Name"]}, Specialization: {reader["Specialization"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void CountAppointmentsPerDoctor()
        {
            string query = @"
        SELECT 
            D.Doctor_ID,
            S.Emp_FName + ' ' + S.Emp_LName AS Doctor_Name,
            COUNT(A.Appt_ID) AS Appointment_Count
        FROM Doctor D
        INNER JOIN Staff S ON D.Emp_ID = S.Emp_ID
        LEFT JOIN Appointment A ON D.Doctor_ID = A.Doctor_ID
        GROUP BY D.Doctor_ID, S.Emp_FName, S.Emp_LName";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nAppointments per Doctor:");
                    Console.WriteLine(new string('-', 40));

                    while (reader.Read())
                    {
                        Console.WriteLine($"Doctor: {reader["Doctor_Name"]}, Appointments: {reader["Appointment_Count"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void ListPatientsWithMultipleAppointments()
        {
            string query = @"
        SELECT 
            P.Patient_ID,
            P.Patient_FName + ' ' + P.Patient_LName AS Patient_Name,
            COUNT(A.Appt_ID) AS Appointment_Count
        FROM Patient P
        INNER JOIN Appointment A ON P.Patient_ID = A.Patient_ID
        GROUP BY P.Patient_ID, P.Patient_FName, P.Patient_LName
        HAVING COUNT(A.Appt_ID) > 1";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nPatients with More Than One Appointment:");
                    Console.WriteLine(new string('-', 50));

                    while (reader.Read())
                    {
                        Console.WriteLine($"Patient: {reader["Patient_Name"]}, Appointments: {reader["Appointment_Count"]}");
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
