using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceNewsOM
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<News> GetAllNews();

        [OperationContract]
        void AddNews(News news);

        [OperationContract]
        News GetOne(int id);

        [OperationContract]
        void UpdateNews(News news);

        [OperationContract]
        void DeleteNews(int id);
    }

    [DataContract]
    public class News
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Details { get; set; }
    }
}
