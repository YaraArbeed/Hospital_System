
```mermaid  
  Department {
        int Dept_ID PK
        string Dept_Head
        string Dept_Name
    }

    Staff {
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

    Doctor {
        int Doctor_ID PK
        string Qualifications
        int Emp_ID FK
        string Specialization
        int Dept_ID FK
    }

    Nurse {
        int Nurse_ID PK
        int Patient_ID FK
        int Emp_ID FK
        int Dept_ID FK
    }

    Technician {
        int Technician_ID PK
        string Tech_FName
        string Tech_LName
        string Qualification
    }

    Patient {
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

    Emergency_Contact {
        int Contact_ID PK
        string Contact_Name
        string Phone
        string Relation
        int Patient_ID FK
    }

    Payroll {
        string Account_No PK
        float Salary
        float Bonus
        int Emp_ID FK
        string IBAN
    }

    Lab_Screening {
        int Lab_ID PK
        int Patient_ID FK
        int Technician_ID FK
        int Doctor_ID FK
        float Test_Cost
        date Date
    }

    Insurance {
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

    Medicine {
        int Medicine_ID PK
        string M_Name
        int M_Quantity
        float M_Cost
    }

    Prescription {
        int Prescription_ID PK
        int Patient_ID FK
        int Medicine_ID FK
        date Date
        int Dosage
        int Doctor_ID FK
    }

    Medical_History {
        int Record_ID PK
        int Patient_ID FK
        string Allergies
        string Pre_Conditions
    }

    Appointment {
        int Appt_ID PK
        datetime Scheduled_On
        date Date
        time Time
        int Doctor_ID FK
        int Patient_ID FK
    }

    Room_Type {
        int Room_Type_ID PK
        string Room_Desc
        float Room_Cost
    }

    Room {
        int Room_ID PK
        int Room_Type_ID FK
        int Patient_ID FK
    }

    Bill {
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
