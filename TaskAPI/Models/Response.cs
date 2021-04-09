using System.Collections.Generic;

namespace TaskAPI.Models
{
    public class Response
    {
        public List<Users> Users { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
    }
}
