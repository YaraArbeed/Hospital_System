using Hospital_Management_System.Ado.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Queries
{
    public class BasicQueries
    {
        public static void GetAllPatients()
        {
            string query = "SELECT Patient_ID, Patient_FName, Patient_LName, Phone, Blood_Type, Email, Gender, Condition_, Admission_Date, Discharge_Date FROM Patient";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int patientId = reader.GetInt32(0);
                    string patientFName = reader.GetString(1);
                    string patientLName = reader.GetString(2);
                    string phone = reader.GetString(3);
                    string bloodType = reader.GetString(4);
                    string email = reader.IsDBNull(5) ? "N/A" : reader.GetString(5);
                    string gender = reader.GetString(6);
                    string condition = reader.GetString(7);
                    DateTime admissionDate = reader.GetDateTime(8);
                    DateTime? dischargeDate = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9);

                    Console.WriteLine($"Patient ID: {patientId}, Name: {patientFName} {patientLName}, " +
                                      $"Phone: {phone}, Blood Type: {bloodType}, Email: {email}, " +
                                      $"Gender: {gender}, Condition: {condition}, Admission Date: {admissionDate.ToShortDateString()}, " +
                                      $"Discharge Date: {dischargeDate?.ToShortDateString() ?? "N/A"}");
                }

                reader.Close();
            }
        }

        public static void GetAllDoctorsAndSpecialties()
        {
            string query = "SELECT Doctor_ID, Emp_ID, Specialization FROM Doctor";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int doctorId = reader.GetInt32(0);
                    int empId = reader.GetInt32(1);
                    string specialization = reader.GetString(2);

                    Console.WriteLine($"Doctor ID: {doctorId}, Employee ID: {empId}, Specialization: {specialization}");
                }

                reader.Close();
            }
        }


            // Method to get appointments by a specific date
            public static void GetAppointmentsByDate(DateTime appointmentDate)
            {
                string query = "SELECT Appt_ID, Date, Time, Doctor_ID, Patient_ID " +
                               "FROM Appointment WHERE Date = @Date";

                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Date", appointmentDate);  // Parameterized query to avoid SQL injection

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No appointments found for the specified date.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            int apptId = reader.GetInt32(0);
                            DateTime date = reader.GetDateTime(1);
                            TimeSpan time = reader.GetTimeSpan(2);
                            int doctorId = reader.GetInt32(3);
                            int patientId = reader.GetInt32(4);

                            Console.WriteLine($"Appointment ID: {apptId}, Date: {date.ToShortDateString()}, Time: {time}, Doctor ID: {doctorId}, Patient ID: {patientId}");
                        }
                    }

                    reader.Close();
                }
            }
        public static void InsertNewPatient(int patientID, string patientFName, string patientLName, string phone, string bloodType, string email, string gender, string condition, DateTime admissionDate, DateTime dischargeDate)
        {
            string query = "INSERT INTO Patient (@Patient_ID,Patient_FName, Patient_LName, Phone, Blood_Type, Email, Gender, Condition_, Admission_Date, Discharge_Date) " +
                           "VALUES (@Patient_FName, @Patient_LName, @Phone, @Blood_Type, @Email, @Gender, @Condition_, @Admission_Date, @Discharge_Date)";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                // Adding parameters to prevent SQL Injection
                cmd.Parameters.AddWithValue("@Patient_ID", patientID);
                cmd.Parameters.AddWithValue("@Patient_FName", patientFName);
                cmd.Parameters.AddWithValue("@Patient_LName", patientLName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Blood_Type", bloodType);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Condition_", condition);
                cmd.Parameters.AddWithValue("@Admission_Date", admissionDate);
                cmd.Parameters.AddWithValue("@Discharge_Date", dischargeDate);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("New patient inserted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert new patient.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static void UpdatePatientPhone(int patientId, string newPhone)
        {
            string query = "UPDATE Patient SET Phone = @Phone WHERE Patient_ID = @Patient_ID";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Phone", newPhone);
                cmd.Parameters.AddWithValue("@Patient_ID", patientId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Patient phone number updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No patient found with the given ID.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void DeleteAppointment(int appointmentId)
        {
            string query = "DELETE FROM Appointment WHERE Appt_ID = @Appt_ID";

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Appt_ID", appointmentId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Appointment deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No appointment found with the given ID.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }


    }
}
