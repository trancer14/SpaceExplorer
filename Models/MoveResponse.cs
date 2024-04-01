using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.Models
{
    public class CreateResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = "";
        public Explorer Explorer { get; set; }
    }
}
