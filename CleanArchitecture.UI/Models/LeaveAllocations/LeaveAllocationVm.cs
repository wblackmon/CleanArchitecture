﻿using CleanArchitecture.UI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.UI.Models.LeaveAllocations
{
    public class LeaveAllocationVm
    {
        public int Id { get; set; }
        [Display(Name = "Number Of Days")]

        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public LeaveTypeVm LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
