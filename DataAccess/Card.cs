using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Position { get; set; }
        public string PositionPersion { get; set; }
        public int LeitnerBoxId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EarlyDate { get; set; }

    }
    public enum BoxPosition
    {
        Box1,
        Box2,
        Box3,
        Box4,
        Box5,
        BoxFinish
    }
}
