using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MVVMAvalonia.Services
{
    internal class JsonCollectionConverterConverter<T>
    {
        public List<T> Convert(string jsonString)
        {
            try
            {
                List<T> collection = JsonConvert.DeserializeObject
               <List<T>>(jsonString);

                return collection;
            }
            catch (Exception ex)
            {
                throw new JsonException();
            }
        }
    }
}
