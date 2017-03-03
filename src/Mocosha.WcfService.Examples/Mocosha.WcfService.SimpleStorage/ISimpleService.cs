using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mocosha.WcfService.SimpleStorage
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle =WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetAll")]
        Dictionary<string, string> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            UriTemplate = "Find/{id}")]
        string FindById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "Add/{value}")]
        string Add(string value);

        [OperationContract(Name = "AddWithKey")]
        [WebInvoke(Method = "GET", 
            UriTemplate = "AddWithKey/{key}/{value}")]
        string Add(string key, string value);

        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "Update/{id}/{value}")]
        string Update(string id, string value);

        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "Remove/{id}")]
        string Remove(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddAnimal", 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        string AddAnimal(string key, Animal animal);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindAnimalById/{id}")]
        Response<Animal> FindAnimalById(string id);
    }

    [DataContract]
    public class Animal
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Response<TResult>
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public TResult Result { get; set; }
    }
}
