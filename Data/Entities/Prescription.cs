﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public partial class Prescription
    {
        public int ID { get; set; }
        public int MedicalRecordId { get; set; }
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public int Frequency { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime EndDate { get; set; }
        public string? SpecialInstructions { get; set; }
        public MedicalRecords MedicalRecords { get; set; } = null!;
    }
}
