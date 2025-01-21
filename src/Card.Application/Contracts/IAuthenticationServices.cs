using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Application.Contracts;
public interface IAuthenticationServices
{
    string Login(string usuario, string senha);
}
