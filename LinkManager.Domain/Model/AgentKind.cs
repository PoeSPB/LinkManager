using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain
{
    public class AgentKind
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Свойства навигации
        public List<Agent> Agents { get; set; } = new List<Agent>();
    }
}
