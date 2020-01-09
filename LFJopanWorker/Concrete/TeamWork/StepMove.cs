using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SianControlGlobal.Concrete.TeamWork
{
   public class StepMove :Constant
   {
       public void ACCEPT_CHECK(string OrderItemCode)
       {
           db.USP_tblDataCheckLog_WORKSTATEUPDATE(GetintOrderItemNum(OrderItemCode), "AdPrint", "CHECK");
       }
       public void SBMAKE_END(string OrderItemCode)
       {            
           db.USP_tblDataCheckLog_WORKSTATEUPDATE(GetintOrderItemNum(OrderItemCode), "AdPrint", "END");
       }
       public void SBMAKE_END(int intOrderItemNum)
       {
           db.USP_tblDataCheckLog_WORKSTATEUPDATE(intOrderItemNum.ToString(), "AdPrint", "END");
       }
       public void MAKE_ASSIGN(string OrderItemCode)
       {
           db.USP_tblWorkItem_INSERT(GetintOrderItemNum(OrderItemCode), "AdPrint", "ASSIGN");
       }
       public void MAKE_ASSIGN(int intOrderItemNum)
       {
           db.USP_tblWorkItem_INSERT(intOrderItemNum.ToString(), "AdPrint", "ASSIGN");
       }
       public void SBORDER_SIANUPLOAD(string OrderItemCode, string sianFilePath)
       {
          //  string sianFilePath = (string.Format("{0}\\{1}.jpg", targetDirectory.FullName.ToString().Replace(targetPath, ""), item.Name.ToString())).Replace("\\", "/");
           db.USP_tblOrderItem_SianFilePath(OrderItemCode, sianFilePath);
       }       
       public void ORDER_ORDEND(string OrderItemCode)
       {
           db.USP_tblMKRequestItem_INSERT(GetintOrderItemNum(OrderItemCode), 0, "", DateTimeToString(DateTime.Now), DateTimeToString(DateTime.Now.AddDays(1)), db.funGETstrTradeCpyCode(OrderItemCode), "REG");
       }
       public void ORDER_ORDEND(string OrderItemCode, string datTradeDate, string datReciveDate)
       {
           db.USP_tblMKRequestItem_INSERT(GetintOrderItemNum(OrderItemCode), 0, "", datTradeDate, datReciveDate, db.funGETstrTradeCpyCode(OrderItemCode), "REG");
       }
       private string GetintOrderItemNum(string OrderItemCode)
       {
           var intOrderItemNum = from p in db.tblOrderItem
                                 where p.strOrderItemCode == OrderItemCode
                                 select p.intOrderItemNum;

           return intOrderItemNum.Single().ToString();
       }

       private string DateTimeToString(DateTime date)
       {
           return date.Year.ToString() + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") +
               " " + date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + ":" + date.Second.ToString("00");

       }
    }
}
