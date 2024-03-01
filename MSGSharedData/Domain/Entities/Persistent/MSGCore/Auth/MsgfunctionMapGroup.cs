namespace MSGSharedData.Domain.Entities.Persistent.MSGCore.Auth
{
    public partial class MsgfunctionMapGroup
    {
        public int Id { get; set; }
        public int? FunctionId { get; set; }
        public int? GroupId { get; set; }

        public virtual Msgfunctions Function { get; set; }
        public virtual Msggroups Group { get; set; }
    }
}
