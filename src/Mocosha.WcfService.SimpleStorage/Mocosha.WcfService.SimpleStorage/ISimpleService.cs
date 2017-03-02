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
        Dictionary<string, string> GetAll();

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Find/{id}")]
        string FindById(string id);

        [OperationContract]
        string Add(string value);
        
        [OperationContract(Name = "AddWithKey")]
        string Add(string key, string value);

        [OperationContract]
        string Update(string id, string value);

        [OperationContract]
        string Remove(string id);

        [OperationContract]
        string AddAnimal(string key, Animal animal);

        [OperationContract]
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
