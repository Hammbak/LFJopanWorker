using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal;
using SianControlGlobal.Abstract;


namespace SianControlGlobal.Concrete
{
    public class OrderItem :DataContext, IOrderItem
    {
        Folders Folders = new Folders();
        Files Files = new Files();

        public bool OrderedAllTheFilesExist(string strOrderItemCode, string sourcePath)
        {
           
            IList<string> sourcepathInFiles = SourcePathInFilesName(sourcePath);
            IList<string> OrderItemCode = GroupOrderItemCode(strOrderItemCode);

            foreach (var item in OrderItemCode.ToList())
	        {
                if (!(sourcepathInFiles.Contains(item))) return false;
                                 
	        }

            return true;                

        }

        public IList<string> GroupOrderItemCode(string strOrderItemCode)
        {
            IList<string> OrderItemCode = new List<string>();
            foreach (var item in db.OrderItemCode(strOrderItemCode).ToList())
            {                
                OrderItemCode.Add(item.strOrderItemCode);
            }
            return OrderItemCode;
        }

        public IList<string> SourcePathInFilesName(string sourcePath)
        {
            IList<string> sourcepathInFiles = new List<string>();
            foreach (var itemFiles in Folders.FolderInGetFileInfo(sourcePath).ToList())
            {
                sourcepathInFiles.Add(Files.FileExtensionDelete(itemFiles));
            }
            return sourcepathInFiles;
        }

    }
}
