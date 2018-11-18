using Newtonsoft.Json;
using Runpath.repository.Interface;
using System;
using System.Collections.Generic;
using System.Net;

namespace Runpath.repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public List<T> GetAll(string url)
        {
            return Call(url);
        }

        private List<T> Call(string url)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
