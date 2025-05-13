using System;
using System.Globalization;
using Hospital_Management_System.Ado.Queries;

namespace HospitalManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching all patients.....\n");
            BasicQueries.GetAllPatients();
            Console.ReadKey();
            Console.WriteLine("Fetching all doctors and their specialties...\n");
            BasicQueries.GetAllDoctorsAndSpecialties();
            Console.ReadKey();
            Console.WriteLine("Enter a date (yyyy-mm-dd) to fetch appointments:");
            string inputDate = Console.ReadLine();

            if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appointmentDate))
            {
                BasicQueries.GetAppointmentsByDate(appointmentDate);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format.");
            }

            Console.ReadKey();
            BasicQueries.InsertNewPatient( 301,"John", "Doe", "1234567890", "O+", "john.doe@email.com", "Male", "Healthy", DateTime.Now, DateTime.Now.AddMonths(1));

            Console.ReadKey();

            // Example: update phone number for patient with ID 1
            BasicQueries.UpdatePatientPhone(301, "9876543210");

            Console.ReadKey();
            // Example: delete appointment with ID 2
            BasicQueries.DeleteAppointment(2);

            Console.ReadKey();
            IntermediateQueries.ListAppointmentsWithDoctorAndPatient();

            Console.ReadKey();
            IntermediateQueries.FindDoctorsByDepartment();
            IntermediateQueries.CountAppointmentsPerDoctor();
            IntermediateQueries.ListPatientsWithMultipleAppointments();

            AdvancedQueries.ShowMostBookedDoctorThisMonth();
            AdvancedQueries.ListDepartmentsWithNoDoctors();
            AdvancedQueries.ListInactivePatients();

        }

    }
}