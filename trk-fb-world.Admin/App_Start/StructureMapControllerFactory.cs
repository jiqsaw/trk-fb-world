using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace TurkcellFacebookDunyasi.Admin
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //if (controllerType == null)
                //throw new HttpException(404, "Controller not found.");
            
            try
            { return ObjectFactory.GetInstance(controllerType) as IController; }
            catch (Exception)
            { 
                return base.GetControllerInstance(requestContext, controllerType); 
            }
        }
    }
}