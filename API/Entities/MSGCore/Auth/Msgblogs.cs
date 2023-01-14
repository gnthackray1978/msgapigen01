using System;

namespace Api.Entities.MSGCore.Auth
{
    public partial class Msgblogs
    {
        public Msgblogs()
        {

        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }

        public string LinkURL { get; set; }

        public string LinkDescription { get; set; }

        public string ImageURL { get; set; }

        public string ImageDescription { get; set; }

        public DateTime DateLastEdit { get; set; }
    }
}
 