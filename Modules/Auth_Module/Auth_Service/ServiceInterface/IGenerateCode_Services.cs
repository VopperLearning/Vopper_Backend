using System;
using Auth_Module.Auth_Core.Entitys;

namespace Auth_Module.Auth_Core.Repository
{
    public interface IGenerate_Code
    {
        String GenerateCode(int longitud);
    }
}