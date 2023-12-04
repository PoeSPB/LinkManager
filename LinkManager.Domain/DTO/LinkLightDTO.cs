using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkManager.Domain.DTO
{
    public class LinkLightDTO
    {
        public string LinkDescription { get; set; }
        public LinkStatus LinkStatus { get; set; } //Статус связи
        public LinkEndTypeDTO LinkEndTypeDTO { get; set; }
    }
}
