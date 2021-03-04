using System;

namespace RivTech.WebService.Generic.Service.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(string msg = "Not found.") : base(msg)
        {
        }
    }
}
