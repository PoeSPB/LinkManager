using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain.DTO
{
    public class AgentDTO
    {
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; } //Идентификатор агента в системе
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public AgentStatus Status { get; set; } //Статус агента
        public DateTime RegisteredTime { get; set; } //Время регистрации агента

        //Свойства навигации
        public AgentKindDTO AgentKindDTO { get; set; }
        public List<LinkLightDTO> LinkLightDTOs { get; set; } = new List<LinkLightDTO>();
    }
}
