using System;

namespace LinkManager.Domain.DTO
{
    public class NewLinkDTO
    {
        public Guid Agent1Id { get; set; }
        public Guid Agent2Id { get; set; }
        public int LinkEnd1KindCode { get; set; }
        public int LinkEnd2KindCode { get; set; }
    }
}
