using System.ServiceModel;

namespace WCF_ShareLibrary
{
    //共有オブジェクトのインターフェース
    [ServiceContract]
    public interface IShareObj
    {
        [OperationContract]
        string GetText();

        [OperationContract]
        void SetText(string str);
    }
}
