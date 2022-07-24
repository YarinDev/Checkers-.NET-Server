using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Model
{
    public class TblGames
    {
        [Key]
        public int GameId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Length { get; set; }
        public String Winner { get; set; }
    }
}
