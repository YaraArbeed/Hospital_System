classDiagram

    class Department {
        int Dept_ID PK
        string Dept_Head
        string Dept_Name
    }

    class Staff {
        int Emp_ID PK
        string Emp_FName
        string Emp_LName
        date Date_Joining
        date Date_Seperation
        string Emp_Type
        string Email
        string Address
        int Dept_ID FK
        int SSN
    }

    class Doctor {
        int Doctor_ID PK
        string Qualifications
        int Emp_ID FK
        string Specialization
        int Dept_ID FK
    }

    class Nurse {
        int Nurse_ID PK
        int Patient_ID FK
        int Emp_ID FK
        int Dept_ID FK
    }

    class Technician {
        int Technician_ID PK
        string Tech_FName
        string Tech_LName
        string Qualification
    }

    class Patient {
        int Patient_ID PK
        string Patient_FName
        string Patient_LName
        string Phone
        string Blood_Type
        string Email
        string Gender
        string Condition_
        date Admission_Date
        date Discharge_Date
    }

    class Emergency_Contact {
        int Contact_ID PK
        string Contact_Name
        string Phone
        string Relation
        int Patient_ID FK
    }

    class Payroll {
        string Account_No PK
        float Salary
        float Bonus
        int Emp_ID FK
        string IBAN
    }

    class Lab_Screening {
        int Lab_ID PK
        int Patient_ID FK
        int Technician_ID FK
        int Doctor_ID FK
        float Test_Cost
        date Date
    }

    class Insurance {
        string Policy_Number PK
        int Patient_ID FK
        string Ins_Code
        string End_Date
        string provider_comp
        string plan_
        float Co_Pay
        string Coverage
        bool Maternity
        bool Dental
        bool Optical
    }

    class Medicine {
        int Medicine_ID PK
        string M_Name
        int M_Quantity
        float M_Cost
    }

    class Prescription {
        int Prescription_ID PK
        int Patient_ID FK
        int Medicine_ID FK
        date Date
        int Dosage
        int Doctor_ID FK
    }

    class Medical_History {
        int Record_ID PK
        int Patient_ID FK
        string Allergies
        string Pre_Conditions
    }

    class Appointment {
        int Appt_ID PK
        datetime Scheduled_On
        date Date
        time Time
        int Doctor_ID FK
        int Patient_ID FK
    }

    class Room_Type {
        int Room_Type_ID PK
        string Room_Desc
        float Room_Cost
    }

    class Room {
        int Room_ID PK
        int Room_Type_ID FK
        int Patient_ID FK
    }

    class Bill {
        int Bill_ID PK
        date Date
        float Room_Cost
        float Test_Cost
        float Other_Charges
        float M_Cost
        int Patient_ID FK
        float Remaining_Balance
        string Policy_Number FK
    }

    Department     ||--o{ Staff           : employs
    Staff          ||--|| Doctor          : has
    Department     ||--o{ Doctor          : manages
    Staff          ||--|| Nurse           : has
    Department     ||--o{ Nurse           : manages
    Room           ||--|| Patient         : assigned_to
    Patient        ||--o{ Emergency_Contact : has
    Patient        ||--o{ Insurance       : holds
    Patient        ||--|| Medical_History : has
    Patient        ||--o{ Lab_Screening   : undergoes
    Patient        ||--o{ Prescription    : receives
    Patient        ||--o{ Appointment     : schedules
    Doctor         ||--o{ Appointment     : schedules
    Doctor         ||--o{ Prescription    : writes
    Patient        ||--o{ Bill            : incurs
    Insurance      ||--o{ Bill            : covers
    Medicine       }o--o{ Prescription    : prescribed_in
    Technician     ||--o{ Lab_Screening   : performs
    Doctor         ||--o{ Lab_Screening   : prescribes
    Room_Type      ||--o{ Room            : consists_of
