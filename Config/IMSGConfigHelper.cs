namespace ConfigHelper
{
    public interface IMSGConfigHelper
    {
        string TestClientUrl { get; set; }
        string AuthServerUrl { get; set; }
        string MSGApiGenUrl { get; set; }

        string MSGGenDB01 { get; set; }

        string Check();
    }


}
