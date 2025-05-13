
```mermaid
classDiagram
    class Department {
        +int Dept_ID
        +string Dept_Head
        +string Dept_Name
    }

    class Staff {
        +int Emp_ID
        +string Emp_FName
        +string Emp_LName
        +date Date_Joining
        +date Date_Seperation
        +string Emp_Type
        +string Email
        +string Address
        +int Dept_ID
        +int SSN
    }

    class Doctor {
        +int Doctor_ID
        +string Qualifications
        +int Emp_ID
        +string Specialization
        +int Dept_ID
    }

    class Nurse {
        +int Nurse_ID
        +int Patient_ID
        +int Emp_ID
        +int Dept_ID
    }

    class Technician {
        +int Technician_ID
        +string Tech_FName
        +string Tech_LName
        +string Qualification
    }

    class Patient {
        +int Patient_ID
        +string Patient_FName
        +string Patient_LName
        +string Phone
        +string Blood_Type
        +string Email
        +string Gender
        +string Condition_
        +date Admission_Date
        +date Discharge_Date
    }

    class Emergency_Contact {
        +int Contact_ID
        +string Contact_Name
        +string Phone
        +string Relation
        +int Patient_ID
    }

    class Payroll {
        +string Account_No
        +float Salary
        +float Bonus
        +int Emp_ID
        +string IBAN
    }

    class Lab_Screening {
        +int Lab_ID
        +int Patient_ID
        +int Technician_ID
        +int Doctor_ID
        +float Test_Cost
        +date Date
    }

    class Insurance {
        +string Policy_Number
        +int Patient_ID
        +string Ins_Code
        +string End_Date
        +string provider_comp
        +string plan_
        +float Co_Pay
        +string Coverage
        +bool Maternity
        +bool Dental
        +bool Optical
    }

    class Medicine {
        +int Medicine_ID
        +string M_Name
        +int M_Quantity
        +float M_Cost
    }

    class Prescription {
        +int Prescription_ID
        +int Patient_ID
        +int Medicine_ID
        +date Date
        +int Dosage
        +int Doctor_ID
    }

    class Medical_History {
        +int Record_ID
        +int Patient_ID
        +string Allergies
        +string Pre_Conditions
    }

    class Appointment {
        +int Appt_ID
        +datetime Scheduled_On
        +date Date
        +time Time
        +int Doctor_ID
        +int Patient_ID
    }

    class Room_Type {
        +int Room_Type_ID
        +string Room_Desc
        +float Room_Cost
    }

    class Room {
        +int Room_ID
        +int Room_Type_ID
        +int Patient_ID
    }

    class Bill {
        +int Bill_ID
        +date Date
        +float Room_Cost
        +float Test_Cost
        +float Other_Charges
        +float M_Cost
        +int Patient_ID
        +float Remaining_Balance
        +string Policy_Number
    }


    DEPARTMENT ||--o{ STAFF : employs
    STAFF ||--|| DOCTOR : has
    DEPARTMENT ||--o{ DOCTOR : manages
    STAFF ||--|| NURSE : has
    DEPARTMENT ||--o{ NURSE : manages
    ROOM ||--|| PATIENT : assigned_to
    PATIENT ||--o{ EMERGENCY_CONTACT : has
    PATIENT ||--o{ INSURANCE : holds
    PATIENT ||--|| MEDICAL_HISTORY : has
    PATIENT ||--o{ LAB_SCREENING : undergoes
    PATIENT ||--o{ PRESCRIPTION : receives
    PATIENT ||--o{ APPOINTMENT : schedules
    DOCTOR ||--o{ APPOINTMENT : schedules
    DOCTOR ||--o{ PRESCRIPTION : writes
    PATIENT ||--o{ BILL : incurs
    INSURANCE ||--o{ BILL : covers
    MEDICINE }o--o{ PRESCRIPTION : prescribed_in
    TECHNICIAN ||--o{ LAB_SCREENING : performs
    DOCTOR ||--o{ LAB_SCREENING : prescribes
    ROOM_TYPE ||--o{ ROOM : consists_of
```
---
