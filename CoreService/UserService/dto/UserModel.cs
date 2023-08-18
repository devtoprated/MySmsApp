using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.dto
{

    public class UserModel
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Account { get; set; }

        public string? House { get; set; }

        public string? Address { get; set; }

        public DateTime? ScheduleDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public TimeSpan? ActualStartTime { get; set; }

        public TimeSpan? ActualEndTime { get; set; }

    }
}
