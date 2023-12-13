using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVCTask1.Models;

namespace WebApplicationMVCTask1.Interface
{
    public interface RegisterInterface
    {
        ResponseModel SignUpAction(RegisterUser objmodel);
        ResponseModel CheckLogin(RegisterUser objmodel);
    }
}
