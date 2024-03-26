using GameBibApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class WantedGame
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int UserId { get; set; }

        public  App app { get; set; }
        public UserDto userDto { get; set; }
    }
}
