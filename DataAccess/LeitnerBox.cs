using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace DataAccess
{
    public class LeitnerBox
    {

        [Key]
        public int Id { get; set; }
        public string LeitnerBoxName { get; set; }
    }
}
