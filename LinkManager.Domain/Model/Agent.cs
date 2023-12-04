using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain
{
    public enum AgentType
    {
        Person = 1,
        Group = 2,
        Object = 3
    }
    public enum AgentStatus
    {
        Acticve = 10,
        Blocked = 0,
        Archive = 100
    }
    public class Agent
    {
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; } //Идентификатор агента в системе
        public AgentType Type { get; set; }
        public AgentStatus Status { get; set; } //Статус агента
        public string Name { get; set; } = null!;
        public string Descripion { get; set; } = string.Empty;
        public string ImgURL { get; set; }
        public DateTime RegisteredTime { get; set; } //Время регистрации агента


        //Внешние ключи
        public int AgentKindId { get; set; }

        //Свойства навигации
        public AgentKind AgentKind { get; set; }
        public List<LinkEnd> Links { get; set; } = new List<LinkEnd>();
    }
}
