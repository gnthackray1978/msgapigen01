namespace MSGSharedData.Domain.Entities.Persistent.MSGCore.Auth
{
    public partial class MsgapplicationMapGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int ApplicationId { get; set; }

        public virtual Msgapplications Application { get; set; }
        public virtual Msggroups Group { get; set; }
    }
}
