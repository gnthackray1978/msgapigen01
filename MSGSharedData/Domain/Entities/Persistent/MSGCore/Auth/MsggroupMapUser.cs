namespace MSGSharedData.Domain.Entities.Persistent.MSGCore.Auth
{
    public partial class MsggroupMapUser
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string UserId { get; set; }

        public virtual Msggroups Group { get; set; }
    }
}
