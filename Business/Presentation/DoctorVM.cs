using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class DoctorVM
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { set; get; }
       // public List<ScheduleVM> Schedule { set; get; }

    }
}
