using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica.Application.Common.Interfaces.Helpers
{
    public interface ICryptoService
    {
        string Decrypt(string encoded, string key);
        string Encrypt(string source, string key);
    }
}
