using System;
using System.IO;
using System.Collections.Generic;


namespace SianControlGlobal.Abstract
{
   public interface IOrderItem  
    {       
       bool OrderedAllTheFilesExist(string strOrderItemCode, string sourcePath);
    }
}
