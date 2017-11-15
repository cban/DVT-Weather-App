using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Services.RequestProvider
{
   public interface IRequestProvider
    {
      Task<TResult> GetAsync<TResult>(string uri, string token = "");
    }
}
