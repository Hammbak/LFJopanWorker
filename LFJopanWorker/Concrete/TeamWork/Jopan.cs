using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal.Abstract;
using SianControlGlobal.Concrete;
using System.IO;

namespace SianControlGlobal.Concrete.TeamWork
{
    // 발주(외주) 포함 - 단계이동 작업하기는 조판 판 등록 할때 적용시킨다. (프로시져->dbo.JopanInsert)
    public class Jopan : Constant
    {
        //Folders Folders = new Folders();
        //Files Files = new Files();
        //Logs Logs = new Logs();
        //CleanUp CleanUp = new CleanUp();
        //StepMove StepMove = new StepMove();
        //OrderItem OrderItem = new OrderItem();

        //public void PdfExecute()
        //{
        //    Console.Write("====== 서버PDF폴더 작업 ======");
        //    string sourcePath = pdfLocalPath;
        //    string targetPath = siansourcePath;
        //    string targetPath2 = pdfJopanUploadPath;
        //    string targetPath3 = backupPath + "\\" + Folders.TodayFolder_Path() + pdfdatabackupPath;

        //    string targetSianPath = sianbackuptPath;
        //    //pdfSourc폴더의 파일을 검토해서
        //    //조판할수 있는 항목인지: state가 MAKE 이상, 취소,환불아이템 아닌것
        //    //입금완료되었는지,
        //    // 

        //    foreach (var item in Folders.FolderInGetFileInfo(sourcePath).ToList())
        //    {
        //        try
        //        {
        //            if (db.funIsCangotoJopan(Files.FileExtensionDelete(item)) == true && db.funIsMoneyInput(Files.FileExtensionDelete(item)) == true && db.funOrderItemReqCheckCount(Files.FileExtensionDelete(item)) == 0)
        //            {
        //                db.JopanLog_Insert(1, Files.FileExtensionDelete(item));

        //                //시안업로드 폴더에 PDF파일을 복사
        //                Files.FileCopy(targetPath, item);

        //                string[] INJopanPlace = new string[] { "ADPRINT", "DUKIL" };
        //                if (INJopanPlace.Contains(db.funGETstrTradeCpyCode(Files.FileExtensionDelete(item))))
        //                {
        //                    //PDF_OUT 폴더에 PDF파일을 복사
        //                    Files.FileCopy(targetPath2, item);
        //                    db.JopanLog_Insert(3, Files.FileExtensionDelete(item));
        //                }

        //                string OrderItemCode = Files.FileExtensionDelete(item);
        //                StepMove.MAKE_ASSIGN(OrderItemCode);
                         
        //                //시안백업폴더에 시안디렉토리를 생성 : 나중에 시안을 백업폴더에 복사하려고 했는데 백업 위치를 바꿔버렸음.
        //                //DirectoryInfo sianDirectory = new DirectoryInfo(OrderItemCode);
        //                //DirectoryInfo targetDirectory = Folders.TargetDirectoryMake(targetSianPath, sianDirectory);
        //                //string sianFilePath = (string.Format("{0}\\{1}.jpg", targetDirectory.FullName.ToString().Replace(targetSianPath, ""), OrderItemCode)).Replace("\\", "/");
        //                string sianFilePath = DateTime.Today.ToDateString().Replace("-", "/") + "/" + OrderItemCode + ".jpg";
        //                //시안정보를 등록
        //                db.USP_tblOrderItem_SianFilePath(OrderItemCode, sianFilePath);
                       
        //                //발주완료처리
        //                StepMove.ORDER_ORDEND(item.Name.Replace(".pdf", ""));

        //                //pdf를 백업폴더에 복사 :2011/7/25/PDFDATA/ADPRINT등/
        //                Files.FileCopy(Folders.Target_TradeCpy_Path(targetPath3, item), item);

        //                //정리폴더에 있는 ai데이터를 백업폴더로 복사하고 정리폴더의 데이터를 삭제
        //                CleanUp.CleanUpBackupExecute(item);

        //                //pdf데이터를 삭제
        //                item.Delete();

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Logs.LogFileMake(logPath, "LogFileName.txt", "Err " + item.FullName + " : " + ex.Message);
        //        }
        //    }
        //}
        //public string GetSianFilePath(DateTime date,string orderItemCode)
        //{
        //    return date.ToDateString().Replace("-", "/") + "/" + orderItemCode + ".jpg";
        //}
    }
}
