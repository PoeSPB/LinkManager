using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkManager.Domain.DTO
{
    //Скорее всего не нужно
    public class LinkEndDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool AgentChecked { get; set; } //Подтверждена агентом 1
        public DateTime CreationTime { get; set; } //Время создания/запроса на установление связи
        public DateTime? CheckedTime { get; set; } = null; //Время подтверждения
        public DateTime? CloseTime { get; set; } = null;//Время завершения связи
        public bool ActiveLinkFlag { get; set; } //Связь является актуальной
        public LinkStatus Status { get; set; } //Статус связи


        //Внешние ключи
        public int LinkEndTypeId { get; set; }
        public Guid AgentId { get; set; }

        //Свойства навигации
        public LinkEndTypeDTO LinkEndTypeDTO { get; set; }
        public Guid LinkOutId { get; set; }
        public LinkEndDTO Out { get; set; }
        public LinkEndDTO In { get; set; }
    }
}
